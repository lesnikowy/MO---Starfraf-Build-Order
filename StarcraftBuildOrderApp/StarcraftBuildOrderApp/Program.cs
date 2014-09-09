using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarcraftBuildOrderApp.simulation;
using StarcraftBuildOrderApp.cost_calc;

namespace StarcraftBuildOrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            float score;
            // do not include starting units: SCVs and Command Center
            List<unit_type> bld_order = new List<unit_type>();

           

            cost.build_req.Add(unit_type.MARINE);
            cost.build_req.Add(unit_type.MARINE);


            bld_order.Add(unit_type.SCV);
            bld_order.Add(unit_type.BARRACKS);
            bld_order.Add(unit_type.BARRACKS);
            bld_order.Add(unit_type.MARINE);
            bld_order.Add(unit_type.MARINE);
            bld_order.Add(unit_type.ACADEMY);



            score = cost.calc(bld_order);

            Console.WriteLine("Score: " + score);

            Console.ReadKey();
        }
    }
}
