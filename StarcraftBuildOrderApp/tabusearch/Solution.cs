using System;
using System.Collections.Generic;
using StarcraftBuildOrderApp.simulation;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class Solution
	{
		private List<unit_type> items;
		public TabuListItem lastMove;
		private const int MAXIMUM_UNITS_IN_RANDOM_SOLUTION = 10;

		public Solution()
		{
			items = new List<unit_type>();
			lastMove = new TabuListItem ();
			createRandomSolution ();
		}

		public Solution(Solution solution)
		{
			this.items = new List<unit_type> (solution.items);
			this.lastMove = new TabuListItem (solution.lastMove);
		}

		public Solution createRandomSolution()
		{
			Random rnd = new Random ();
			int howManyUnits = rnd.Next (0, MAXIMUM_UNITS_IN_RANDOM_SOLUTION);
			for (int i = 0; i < howManyUnits; i++) {
				items.Add ((unit_type)rnd.Next (1, (int)unit_type.UNIT_TYPE_SIZE - 1));
			}
			return this;
		}

		public void doRandomThing(int operation)
		{
			if (operation == 0)
				addUnit ();
			else if (operation > 1 && operation < 8)
				exchangeUnits ();
			else {
				if (items.Count > 2)
					removeUnit ();
			}
		}

		private void addUnit ()
		{
			Random rnd = new Random ();
			items.Add ((unit_type)rnd.Next (1, (int)unit_type.UNIT_TYPE_SIZE - 1));
			lastMove.setToAdding (items.Count);
		}

		private void exchangeUnits()
		{
			bool drawnUnitsOfTheSameType = true;
			Random rnd = new Random ();

			int indexA = 0;
			int indexB = 0;
			int endlessLoopPrevention = 0;

			while (drawnUnitsOfTheSameType) {
				indexA = rnd.Next(0, items.Count - 1);
				indexB = rnd.Next(0, items.Count - 1);
				if (items [indexA] != items [indexB])
					drawnUnitsOfTheSameType = false;
				if (endlessLoopPrevention > 3)
					drawnUnitsOfTheSameType = false;
				endlessLoopPrevention++;
			}
			// swap elements
			unit_type temp = items [indexA];
			items [indexA] = items [indexB];
			items [indexB] = temp;

			lastMove.setToExchange (indexA, indexB);
		}

		private void removeUnit()
		{
			Random rnd = new Random ();
			int index = rnd.Next (0, items.Count - 1);
			items.RemoveAt(index);
			lastMove.setToDelete (index);

		}

		public int getItemsQuantity()
		{
			return items.Count;
		}
		public List<unit_type> getEnums()
		{
			return items;
		}

		public void printSolution() {
			string s = "[ ";
			for (int i = 0; i < items.Count; i++) {
				s += items[i].ToString() + " ";
			}
			Console.WriteLine (s + " ]"); 
		}
	}
}

