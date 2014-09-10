using System;
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
            
           
           


            cost.build_req.Add(unit_type.MARINE);
            //cost.build_req.Add(unit_type.MARINE);

			TabuSearch tabu = new TabuSearch (10, 50, new Solution ());
			Solution s = tabu.iterate (tabu.bestSolution);
			for (int i = 0; i < 1000; i++) {
				s = tabu.iterate (s);
			}

			Console.WriteLine("Score: " + tabu.bestSolutionValue);

            Console.ReadKey();
        }
    }
}
