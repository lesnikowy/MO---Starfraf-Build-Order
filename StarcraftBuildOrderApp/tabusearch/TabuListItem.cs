using System;

namespace StarcraftBuildOrderApp.tabusearch
{
	public enum ItemType {
		ADDING = 0,
		EXCHANGE,
		DELETE,
	};

	public class TabuListItem
	{
		ItemType type;
		int indexA;
		int indexB;
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
			this.indexB = 0;
			this.retention = 0;
		}

		public TabuListItem(TabuListItem item)
		{
			this.type = item.type;
			this.indexA = item.indexA;
			this.indexB = item.indexB;
			this.retention = item.retention;
		}

		public void setToAdding(int index) {
			this.type = ItemType.ADDING;
			this.indexA = index;
			this.indexB = index;
		}

		public void setToExchange(int indexA, int indexB)
		{
			this.type = ItemType.EXCHANGE;
			if (indexA < indexB) {
				this.indexA = indexA;
				this.indexB = indexB;
			} else {
				this.indexA = indexB;
				this.indexB = indexA;
			}
		}

		public void setToDelete(int index)
		{
			this.type = ItemType.DELETE;
			this.indexA = index;
			this.indexB = index;
		}

		public override bool Equals(System.Object obj)
		{
			bool sameSame = false;
			TabuListItem o = (TabuListItem) obj;
			sameSame = this.indexA == o.indexA && this.indexB == o.indexB;
			return sameSame;
		}	

		public override int GetHashCode() {
			int prime = 31;
			int result = 1;
			result = prime * result + ((indexA == null) ? 0 : indexA.GetHashCode());
			result = prime * result + ((indexB == null) ? 0 : indexB.GetHashCode());
			return result; 
		}
	}
}

