using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketplace
{
    class MenuElements
    {
        private int userIdCounter = 200000;
        private bool breakFlag, breakFlag2, failmessage;
        private string shopName,name,location,tempPassword,password,ID;
        User user = new User();
        private User accountInUse;
        private Seller accountInUseSeller;
        private Buyer accountInUseBuyer;


        public User AccountInUse
        {
            get { return accountInUse; }
            set { accountInUse = value; }
        }

        public Seller AccountInUseSeller
        {
            get { return accountInUseSeller; }
            set { accountInUseSeller = value; }
        }

        public Buyer AccountInUseBuyer
        {
            get { return accountInUseBuyer; }
            set { accountInUseBuyer = value; }
        }

        public bool LoginAccount()
        {
            breakFlag = true;
            failmessage = true;
            while (breakFlag)
            {
                Console.WriteLine("1)Buyer Login");
                Console.WriteLine("2)Seller Login");
                Console.WriteLine("0)Go back");
                string login = Console.ReadLine();
                if (login == "0")
                    return false;

                Console.WriteLine("Enter your user ID: ");
                ID = Console.ReadLine();

                Console.WriteLine("Enter your password: ");
                password = Console.ReadLine();

                if (login == "1")
                {
                    for (int i = 0; i < user.BuyerList.Count; i++)
                    {
                        if (ID == user.BuyerList[i].UserID && password == user.BuyerList[i].Password)
                        {
                            accountInUseBuyer = user.BuyerList[i];
                            accountInUse = user.BuyerList[i];
                            Console.WriteLine("Login Successful!");
                            failmessage = false;
                            breakFlag = false;
                            return true;
                        }
                    }
                }

                else if (login == "2")
                {
                    for (int i = 0; i < user.SellerList.Count; i++)
                    {
                        if (ID == user.SellerList[i].UserID && password == user.SellerList[i].Password)
                        {
                            accountInUseSeller = user.SellerList[i];
                            accountInUse = user.SellerList[i];
                            Console.WriteLine("Login Successful!");
                            failmessage = false;
                            breakFlag = false;
                            return true;
                        }
                    }
                }
                if (failmessage)
                {
                    Console.WriteLine("Password or ID is wrong please try again");
                }
            }
            return true;
        }

        public void CreateAccount()
        {
            breakFlag2 = true;
            while (breakFlag2)
            {
                Console.WriteLine("1) Create a seller account.");
                Console.WriteLine("2) Create a buyer account.");
                Console.WriteLine("0) Go back.");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Enter your shop name or type 0 to go back");
                        shopName = Console.ReadLine();
                        if (shopName == "0")
                            break;

                        Console.WriteLine("Enter your name and surname");
                        name = Console.ReadLine();

                        Console.WriteLine("Enter your location");
                        location = Console.ReadLine();

                        breakFlag = true;

                        while (breakFlag)
                        {
                            Console.WriteLine("Set a password");
                            tempPassword = Console.ReadLine();

                            if (tempPassword.Length < 8)
                                Console.WriteLine("Password must be longer than 8 characters please try again");
                            else
                            {
                                password = tempPassword;
                                breakFlag = false;
                            }
                        }
                        ID = userIdCounter++.ToString();                        
                        user.SellerList.Add(new Seller(shopName, ID, location, name, password));
                        Console.WriteLine("Account has been created your user ID is: " + ID);
                        breakFlag2 = false;
                        break;

                    case "2":
                        Console.WriteLine("Enter your name and surname or type 0 to go back");
                        name = Console.ReadLine();
                        if (name == "0")
                            break;

                        Console.WriteLine("Enter your location");
                        location = Console.ReadLine();

                        breakFlag = true;
                        while (breakFlag)
                        {
                            Console.WriteLine("Set a password");
                            tempPassword = Console.ReadLine();

                            if (tempPassword.Length < 8)
                                Console.WriteLine("Password must be longer than 8 characters please try again");
                            else
                            {
                                password = tempPassword;
                                breakFlag = false;
                            }
                        }

                        breakFlag = true;

                        ID = userIdCounter++.ToString();
                        user.BuyerList.Add(new Buyer(ID, location, name, password));
                        Console.WriteLine("Account has been created your user ID is: " + ID);
                        breakFlag2 = false;
                        break;
                    case "0":
                        breakFlag2 = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input!");
                        break;
                }
            }
        }
    }
}
