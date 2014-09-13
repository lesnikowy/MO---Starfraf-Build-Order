using System;
using System.Collections.Generic;
using StarcraftBuildOrderApp.cost_calc;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class TabuSearch
	{
		private int howManyNeighbours;
		private TabuList tabuList;

		public Solution bestSolution;
		public float bestSolutionValue;

		public TabuSearch (int howManyNeighbours, int retention, Solution seed)
		{
			this.howManyNeighbours = howManyNeighbours;
			tabuList = new TabuList (retention);
			bestSolution = seed;
			bestSolutionValue = evaluateSolution (seed);
		}

		public Solution iterate(Solution solution)
		{
			List<Solution> neighbours = createNeighbours(solution);
			Solution localBest = null;
			float localBestValue = float.MaxValue;
			Solution localBestTL = null;
			float localBestTLValue = float.MaxValue;

			Solution nextSolution = null;

			// Find lowest cost neighbours
			for(int i=0;i<neighbours.Count;i++)
			{
				Solution nb = neighbours[i];
				float value = evaluateSolution(nb);
				/* if (tabuList.isOnTabooList(nb.lastMove)) {
					if (value < localBestTLValue) {
						localBestTL = nb;
						localBestTLValue = value;
					}
				} else { */
				if (value < localBestValue) {
					localBest = nb;
                    localBest.cost = value;
					localBestValue = value;
				}
			}
			// Update TL
			tabuList.clearOldMoves();
			if (localBest == null)
				localBest = neighbours [0];
			nextSolution = localBest;

			// Choose best solution
			if (localBestValue < localBestTLValue && localBestValue < bestSolutionValue) {
				bestSolution = localBest;
				bestSolutionValue = localBestValue;
			} else if (localBestValue > localBestTLValue && localBestTLValue < bestSolutionValue) {
				nextSolution = bestSolution = localBestTL;
				bestSolutionValue = localBestTLValue;
			}
			tabuList.addToTabuList(nextSolution.lastMove);
			
			return nextSolution;
		}

		private List<Solution> createNeighbours(Solution solution)
		{
			List<Solution> neighbours = new List<Solution>();
			Random rnd = new Random();
			int endlessLoopPrevention = 0;

			for(int i=0;i<howManyNeighbours;i++) {
				Solution newNeighbour = new Solution(solution);
				int randomOperation = rnd.Next (0, 5);

                if (solution.getItemsQuantity() <= 2)
                {
                    randomOperation = 0;
                }

				newNeighbour.doRandomThing (randomOperation);
				neighbours.Add (newNeighbour);
				if (tabuList.isOnTabooList (newNeighbour.lastMove) > 0) {
					if (endlessLoopPrevention > 5) {
						endlessLoopPrevention = 0;
						continue;
					}
					i--;
					neighbours.RemoveAt (neighbours.Count - 1);
				}
				endlessLoopPrevention++;
			}
			return neighbours;
		}

		private float evaluateSolution(Solution solution)
		{
			return cost.calc (solution.getEnums ());
		}

	}
}

