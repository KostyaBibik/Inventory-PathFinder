using System;
using UnityEngine;

namespace TraderScene.Models.Inventory
{
    public class ItemModel
    {
        public string Name { get; }
        public Sprite Icon { get; }
        public int Price { get; private set; }

        public ItemModel(string name, int price, Sprite icon)
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
        }
        
        public void UpdatePrice(int newAmount)
            => Price = Mathf.Clamp(newAmount, 0, newAmount);
    }
}