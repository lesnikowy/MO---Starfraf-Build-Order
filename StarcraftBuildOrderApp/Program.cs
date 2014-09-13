using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using StarcraftBuildOrderApp.simulation;
using StarcraftBuildOrderApp.cost_calc;
using StarcraftBuildOrderApp.tabusearch;

namespace StarcraftBuildOrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StreamWriter outfile = new StreamWriter("C:\\costs.txt");

            int start = Environment.TickCount;

           

            //initialize cost module
           
                cost.fullfill_coef = (float)(1000);
                cost.illegal_coef = (float)(10000);
                cost.ovrload_coef = (float)(10000);




                cost.add_build_req(unit_type.SUPPLY_DEPOT);
                cost.add_build_req(unit_type.MARINE);
                cost.add_build_req(unit_type.MARINE);
                cost.add_build_req(unit_type.MARINE);
                cost.add_build_req(unit_type.GOLIATH);
                cost.add_build_req(unit_type.GOLIATH);
                cost.add_build_req(unit_type.TANK);

                cost.add_req_unit();

                /* List<unit_type> tmp = new List<unit_type>();

                
                  tmp.Add(unit_type.BARRACKS);
               
                  tmp.Add(unit_type.FACTORY);
                  tmp.Add(unit_type.SCV);
                  tmp.Add(unit_type.MARINE);
                  tmp.Add(unit_type.SCV);
                  tmp.Add(unit_type.ARMORY);
                  tmp.Add(unit_type.SUPPLY_DEPOT);
                  tmp.Add(unit_type.MACHINE_SHOP);
                  tmp.Add(unit_type.MARINE);
                  tmp.Add(unit_type.TANK);
                  tmp.Add(unit_type.GOLIATH);
                  tmp.Add(unit_type.GOLIATH);
                  tmp.Add(unit_type.SCV);
                  tmp.Add(unit_type.SUPPLY_DEPOT);
                  tmp.Add(unit_type.SCV);
                  tmp.Add(unit_type.MARINE);


                  float ss = cost.calc(tmp); 
          
                  return;   */

                TabuSearch tabu = new TabuSearch(10, 10, new Solution());
                Solution s = tabu.iterate(tabu.bestSolution);


            int total_counter = 0;
            int good_solution_counter = 0;

            while (true)
            {
               
                    s = tabu.iterate(s);
                    Console.WriteLine("local best: " + s.cost + ",\t\t best: " + tabu.bestSolutionValue + ", \t\t total counter: " + total_counter);
                    s.printSolution();

                    outfile.WriteLine(s.cost + ";" + tabu.bestSolutionValue);

                   /* if (tabu.bestSolutionValue < 1000)
                    {
                        good_solution_counter++;
                    } */
                    total_counter++;

                    if (total_counter > 100000 | good_solution_counter > 10000)
                    {
                        break;
                    }
            }

            Console.WriteLine("DONE: total steps: " + total_counter );
            Console.WriteLine("Time: " + (Environment.TickCount - start)/1000 + "s");
            Console.WriteLine("Score: " + tabu.bestSolutionValue);
            tabu.bestSolution.printSolution();
            outfile.Close();
            Console.ReadKey();

         
        }
    }
}
