using System;
using UnityEngine;

namespace TraderScene.Models.Inventory
{
    public class ItemModel
    {
        public string Name { get; }
        public int Price { get; }
        public Sprite Icon { get; }
        
        public int Count { get; private set; }

        public ItemModel(string name, int price, Sprite icon, int count = 1)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            }
            
            Name = name;
            Price = price;
            Icon = icon;
            Count = count;
        }
        
        public void UpdateCount(int delta)
        {
            var newCount = Count + delta;
            if (newCount < 0)
            {
                throw new InvalidOperationException("Count cannot be negative.");
            }
            
            Count = newCount;
        }
    }
}