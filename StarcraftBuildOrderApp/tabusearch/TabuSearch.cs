using System;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class TabuSearch
	{
		int howManyNeighbours;
		int retention;
		TabuList tabuList;

		Solution bestSolution;
		float bestSolutionValue;

		public TabuSearch (int howManyNeighbours, int retention)
		{
			this.howManyNeighbours = howManyNeighbours;
			this.retention = retention;
			tabuList = new TabuList (retention);
		}

		public Solution iterate()
		{
			Solution[] neighbours = createNeighbours(start);
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
				if (tabuList.isOnTabooList(nb.getLastMove())) {
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
			tabuList.addToTabuList(nextSolution.getLastMove());
			// Choose best solution
			if (localBestValue < localBestTLValue && localBestValue < bestSolutionValue) {
				bestSolution = localBest;
				bestSolutionValue = localBestValue;
			} else if (localBestValue > localBestTLValue && localBestTLValue < bestSolutionValue) {
				nextSolution = bestSolution = localBestTL;
				bestSolutionValue = localBestTLValue;
			}
			return nextSolution;
		}

		private Solution[] createNeighbours()
		{
			Solution[] neighbours = new Solution[howManyNeighbours];
			Random rnd = new Random();

			for(int i=0;i<howManyNeighbours;i++) {
				Solution newNeighbour = new Solution(solution);
				Boolean drawnTheSameElements = true;
				int indexA = 0, indexB = 0;
				int loopBoundary = 0;
				while(drawnTheSameElements) {
					indexA = rnd.Next(0, newNeighbour.getItemsQuantity() - 1);
					indexB = rnd.Next(0, newNeighbour.getItemsQuantity() - 1);
					if (loopBoundary > 1000)
						break;
					loopBoundary++;
					if (newNeighbour.itemsAtIndexesHaveDifferentLength(indexA, indexB))
						drawnTheSameElements = false;
				}

				newNeighbour.exchangeTwoItems(indexA, indexB);
				neighbours[i] = newNeighbour;
			}
			return neighbours;
		}

		private void evaluateSolution()
		{
			// wez i wywolaj zajebiste funkcje ukaszowe
		}

	}
}

