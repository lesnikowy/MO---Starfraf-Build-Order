using System;

namespace StarcraftBuildOrderApp
{
	enum ItemType {
		ADDING = 1,
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

	}
}

