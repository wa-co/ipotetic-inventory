using System;

namespace Ipotetic_Inventory
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var inv = new Inventory(5000);
            var banana = new Item(1, ItemType.Food, 25);
            var sword = new Item(2, ItemType.Tool, 250);

            inv.Buy(banana);
            Console.WriteLine(inv.GetMoney());

        }
    }
}
