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
				else
					tabulist.Remove(i); i--;
			}
		}

		public void addToTabuList(TabuListItem item)
		{
			if (isOnTabooList (item))
				tabulist [tabulist.FindIndex (item)].retention = retention;
			else
				tabulist.Add (item);
		}
	}
}

