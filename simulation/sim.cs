using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBuildOrderApp.simulation
{
    class sim {
        private uint time;
        private uint resources;
        private List<unit> unit_list;

        private uint total_supply_usage;
        private uint total_supply;

       public sim() {
            time = sim_const.start_time;
            resources = sim_const.start_resources;
            unit_list = new List<unit>();
            total_supply_usage = 0;
            total_supply = 0;
            Console.WriteLine("INFO: sim object initialized");
        }

        ~sim() {
            // nothing to destroy
        }

        public uint run(List <unit_type> raw_unit_vector) {
            time = sim_const.start_time;
            resources = sim_const.start_resources;
            total_supply_usage = 0;
            total_supply = 0;

            build_unit_list(raw_unit_vector);
            print_unit_list();

            if (!is_order_executable()) {
                return 0;
            }

            while (!is_full_build_done()) {
                Console.WriteLine("**************************");
                Console.WriteLine("TIME = " + time + " RESOURCES = " + resources);

                refresh_all_units_states();
                update_supply_stats();

                perform_build_actions();

                gather_resources();
                increment_timer();
                //System.Threading.Thread.Sleep(400);
            }

            return time;
        }

        private void build_unit_list(List <unit_type> raw_unit_vector) {
            unit_list.Clear();

            // start with 4 SCV and one CMD_CENTER
            unit_list.Add(new unit(unit_type.CMD_CENTER, true));
            for (int i = 0; i < 4; i++) {
                unit_list.Add(new unit(unit_type.SCV, true));
            }

            // translate IDs for simulation structures
            for (int i = 0; i < raw_unit_vector.Count; i++) {
                unit_list.Add(new unit(raw_unit_vector[i], false));
            }
        }

        private void print_unit_list() {
            Console.WriteLine("***************************");
            Console.WriteLine("Input build order:");
            for (int i = 0; i < unit_list.Count; i++) {
                Console.WriteLine( " " + (i+1) + " " + unit_list[i].name);
            }
            Console.WriteLine("***************************");
        }

        private List <unit_type> get_unit_type_list() {
            List<unit_type> unit_type_list = new List<unit_type>();

            for (int i = 0; i < unit_list.Count; i++) {
                unit_type_list.Add(unit_list[i].u_type);
            }

            return unit_type_list;
        }

	private bool are_requirements_met(int index, bool init_check) {
            List <unit_type> temp_unit_type_list = get_unit_type_list();
            for (int j = 0; j < unit_list[index].requirements.Count; j++) {
                if (!temp_unit_type_list.GetRange(0, index).Contains(unit_list[index].requirements[j]) && (!init_check || unit_list[index].get_state() == unit_state.READY)) {
                   return false;
                }
            }
  
            return true;
        }

        private bool is_order_executable() {
            for (int i = 0; i < unit_list.Count; i++) {
                if (!are_requirements_met(i, true)) {
                    Console.WriteLine("ERROR: unit type list not executable - requirements for unit " + unit_list[i].name + " not met");
                    return false;
                }
            }

            for (int i = 0; i < unit_list.Count; i++) {
                if (count_supply(i, false) < count_supply_usage(i, false)) {
                    Console.WriteLine("ERROR: unit type list not executable - no supply for unit on index " + i);
                    return false;
                }
            }

            return true;
        }

        private bool is_full_build_done() {
            for (int i = 0; i < unit_list.Count; i++) {
                if (unit_list[i].get_state() != unit_state.READY) {
                    return false;
                }
            }
            return true;
        }

        private uint count_unit_type(unit_type ref_type) {
            uint cnt = 0;
            for (int i = 0; i < unit_list.Count; i++) {
                if (ref_type == unit_list[i].u_type) {
                    cnt++;
                }
            }
            return cnt;
        }

        private void gather_resources() {
            if (time % sim_const.gather_interval == 0) {
                resources += count_unit_type(unit_type.SCV) * sim_const.gather_per_SCV;
            }
        }

        private void increment_timer() {
            time++;
        }

        private uint count_supply_usage(int index, bool state_matters) {
            uint result = 0;
            for (int i = 0; i < index; i++) {
                if (unit_list[i].supply_usage > 0 && (unit_list[i].is_consuming_supply() || !state_matters)) {
                    result += unit_list[i].supply_usage;
                }
            }
            return result;
        }

        private uint count_supply(int index, bool state_matters) {
            uint result = 0;
            for (int i = 0; i < index; i++) {
                if (unit_list[i].supply > 0 && (unit_list[i].is_providing_supply() || !state_matters)) {
                    result += unit_list[i].supply;
                }
            }
            return result;
        }

        private void update_supply_stats() {
            total_supply_usage = count_supply_usage(unit_list.Count, true);
            total_supply = count_supply(unit_list.Count, true);

            if (total_supply_usage > total_supply) {
                Console.WriteLine("ERROR: total_supply_usage = " + total_supply_usage + " is greater than total_supply = " + total_supply);
            } else { 
                Console.WriteLine("supply used = " + total_supply_usage + " total supply = " + total_supply);               
            }
        }

        private void refresh_constructed_unit_index(int index) {
            if (unit_list[index].get_constructed_unit_index() != sim_const.constructed_unit_index_no_unit) {
                if (unit_list[unit_list[index].get_constructed_unit_index()].get_state() == unit_state.READY) {
                   unit_list[index].unset_constructed_unit_index();
                }
            }
        }

        private void refresh_all_units_states() {
            for (int i = 0; i < unit_list.Count; i++) {
                unit_list[i].refresh_state();
            }

            // this cannot be done in pararel
            for (int i = 0; i < unit_list.Count; i++) {
                refresh_constructed_unit_index(i);
            }            
        }

        private int find_factory_not_bussy(int index) {
            for (int i = 0; i < unit_list.Count; i++) {
                if (unit_list[i].products.Count > 0 && unit_list[i].get_state() == unit_state.READY && unit_list[i].get_constructed_unit_index() == sim_const.constructed_unit_index_no_unit) {
                    for (int j = 0; j < unit_list[i].products.Count; j++) {
                        if (unit_list[i].products[j] == unit_list[index].u_type) {
                            return i;
                        }
                    }
                }
            }
            return sim_const.constructed_unit_index_no_unit;
        }

        private bool can_be_constructed(int index) {
            return resources >= unit_list[index].cost && are_requirements_met(index, false);
        }

        private void perform_build_actions() {
            int index_of_non_existing_unit = 0;
            bool found_non_existing_unit = false;
            int factory_index;
            for (int i = 0; i < unit_list.Count; i++) {
                if (unit_list[i].get_state() == unit_state.NOT_EXISTS) {
                    found_non_existing_unit = true;
                    index_of_non_existing_unit = i;
                    Console.WriteLine("next = " + index_of_non_existing_unit);
                    break;
                }
            }

            if (found_non_existing_unit) {
                do {
                    factory_index = find_factory_not_bussy(index_of_non_existing_unit);
                    if (can_be_constructed(index_of_non_existing_unit) && factory_index != sim_const.constructed_unit_index_no_unit) {
                        unit_list[factory_index].set_constructed_unit_index(index_of_non_existing_unit);
                        unit_list[index_of_non_existing_unit].enter_bld_state();
                        resources -= unit_list[index_of_non_existing_unit].cost;
                    }
                    index_of_non_existing_unit++;
                    if (! (index_of_non_existing_unit < unit_list.Count)) {
                        break;
                    }
                } while (unit_list[index_of_non_existing_unit].get_state() == unit_state.NOT_EXISTS); // pararelization
            }
        }
    };
}
