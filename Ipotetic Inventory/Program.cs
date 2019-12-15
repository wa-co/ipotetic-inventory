using System;

namespace Ipotetic_Inventory
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var inv = new Inventory(5000);

            var banana = new Item(1, ItemType.Food, 25, "Banana");

            var sword = new Item(2, ItemType.Tool, 250, "Sword");

            var notificater = new NotificationHandler();

            inv.ItemSold += notificater.OnItemSold;

            inv.Buy(banana, 3);
            inv.Sell(banana, 8);
            Console.WriteLine(inv.Money);

        }
    }
}
