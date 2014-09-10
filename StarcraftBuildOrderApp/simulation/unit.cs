using System;
using System.Collections.Generic;
using System.Text;
using Logger;

namespace StarcraftBuildOrderApp.simulation
{
    // unit type IDs
    public enum unit_type {
        NO_UNIT = 0,

        // ground units
        SCV = 1,
        MARINE,
        FIREBAT,
        GHOST,
        VULTURE,
        TANK,
        GOLIATH,

        // buildings
        CMD_CENTER,
        SUPPLY_DEPOT,
        BARRACKS,
        ACADEMY,
        FACTORY,
        MACHINE_SHOP,
        ARMORY,

        UNIT_TYPE_SIZE
    };

    enum unit_state {
        NOT_EXISTS = 0,
        UNDER_CONSTRUCTION,
        READY
    };

    class unit {
        private unit_state state;
        private uint bld_time_left;

	// sim.unit_list index of unit being currently built by this structure during simulation
	// use sim_const.constructed_unit_index_no_unit for no unit
	private int constructed_unit_index;

        public readonly unit_type u_type;
        public readonly string name;
        public readonly uint cost;
        public readonly uint bld_time;
        public readonly uint supply_usage;
        public readonly uint supply;
        public readonly bool building;
        public readonly List<unit_type> products;
        public readonly List<unit_type> requirements;

        ~unit() {
            // nothing to destroy
        }

