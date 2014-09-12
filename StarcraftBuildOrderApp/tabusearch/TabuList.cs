using System;
using System.Collections;
using System.Collections.Generic;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class TabuList
	{
		private List<TabuListItem> tabulist;
		private int retention;

		public TabuList(int retention)
		{
			tabulist = new List<TabuListItem>();
			this.retention = retention;
		}
			
		public Boolean isOnTabooList(TabuListItem item) {
			for(int i=0;i<tabulist.Count;i++)
			{
				TabuListItem temp = tabulist [i];
				if (item.type == ItemType.ADDING) {
					if (temp.type == ItemType.DELETE
					    	&& temp.unitA == item.unitA
					    		&& temp.indexA == item.indexA)
						return true;
				} else if (item.type == ItemType.DELETE) {
					if (temp.type == ItemType.ADDING
						&& temp.unitA == item.unitA
							&& temp.indexA == item.indexA)
						return true;
				} else {
					if (temp.type == ItemType.EXCHANGE
						&& temp.unitA == item.unitA
							&& temp.indexA == item.indexA
								&& temp.unitB == item.unitB
								&& temp.indexB == item.indexB)
						return true;
				}
			}
			return false;
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
			if (isOnTabooList (item)) {
				int index = tabulist.IndexOf (item);
				tabulist [index].retention = retention;
			} else {
				item.retention = retention;
				tabulist.Add (item);
			}
		}
			
	}
}
