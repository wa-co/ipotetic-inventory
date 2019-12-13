using System;
using System.Collections.Generic;

namespace Ipotetic_Inventory
{

public class Inventory
    {
        private decimal Money { get; set; }
        public Dictionary<Item, int> Items { get; } = new Dictionary<Item, int>();

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
                    Items[item] -= amount;
                }
                else
                {
                    throw new Exception("You don't have this item");
                }
            }
        }
    public decimal GetMoney() 
    {
            return Money;
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
                if (!(Items.ContainsKey(ndItem))) 
                {
                    Items.Add(ndItem, 1);
                }

                if (Items[ndItem] >= 1)
                {
                    Items[ndItem] += amount;
                }

            }
        }

  };
  
}
