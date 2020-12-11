using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketplace
{
    public class User
    {
        protected string userID;
        protected string location;
        protected string name;
        protected string password;
        protected double balance;
        protected string userType;
        
        List<User> userList = new List<User>();
        List<Buyer> buyerList = new List<Buyer>();
        List<Seller> sellerList = new List<Seller>();
        

        public List<User> UserList
        {
            get { return userList; }
            set { userList = value; }
        }

        public List<Buyer> BuyerList
        {
            get { return buyerList; }
            set { buyerList = value; }
        }

        public List<Seller> SellerList
        {
            get { return sellerList; }
            set { sellerList = value; }
        }


        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public virtual void displayInfo()
        {
            Console.WriteLine("Showing Profile....");
            Console.WriteLine("User ID:" + userID);
            Console.WriteLine("Name Surname: " + name);
            Console.WriteLine("Location: " + location);
            Console.WriteLine("Account balance: " + balance+"TL");
        }


    }
}
