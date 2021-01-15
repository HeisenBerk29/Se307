using System;
using System.Collections.Generic;
using System.Text;

namespace SE307Project
{
    public class Item
    {
        private string name;
        private double weight;
        private double price;
        private string sellerID;
        private string description;
        private string category;
        private string itemID;       
        List<Item> itemList = new List<Item>();

        public Item(string name, double weight, double price, string sellerID, string description, string category,string itemID)
        {
            this.name = name;
            this.weight = weight;
            this.price = price;
            this.sellerID = sellerID;
            this.description = description;
            this.category = category;
            this.itemID = itemID;           
        }

        public Item() { }
        
        public List<Item> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string SellerID
        {
            get { return sellerID; }
            set { sellerID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public void showItemInfo()
        {
            Console.WriteLine("Name: "+name);
            Console.WriteLine("Price: "+price);
            Console.WriteLine("Category: "+category);
            Console.WriteLine("Weight: "+weight);
            Console.WriteLine("Item ID: "+itemID);
            Console.WriteLine("Seller ID: "+sellerID);
            Console.WriteLine("Description: "+description);
        }
    }
}
