using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketplace
{
    public class Buyer : User
    {
        List<Item> basket = new List<Item>();

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
        
    }
}
