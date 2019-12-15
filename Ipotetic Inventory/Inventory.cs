using System;
using System.Collections.Generic;

namespace Ipotetic_Inventory
{
public class ItemEventArgs : EventArgs
    {
        public Item Item { get; set; }
        public int Amount { get; set; }

    }
public class Inventory
    {
        public decimal Money { get; private set; }
        public Dictionary<Item, int> Items { get; } = new Dictionary<Item, int>();

        public delegate void ItemSoldEventHandler(object source, ItemEventArgs args);

        public event ItemSoldEventHandler ItemSold;
        protected virtual void OnItemSold(Item item, int amount) => ItemSold?.Invoke(this, new ItemEventArgs() { Item = item, Amount = amount });
        public Inventory(decimal money)
        {
            Money = money;
        }


        public void AddItem(Item item, int amount = 1) 
    { 
                if (Items.ContainsKey(item)) 
                {
                        Items[item] += amount;
                }
                else
                {
                        Items.Add(item, amount);
                }
    }

        public void Sell(ISellable toSell, int amount = 1)
        {

                decimal money = toSell.Price
                * amount;
            Money += money;
            if (toSell is Item item)
            {
                if (Items.ContainsKey(item))
                {
                    if (amount > Items[item])
                    {
                        throw new Exception("Not enough " + nameof(item).ToString());
                    }
                    Items[item] -= amount;
                }
                else
                {
                    throw new Exception("You don't have this item");
                }

                OnItemSold(item, amount);
            }
        }

    public void Buy(ISellable item, int amount = 1) 
    {
            decimal cost = item.Price
                           * amount;
            if (cost > Money) {
                throw new Exception("Not enough money");
            }
            Money -= cost;
            if (item is Item ndItem)
            {
                if (!Items.TryAdd(ndItem, amount))
                {
                    Items[ndItem] += amount;
                }

            }
        }

  };
  
}
