using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketplace
{
    class Menu
    {
        MenuElements elements = new MenuElements();
        bool breakFlag, breakFlag2;

        public void menu()
        {
            breakFlag = true;
            while (breakFlag)
            {
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Create an account");
                Console.WriteLine("0) Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (elements.LoginAccount())
                        {
                            if (elements.AccountInUse.UserType == "Buyer") //Buyer Menu
                            {
                                breakFlag2 = true;
                                while (breakFlag2)
                                {
                                    Console.WriteLine("1) Marketplace");
                                    Console.WriteLine("2) Show profile");
                                    Console.WriteLine("3) Add Balance");
                                    Console.WriteLine("4) Basket and checkout");
                                    Console.WriteLine("0) Logout");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            elements.MarketPlace();
                                            break;
                                        case "2":
                                            elements.AccountInUseBuyer.displayInfo();
                                            break;
                                        case "3":
                                            elements.AccountInUseBuyer.addBalance();
                                            break;
                                        case "4":
                                            elements.Basket();
                                            break;
                                        case "0":
                                            breakFlag2 = false;
                                            break;
                                    }
                                }
                            }
                            else if (elements.AccountInUse.UserType == "Seller") // Seller Menu
                            {
                                breakFlag2 = true;
                                while (breakFlag2)
                                {
                                    Console.WriteLine("1) Show profile");
                                    Console.WriteLine("2) Add or remove items from your shop");
                                    Console.WriteLine("3) See the items in your shop");
                                    Console.WriteLine("0) Logout");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            elements.AccountInUseSeller.displayInfo();
                                            break;
                                        case "2":
                                            elements.addRemoveItems();
                                            break;
                                        case "3":
                                            elements.AccountInUseSeller.showItemsInShop();
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
                        break;
                    case "2":
                        elements.CreateAccount();
                        break;
                    case "0":
                        breakFlag = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input: ");
                        break;
                }
            }
        }
    }
}
