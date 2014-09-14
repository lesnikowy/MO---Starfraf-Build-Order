using System;
using System.Collections.Generic;
using StarcraftBuildOrderApp.simulation;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class Solution
	{
		private List<unit_type> items;
		public TabuListItem lastMove;
        public float cost;

		private const int MAXIMUM_UNITS_IN_RANDOM_SOLUTION = 10;

		public Solution()
		{
			items = new List<unit_type>();
			lastMove = new TabuListItem ();
			createRandomSolution (10);
		}

		public Solution(int maxUnitsInRandomSolution)
		{
			items = new List<unit_type>();
			lastMove = new TabuListItem ();
			createRandomSolution (maxUnitsInRandomSolution);
		}

		public Solution(Solution solution)
		{
			this.items = new List<unit_type> (solution.items);
			this.lastMove = new TabuListItem (solution.lastMove);
		}

		public Solution createRandomSolution(int size)
		{
			Random rnd = new Random ();
			int howManyUnits = rnd.Next (2, size);
			for (int i = 0; i < size; i++) {
				items.Add ((unit_type)rnd.Next (1, (int)unit_type.UNIT_TYPE_SIZE));
			}
			return this;
		}

		public void addUnit ()
		{
			Random rnd = new Random ();
			unit_type unit = (unit_type)rnd.Next (1, (int)unit_type.UNIT_TYPE_SIZE);
			items.Add (unit);
			lastMove.setToAdding (items.Count, unit);
		}

		public void exchangeUnits()
		{
			bool drawnUnitsOfTheSameType = true;
			Random rnd = new Random ();

			int indexA = 0;
			int indexB = 0;
			int endlessLoopPrevention = 0;

			while (drawnUnitsOfTheSameType) {
				indexA = rnd.Next(0, items.Count);
				indexB = rnd.Next(0, items.Count);
				if (items [indexA] != items [indexB])
					drawnUnitsOfTheSameType = false;
				if (endlessLoopPrevention > 10)
					drawnUnitsOfTheSameType = false;
				endlessLoopPrevention++;
			}
			// swap elements
			unit_type temp = items [indexA];
			items [indexA] = items [indexB];
			items [indexB] = temp;

			lastMove.setToExchange (indexA, items [indexA], indexB, items [indexB]);
		}

		public void removeUnit()
		{
			Random rnd = new Random ();
			int index = rnd.Next (0, items.Count);
			unit_type unit = items [index];
			items.RemoveAt(index);
			lastMove.setToDelete (index, unit);

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