        public unit(unit_type type, bool start_unit) {
            if (start_unit) {
                state = unit_state.READY;
            }
            else {
                state = unit_state.NOT_EXISTS;
            }

            if (type < unit_type.NO_UNIT && type > unit_type.UNIT_TYPE_SIZE) {
                Logger.Log.Write("ERROR: unit class constructor: unknown unit type " + type + "\n");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            } else {
                products = new List<unit_type>();
                requirements = new List<unit_type>();
                u_type = type;
		constructed_unit_index = sim_const.constructed_unit_index_no_unit;

                switch (type) {
                    case unit_type.NO_UNIT:
                        //skip for compilance
                        break;
                    case unit_type.SCV:
                        name = "SCV";
                        cost = 50;
                        bld_time = 20;
                        supply_usage = 1;
                        supply = 0;
                        building = false;
                        products.Add(unit_type.CMD_CENTER);
                        products.Add(unit_type.SUPPLY_DEPOT);
                        products.Add(unit_type.BARRACKS);
                        products.Add(unit_type.ACADEMY);
                        products.Add(unit_type.FACTORY);
                        products.Add(unit_type.ARMORY);
                        products.Add(unit_type.MACHINE_SHOP);
                        requirements.Add(unit_type.CMD_CENTER);
                        break;
                    case unit_type.MARINE:
                        name = "Marine";
                        cost = 50;
                        bld_time = 25;
                        supply_usage = 1;
                        supply = 0;
                        building = false;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        break;
                    case unit_type.FIREBAT:
                        name = "Firebat";
                        cost = 75;
                        bld_time = 30;
                        supply_usage = 1;
                        supply = 0;
                        building = false;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        requirements.Add(unit_type.ACADEMY);
                        break;
                    case unit_type.GHOST:
                        name = "Ghost";
                        cost = 100;
                        bld_time = 50;
                        supply_usage = 1;
                        supply = 0;
                        building = false;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        requirements.Add(unit_type.ACADEMY);
                        break;
                    case unit_type.VULTURE:
                        name = "Vulture";
                        cost = 70;
                        bld_time = 35;
                        supply_usage = 2;
                        supply = 0;
                        building = false;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        requirements.Add(unit_type.FACTORY);
                        break;
                    case unit_type.TANK:
                        name = "Tank";
                        cost = 150;
                        bld_time = 50;
                        supply_usage = 3;
                        supply = 0;
                        building = false;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        requirements.Add(unit_type.FACTORY);
                        requirements.Add(unit_type.MACHINE_SHOP);
                        break;
                    case unit_type.GOLIATH:
                        name = "Goliath";
                        cost = 125;
                        bld_time = 45;
                        supply_usage = 2;
                        supply = 0;
                        building = false;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        requirements.Add(unit_type.FACTORY);
                        requirements.Add(unit_type.ARMORY);
                        break;

                    // buildings
                    case unit_type.CMD_CENTER:
                        name = "Command Center";
                        cost = 400;
                        bld_time = 100;
                        supply_usage = 0;
                        supply = 10;
                        building = true;
                        products.Add(unit_type.SCV);
                        requirements.Clear();
                        break;
                    case unit_type.SUPPLY_DEPOT:
                        name = "Supply Depot";
                        cost = 100;
                        bld_time = 40;
                        supply_usage = 0;
                        supply = 9;
                        building = true;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        break;
                    case unit_type.BARRACKS:
                        name = "Barracks";
                        cost = 100;
                        bld_time = 55;
                        supply_usage = 0;
                        supply = 0;
                        building = true;
                        products.Add(unit_type.MARINE);
                        products.Add(unit_type.FIREBAT);
                        requirements.Add(unit_type.CMD_CENTER);
                        break;
                    case unit_type.ACADEMY:
                        name = "Academy";
                        cost = 100;
                        bld_time = 40;
                        supply_usage = 0;
                        supply = 0;
                        building = true;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        break;
                    case unit_type.FACTORY:
                        name = "Supply Depot";
                        cost = 150;
                        bld_time = 60;
                        supply_usage = 0;
                        supply = 0;
                        building = true;
                        products.Add(unit_type.TANK);
                        products.Add(unit_type.VULTURE);
                        products.Add(unit_type.GOLIATH);
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        break;
                    case unit_type.MACHINE_SHOP:
                        name = "Supply Depot";
                        cost = 75;
                        bld_time = 45;
                        supply_usage = 0;
                        supply = 0;
                        building = true;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        requirements.Add(unit_type.FACTORY);
                        break;
                    case unit_type.ARMORY:
                        name = "Armory";
                        cost = 125;
                        bld_time = 50;
                        supply_usage = 0;
                        supply = 0;
                        building = true;
                        products.Clear();
                        requirements.Add(unit_type.CMD_CENTER);
                        requirements.Add(unit_type.BARRACKS);
                        requirements.Add(unit_type.FACTORY);
                        break;
                    default:
                        Logger.Log.Write("ERROR: UNKNOWN UNIT TYPE: " + type + ". EXITING...\n");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public unit_state get_state() {
            return state;
        }

        public uint get_bld_time_left() {
            return bld_time_left;
        }

        public void refresh_state() {
            if (state == unit_state.UNDER_CONSTRUCTION) {
                if (bld_time_left == 0) {
                    state = unit_state.READY;
                    Logger.Log.Write(u_type + " build finished!!!");
                } else {
                    bld_time_left--;
                    Logger.Log.Write(bld_time_left + " until " + u_type + " build finish");
               }
            }
        }

        public void enter_bld_state() {
            if (state == unit_state.NOT_EXISTS) {
                // chceck if unit can be constructed
                state = unit_state.UNDER_CONSTRUCTION;
                bld_time_left = bld_time;
                Logger.Log.Write("INFO: " + u_type + " is under construction");
            } else {
                Logger.Log.Write("ERROR: Cannot start unit " + name + " build - invalid state = " + state);
            }
        }

        public bool set_constructed_unit_index(int unit_index) {
            if (constructed_unit_index != sim_const.constructed_unit_index_no_unit) {
                Logger.Log.Write("ERROR: Attempt to construct unit when factory is bussy");
                return false;
            } else {
                Logger.Log.Write(u_type + " is constructiong unit with index " + unit_index);
                constructed_unit_index = unit_index;
                return true;
            }
        }

        public void unset_constructed_unit_index() {
            constructed_unit_index = sim_const.constructed_unit_index_no_unit;
        }

        public int get_constructed_unit_index() {
            return constructed_unit_index;
        }

        public bool is_consuming_supply() {
            if (state == unit_state.READY || state == unit_state.UNDER_CONSTRUCTION) {
                return true;
            } else {
                return false;
            }
        }

        public bool is_providing_supply() {
            if (state == unit_state.READY) {
                return true;
            } else {
                return false;
            }
        }
    };
}
