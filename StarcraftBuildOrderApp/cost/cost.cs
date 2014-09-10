using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarcraftBuildOrderApp.simulation;

namespace StarcraftBuildOrderApp.cost_calc
{
    static class cost
    {

        public static List<unit_type> build_req = new List<unit_type>();


        private static List<unit> unit_list = new List<unit>();

        public static float calc(List<unit_type> raw_unit_vector)
        {

            sim sim_unit = new sim();


            //##############################################################
            // check fulfillment of requirements
            int fulfillment = 0;
            if (build_req.Count != 0)
            {
                int[] build_req_unit_count = new int[(int)(unit_type.UNIT_TYPE_SIZE)];
                int[] build_unit_count = new int[(int)(unit_type.UNIT_TYPE_SIZE)];

                for (int i = 0; i < build_req.Count(); i++ )
                {
                    build_req_unit_count[(int)(build_req[i])]++;
                }

                for (int i = 0; i < raw_unit_vector.Count(); i++)
                {
                    build_unit_count[(int)(raw_unit_vector[i])]++;
                }


                for (int i = 0; i < build_req_unit_count.Count(); i++)
                {
                    if(build_req_unit_count[i] != 0) {
                        fulfillment += Math.Abs(build_req_unit_count[i] - build_unit_count[i]);
                    }
                }
            }
            
            
            //##############################################################
            // check correctness of build order 



            int illegal_unit_cnt = 0;

            build_unit_list(raw_unit_vector);

            for (int i = 1; i < unit_list.Count() ; i++)
            {
                
                for (int req = 0; req < unit_list[i].requirements.Count(); req++ )
                {
                    bool legal_unit = false;
                    for (int j = i-1; j >= 0; j--)
                    {
                        if (unit_list[i].requirements[req] == unit_list[j].u_type)
                        {
                            legal_unit = true;
                            break;
                        }
                    }

                    if (!legal_unit)
                    {
                        illegal_unit_cnt++;
                        break;
                    }
                }
            }



                //##############################################################
                // check timing
            if (fulfillment == 0 && illegal_unit_cnt == 0)
                {
                    return (float)(sim_unit.run(unit_list));
                }
                else
                {
                    return (float)(fulfillment) * (float)(1000.0) + (float)(illegal_unit_cnt)*(float)(10000.0);
                }
            
            
        }


        private static void build_unit_list(List<unit_type> raw_unit_vector)
        {
            unit_list.Clear();

            // start with 4 SCV and one CMD_CENTER
            unit_list.Add(new unit(unit_type.CMD_CENTER, true));
            for (int i = 0; i < 4; i++)
            {
                unit_list.Add(new unit(unit_type.SCV, true));
            }

            // translate IDs for simulation structures
            for (int i = 0; i < raw_unit_vector.Count; i++)
            {
                unit_list.Add(new unit(raw_unit_vector[i], false));
            }
        }

    }
}
