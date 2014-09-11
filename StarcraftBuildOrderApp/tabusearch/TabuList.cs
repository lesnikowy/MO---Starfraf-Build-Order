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
			
		public Boolean isOnTabooList(TabuListItem i) {
			return tabulist.Contains (i);
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
