using System;
using System.Collections.Generic;
using System.Text;
using Logger;

namespace StarcraftBuildOrderApp
{
    class UnitTest {
        static void Main(string[] args) {
            bool finished;

            simulation.sim sim_unit = new simulation.sim();
	        uint score;
	        // do not include starting units: SCVs and Command Center
            List<simulation.unit_type> bld_order = new List<simulation.unit_type>();

            bld_order.Add(simulation.unit_type.SCV);
            bld_order.Add(simulation.unit_type.BARRACKS);
            bld_order.Add(simulation.unit_type.BARRACKS);
            bld_order.Add(simulation.unit_type.MARINE);
            bld_order.Add(simulation.unit_type.MARINE);
            bld_order.Add(simulation.unit_type.ACADEMY);	

            score = sim_unit.run(bld_order);

            Logger.Log.Write("INFO: Build order compleated with time " + score);

            System.Threading.Thread.Sleep(5000);
        }
    }
}
