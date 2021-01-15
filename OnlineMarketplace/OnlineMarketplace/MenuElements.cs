using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketplace
{
    class MenuElements
    {
        private int userIdCounter = 200000;
        private bool breakFlag, breakFlag2, failmessage;
        private int itemId = 0001;
        private double price, weight;
        private string shopName,name,location,tempPassword,password,ID,input,description,category,deleteID;
        User user = new User();
        Item item = new Item();
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
        public void addRemoveItems()
        {
            breakFlag2 = true;
            while (breakFlag2)
            {
                Console.WriteLine("1) Add product");
                Console.WriteLine("2) Remove product");
                Console.WriteLine("0) Go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        breakFlag = true;
                        while (breakFlag)
                        {
                            Console.WriteLine("Select the category of the item that you want to add");
                            Console.WriteLine("1) Electronics");
                            Console.WriteLine("2) Clothing");
                            Console.WriteLine("3) Personal Care");
                            Console.WriteLine("0) Go back");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    category = "Electronics";
                                    break;
                                case "2":
                                    category = "Clothing";
                                    break;
                                case "3":
                                    category = "Personal Care";
                                    break;
                                case "0":
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid input");
                                    break;
                            }
                            if (input == "0")
                                break;
                            Console.WriteLine("Enter product name");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter product price");
                            price = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter product weight");
                            weight = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter description");
                            description = Console.ReadLine();
                            Item addedItem = new Item(name, weight, price, accountInUseSeller.UserID, description, category, Convert.ToString(itemId));
                            itemId++;
                            item.ItemList.Add(addedItem);
                            accountInUseSeller.ItemsInShop.Add(addedItem);
                            Console.WriteLine("Product has been added to the marketplace successfully!");
                        }
                        break;
                    case "2":
                        breakFlag = true;
                        while (breakFlag)
                        {
                            if (accountInUseSeller.ItemsInShop.Count == 0)
                            {
                                Console.WriteLine("You dont have any products on the marketplace");
                                break;
                            }
                            Console.WriteLine("1) Remove from the list");
                            Console.WriteLine("2) Remove with name");
                            Console.WriteLine("0) Go back");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    int i;
                                    for (i = 0; i < accountInUseSeller.ItemsInShop.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + ") " + accountInUseSeller.ItemsInShop[i].Name);
                                    }

                                    int delete = Convert.ToInt32(Console.ReadLine());
                                    deleteID = accountInUseSeller.ItemsInShop[delete - 1].ItemID;
                                    accountInUseSeller.ItemsInShop.RemoveAt(delete - 1);
                                    for (i = 0; i < item.ItemList.Count; i++)
                                        if (deleteID == item.ItemList[i].ItemID)
                                            item.ItemList.RemoveAt(i);
                                    Console.WriteLine("Product removed successfully");
                                    break;

                                case "2":
                                    Console.WriteLine("Enter the name of the product to be removed");
                                    name = Console.ReadLine();
                                    for (i = 0; i < accountInUseSeller.ItemsInShop.Count; i++)
                                        if (accountInUseSeller.ItemsInShop[i].Name == name)
                                        {
                                            deleteID = accountInUseSeller.ItemsInShop[i].ItemID;
                                            accountInUseSeller.ItemsInShop.RemoveAt(i);
                                        }
                                    for (i = 0; i < item.ItemList.Count; i++)
                                        if (deleteID == item.ItemList[i].ItemID)
                                        {
                                            Console.WriteLine(item.ItemList[i].Name + " has been removed successfully");
                                            item.ItemList.RemoveAt(i);
                                        }
                                    break;
                                case "0":
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid input");
                                    break;
                            }
                            breakFlag = false;
                        }
                        break;
                    case "0":
                        breakFlag2 = false;
                        break;
                    default:
                        break;
                }

            }

        }
        public void MarketPlace()
        {
            breakFlag = true;
            while (breakFlag)
            {
                Console.WriteLine("1) Show all items for sale");
                Console.WriteLine("0) Go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        breakFlag2 = true;
                        while (breakFlag2)
                        {
                            Console.WriteLine("Select the item to see its info");
                            Console.WriteLine("Press 0 to go back");
                            for (int i = 0; i < item.ItemList.Count; i++)
                            {
                                Console.WriteLine(i + 1 + ") " + item.ItemList[i].Name);
                            }
                            int itemSelect = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (itemSelect == -1)
                            {
                                breakFlag2 = false;
                            }
                            else
                            {
                                item.ItemList[itemSelect].showItemInfo();
                                Console.WriteLine("1) Add to basket ");
                                Console.WriteLine("0) Go back");
                                int input = Convert.ToInt32(Console.ReadLine());
                                if (input == 1)
                                {
                                    accountInUseBuyer.Basket.Add(item.ItemList[itemSelect]);
                                    Console.WriteLine("Item has been added to the basket");
                                }
                            }
                        }
                        break;

                    case "0":
                        breakFlag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input! Try again.");
                        break;
                }
            }
        }

        public void Basket()
        {
            breakFlag = true;
            while (breakFlag)
            {
                Console.WriteLine("1) Your basket");
                Console.WriteLine("2) Checkout");
                Console.WriteLine("0) Go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        accountInUseBuyer.displayBasket();
                        break;
                    case "2":
                        if (accountInUseBuyer.Balance >= accountInUseBuyer.TotalBasketPrice)
                        {
                            for (int i = 0; i < accountInUseBuyer.Basket.Count; i++)
                            {
                                for (int j = 0; j < user.SellerList.Count; j++)
                                {
                                    if (accountInUseBuyer.Basket[i].SellerID == user.SellerList[j].UserID)
                                    {
                                        double price = accountInUseBuyer.Basket[i].Price;
                                        accountInUseBuyer.Balance -= price;
                                        user.SellerList[j].Balance += price;
                                    }
                                }
                            }
                            Console.WriteLine("Checkout Complete! Have a nice day.");
                        }
                        else
                            Console.WriteLine("Insufficient balance! Please add money to your account and try again");
                        break;
                    case "0":
                        breakFlag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input! Try again.");
                        break;
                }
            }
        }


    }
}
