using System;

namespace Ipotetic_Inventory
{
    public class NotificationHandler
    {
        public void OnItemSold(object source, ItemEventArgs args)
        {
            Console.WriteLine("LOG: {0} {1} has been sold at price {2}", args.Amount, args.Item.Type, args.Item.Price *args.Amount);
        }
    }
}
