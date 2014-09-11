﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarcraftBuildOrderApp.simulation;
using StarcraftBuildOrderApp.cost_calc;
using StarcraftBuildOrderApp.tabusearch;

namespace StarcraftBuildOrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            float score;
            // do not include starting units: SCVs and Command Center

            cost.build_req.Add(unit_type.MARINE);
			cost.build_req.Add (unit_type.FIREBAT);

			TabuSearch tabu = new TabuSearch (10, 10, new Solution ());
			Solution s = tabu.iterate (tabu.bestSolution);
			for (int i = 0; i < 500; i++) {
				s = tabu.iterate (s);
			}

			Console.WriteLine("Score: " + tabu.bestSolutionValue);
			tabu.bestSolution.printSolution ();


			Console.WriteLine ("KONIEC");
            Console.ReadKey();
        }
    }
}
