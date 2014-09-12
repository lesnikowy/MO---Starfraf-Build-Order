using System;
using StarcraftBuildOrderApp.simulation;

namespace StarcraftBuildOrderApp.tabusearch
{
	public enum ItemType {
		ADDING = 0,
		EXCHANGE,
		DELETE,
	};

	public class TabuListItem
	{
		public ItemType type;
		public int indexA;
		public unit_type unitA;
		public int indexB;
		public unit_type unitB;
		public int retention;

		public TabuListItem (ItemType type, int indexA, int indexB, int retention)
		{
			this.type = type;
			this.indexA = indexA;
			this.indexB = indexB;
			this.retention = retention;
		}

		public TabuListItem()
		{
			this.type = ItemType.DELETE;
			this.indexA = 0;
			this.unitA = unit_type.NO_UNIT;
			this.indexB = 0;
			this.unitB = unit_type.NO_UNIT;
			this.retention = 0;
		}

		public TabuListItem(TabuListItem item)
		{
			this.type = item.type;
			this.indexA = item.indexA;
			this.unitA = item.unitA;
			this.indexB = item.indexB;
			this.unitB = item.unitB;
			this.retention = item.retention;
		}

		public void setToAdding(int index, unit_type unit) {
			this.type = ItemType.ADDING;
			this.indexA = index;
			this.unitA = unit;
			this.indexB = index;
			this.unitB = unit;
		}

		public void setToExchange(int indexA, unit_type unitA, int indexB, unit_type unitB)
		{
			this.type = ItemType.EXCHANGE;
			if (indexA < indexB) {
				this.indexA = indexA;
				this.unitA = unitA;
				this.indexB = indexB;
				this.unitB = unitB;
			} else {
				this.indexA = indexB;
				this.unitA = unitB;
				this.indexB = indexA;
				this.unitB = unitA;
			}
		}

		public void setToDelete(int index, unit_type unit)
		{
			this.type = ItemType.DELETE;
			this.indexA = index;
			this.unitA = unit;
			this.indexB = index;
			this.unitB = unit;
		}
			
	}
}

