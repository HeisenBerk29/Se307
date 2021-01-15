using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketplace
{
    class Seller : User
    {        
        protected string shopName;

        List<Item> itemsInShop = new List<Item>();
              
        public Seller(string shopName,string UserID,string Location,string Name,string Password):base()
        {            
            this.shopName = shopName;
            userID = UserID;
            location = Location;
            name = Name;
            password = Password;
            Balance = 0;
            userType = "Seller";
        }

        public List<Item> ItemsInShop
        {
            get { return itemsInShop; }
            set { itemsInShop = value; }
        }

        public string ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }

        public override void displayInfo()
        {
            Console.WriteLine("Showing Profile....");
            Console.WriteLine("Shop Name: "+shopName);
            Console.WriteLine("User ID:" + userID);
            Console.WriteLine("Name Surname: " + name);
            Console.WriteLine("Location: " + location);
            Console.WriteLine("Account balance: " + balance+"TL");
        }

        public void showItemsInShop()
        {
            for (int i = 0; i < itemsInShop.Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + itemsInShop[i].Name);
            }
        }




    }
}
