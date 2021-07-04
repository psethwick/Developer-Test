using System;

namespace coinshop.core
{
    public class Item : IEquatable<Item>
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
        
        // for now an Item is the same if the name is the same
        // in the future I would migrate to unique item IDs
        public bool Equals(Item other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}