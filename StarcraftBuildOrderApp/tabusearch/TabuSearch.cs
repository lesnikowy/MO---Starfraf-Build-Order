using System;
using StarcraftBuildOrderApp.cost_calc;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class TabuSearch
	{
		private int howManyNeighbours;
		private int retention;
		private TabuList tabuList;

		public Solution bestSolution;
		public float bestSolutionValue;

		public TabuSearch (int howManyNeighbours, int retention, Solution seed)
		{
			this.howManyNeighbours = howManyNeighbours;
			this.retention = retention;
			tabuList = new TabuList (retention);
			bestSolution = seed;
			bestSolutionValue = evaluateSolution (seed);
		}

		public Solution iterate(Solution solution)
		{
			Solution[] neighbours = createNeighbours(solution);
			Solution localBest = null;
			float localBestValue = float.MaxValue;
			Solution localBestTL = null;
			float localBestTLValue = float.MaxValue;

			Solution nextSolution = null;

			// Find lowest cost neighbours
			for(int i=0;i<howManyNeighbours;i++)
			{
				Solution nb = neighbours[i];
				float value = evaluateSolution(nb);
				if (tabuList.isOnTabooList(nb.lastMove)) {
					if (value < localBestTLValue) {
						localBestTL = nb;
						localBestTLValue = value;
					}
				} else {
					if (value < localBestValue) {
						localBest = nb;
						localBestValue = value;
					}
				}	
			}
			// Update TL
			tabuList.clearOldMoves();
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
			Console.WriteLine ("local best: " + localBestValue + "local best TL: " + localBestTLValue + ", best: " + bestSolutionValue);
			nextSolution.printSolution ();
			return nextSolution;
		}

		private Solution[] createNeighbours(Solution solution)
		{
			Solution[] neighbours = new Solution[howManyNeighbours];
			Random rnd = new Random();

			for(int i=0;i<howManyNeighbours;i++) {
				Solution newNeighbour = new Solution(solution);
				int randomOperation = rnd.Next (0, 6);

				newNeighbour.doRandomThing (randomOperation);
				neighbours[i] = newNeighbour;
				if (tabuList.isOnTabooList (newNeighbour.lastMove))
					i--;
			}
			return neighbours;
		}

		private float evaluateSolution(Solution solution)
		{
			return cost.calc (solution.getEnums ());
		}

	}
}

