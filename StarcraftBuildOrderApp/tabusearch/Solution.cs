using System;
using System.Collections.Generic;
using StarcraftBuildOrderApp.simulation;

namespace StarcraftBuildOrderApp.tabusearch
{
	public class Solution
	{
		private List<unit_type> items;
		private TabuListItem lastMove;

		public Solution()
		{
			items = new List<unit_type>();
			lastMove = null;
		}

		/* Konstruktor kopiujacy
		public Solution(Solution solution) {
			List<unit_type> i = (ArrayList<Item>)solution.items;
			this.items = (ArrayList<Item>)i.clone();
			this.lastMove = new TabooListItem();
		} */

		public void populateSolution(List<Item> plannedItems) {
			for(int i=0;i<plannedItems.size();i++) {
				for(int j=0;j<plannedItems.get(i).getQuantity();j++) {
					items.add(plannedItems.get(i));
				}
			}
		}

		public void exchangeTwoItems(Integer indexA, Integer indexB) {
			Collections.swap(items, indexA, indexB);
			lastMove.updateItem(indexA, indexB);
		}
		public Integer getItemsQuantity() {
			return items.size();
		}

		public TabooListItem getLastMove() {
			return lastMove;
		}

		public void addItemToSolution(Item i) {
			this.items.add(i);
		}

		private Integer getKnifeChanges() {
			Integer knifeChanges = 0;
			for (Integer i=0;i<items.size()-1;i++) {
				if (itemsHaveDifferentLength(items.get(i), items.get(i+1)))
					knifeChanges++;
			}
			return knifeChanges;
		}

		private Boolean itemsHaveDifferentLength(Item a, Item b) {
			return Math.abs(a.getLength() - b.getLength()) > 0.05;
		}

		public Boolean itemsAtIndexesHaveDifferentLength(Integer a, Integer b) {
			if (a >= items.size() || b >= items.size())
				return false;
			return itemsHaveDifferentLength(items.get(a), items.get(b));
		}

		public QualityOfSolution quality(Double length, Double knifeWidth) {
			QualityOfSolution qos = new QualityOfSolution();
			List<StockBar> bars = distributeToBars(length, knifeWidth);
			Double usedLength = 0.0;

			for(StockBar b : bars)
				usedLength += b.getUsedLength();

			Double accordingToPlan = 0.0;
			for(int i=0; i<items.size(); i++) {
				Item item = items.get(i);
				accordingToPlan += item.getDaysToDeliveryDate() * ((items.size()-i));
			}

			qos.setLeftoversPercentage( 1 - (usedLength / (bars.size() * length)) );
			qos.setKnifeChanges(getKnifeChanges());
			qos.setAccordingToPlan(accordingToPlan);
			return qos;
		}


		private List<StockBar> distributeToBars(Double barLength, Double knifeWidth) {
			Boolean itemsNotDistributed = true;
			Integer itemId = 0;
			List<StockBar> bars = new ArrayList<StockBar>();

			StockBar bar = new StockBar(barLength, knifeWidth);
			while(itemsNotDistributed) {
				try {
					bar.addItemToStock(items.get(itemId));
					if (itemId == items.size()-1) {
						itemsNotDistributed = false;
					}
					itemId++;
				} catch (LongerThanStock e) {
					bars.add(bar);
					bar = new StockBar(barLength, knifeWidth);
				}
			}
			bars.add(bar);
			return bars;
		}
	}
}

