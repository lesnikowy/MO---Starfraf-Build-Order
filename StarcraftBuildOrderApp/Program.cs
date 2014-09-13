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
            

            //initialize cost module
           
                cost.fullfill_coef = (float)(1000);
                cost.illegal_coef = (float)(10000);
                cost.ovrload_coef = (float)(10000);


                cost.build_req.Add(unit_type.SUPPLY_DEPOT);
                cost.build_req.Add(unit_type.MARINE);
                cost.build_req.Add(unit_type.MARINE);
                cost.build_req.Add(unit_type.MARINE);
                cost.build_req.Add(unit_type.GOLIATH);

                TabuSearch tabu = new TabuSearch(10, 10, new Solution());
                Solution s = tabu.iterate(tabu.bestSolution);


            while (true)
            {
                for (int i = 0; i < 5000; i++)
                {
                    s = tabu.iterate(s);
                }

                Console.WriteLine("Score: " + tabu.bestSolutionValue);
                tabu.bestSolution.printSolution();


                Console.WriteLine("KONIEC");
                if (Console.ReadKey().Key  == ConsoleKey.Enter)
                {
                    break;
                }

            }
        }
    }
}
