using System;
using System.Collections;
using System.Collections.Generic;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class TabuList
	{
		public List<TabuListItem> tabulist;
		private int retention;

		public TabuList(int retention)
		{
			tabulist = new List<TabuListItem>();
			this.retention = retention;
		}
			
		public int isOnTabooList(TabuListItem item) {
			for(int i=0;i<tabulist.Count;i++)
			{
				TabuListItem temp = tabulist [i];
				if (item.type == ItemType.ADDING) {
					if (temp.type == ItemType.DELETE
					    	&& temp.unitA == item.unitA
					    		&& temp.indexA == item.indexA)
						return i;
				} else if (item.type == ItemType.DELETE) {
					if (temp.type == ItemType.ADDING
						&& temp.unitA == item.unitA
							&& temp.indexA == item.indexA)
						return i;
				} else {
					if (temp.type == ItemType.EXCHANGE
						&& temp.unitA == item.unitA
							&& temp.indexA == item.indexA
								&& temp.unitB == item.unitB
								&& temp.indexB == item.indexB)
						return i;
				}
			}
			return -1;
		}

		public void clearOldMoves()
		{
			for(int i=0;i<tabulist.Count;i++) {
				TabuListItem item = tabulist [i];
				if (item.retention > 1)
					item.retention--;
				else {
					tabulist.RemoveAt (i);
					i--;
				}
			}
		}

		public void addToTabuList(TabuListItem item)
		{
			int itemIndex = -1;
			// Yes, this if really should look like that
			if ((itemIndex = isOnTabooList (item)) > 0) {
				tabulist [itemIndex].retention = retention;
			} else {
				item.retention = retention;
				tabulist.Add (item);
			}
		}
			
	}
}
