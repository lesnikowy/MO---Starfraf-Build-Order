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
            
            float score;
            // do not include starting units: SCVs and Command Center
            
			TabuSearch tabu = new TabuSearch (30, 50, new Solution ());
			Solution s = tabu.iterate (tabu.bestSolution);
			for (int i = 0; i < 5000; i++) {
				s = tabu.iterate (s);
			}

			Console.WriteLine("Score: " + tabu.bestSolutionValue);

			Console.WriteLine ("KONIEC");
            Console.ReadKey();
        }
    }
}
