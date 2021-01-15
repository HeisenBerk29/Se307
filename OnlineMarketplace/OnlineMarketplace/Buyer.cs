using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketplace
{
    public class Buyer : User
    {
        List<Item> basket = new List<Item>();
        private double totalBasketPrice;

        public List<Item> Basket
        {
            get { return basket; }
            set { basket = value; }
        }

        public Buyer(string UserID, string Location, string Name, string Password):base()
        {
            userID= UserID;
            location= Location;
            name = Name;
            password = Password;
            balance = 0;
            userType = "Buyer";
        }

        public double TotalBasketPrice
        {
            get { return totalBasketPrice; }
            set { totalBasketPrice = value; }
        }

        public void addBalance()
        {
            Console.WriteLine();
            Console.WriteLine("Current Balance: " + balance);
            Console.WriteLine("Enter the amount to deposit");
            balance += Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("New Balance: " + balance);
            Console.WriteLine();
        }

        public void displayBasket()
        {
            Console.WriteLine();
            Console.WriteLine("Items in the basket: ");
            for (int i = 0; i < basket.Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + basket[i].Name + " " + basket[i].Price + "TL");
                totalBasketPrice += basket[i].Price;
                Console.WriteLine();

            }
            Console.WriteLine("Total Price: " + totalBasketPrice + "TL");
        }

    }
}
