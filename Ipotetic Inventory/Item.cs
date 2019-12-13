using System;
using System.Diagnostics.CodeAnalysis;

namespace Ipotetic_Inventory
{
public struct Item : IEquatable<Item>, ISellable
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public decimal Price { get; set; }

        public Item(int id, ItemType type, decimal price)
        {
            Id = id;
            Type = type;
            Price = price;
        }
        public override bool Equals(object b)
        {
            if (!(b is Item)) { return false; }
            else
            {
                return this.Equals((Item)b);
            }
        }

        public bool Equals(Item other)
        {
            return this.Id == other.Id;
        }

        public static bool operator ==(Item left, Item right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Item left, Item right)
        {
            return !(left == right);
        }
    }

}
