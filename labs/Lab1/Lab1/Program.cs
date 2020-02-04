// Jose Gonzalez 

using System;

namespace lab1_pizza
{
    class Program
    {
        enum Command
        {
            NewOrder = 0,
            EditOrder = 1,
            ViewExisting = 2,
            Quit = 3,
            BackToMain = 4,
        }

        static void Main ( string[] args )
        {
            var appRunning = true;

            do
            {
                switch (MainMenu())
                {
                    case Command.NewOrder: BuildPizzaMenu(); break;
                    case Command.EditOrder: BuildPizzaMenu(); break;
                    //case Command.ViewExisting: OrderReceipt(); break;
                    case Command.Quit: appRunning = false; break;
                    case Command.BackToMain: MainMenu(); break;
                };
            } while (appRunning != false);
        }

        private static Command MainMenu ()
        {
            do
            {
                // Header
                Console.WriteLine("       Main Menu");
                Console.WriteLine("0.) Create new order");
                Console.WriteLine("1.) Modify Existing Order");
                Console.WriteLine("2.) View Existing Order");
                Console.WriteLine("3.) Quit program");
                Console.Write("Select an option to proceed: ");
                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "0": return Command.NewOrder;
                    case "1": return Command.EditOrder;
                    case "2": return Command.ViewExisting;
                    case "3": return Command.Quit;

                    default: Console.WriteLine("Invalid Input"); break;

                }
            } while (true);
        }

        private static Command BuildPizzaMenu ()
        {
            do
            {
                // Header
                Console.WriteLine("         Build your pizza");

                // Size
                Console.WriteLine("Sizes : S)mall = $2 | M)edium = $3 | L)arge = $4");
                string sizeOp = Console.ReadLine();
                var currentPrice = SetSize(sizeOp);

                // Meats
                Console.WriteLine("Meats : B)acon = $1 | P)epperoni = $2");
                string meatOp = Console.ReadLine();
                var currentPrice2 = SetMeats(meatOp);

                // Vegetables
                Console.WriteLine("Vegetables : O)nions = $1 | P)eppers = $2");
                string vegeOp = Console.ReadLine();
                var currentPrice3 = SetVegetables(vegeOp);

                // Sauce
                Console.WriteLine("Sauce : T)raditional = $1 | G)arlic = $2 | O)regano = $3");
                string sauceOp = Console.ReadLine();
                var currentPrice4 = SetSauce(sauceOp);

                // Cheese
                Console.WriteLine("Cheese : R)egular = $0 | E)xtra = $1");
                string cheeseOp = Console.ReadLine();
                var currentPrice5 = SetCheese(cheeseOp);

                // Delivery option
                Console.WriteLine("Delivery Option : T)ake Out = $0 | D)elivery = $2");
                string deliveryOp = Console.ReadLine();
                var currentPrice6 = SetDelivery(deliveryOp);

                // calculate total
                var final = FinalPrice(currentPrice, currentPrice2, currentPrice3, currentPrice4, currentPrice5, currentPrice6);
                Console.WriteLine("Final price: $" + final);

                // back to main menu
                Console.Write("Enter any key to return to the main menu: ");
                var selection = Console.ReadLine();

                switch (selection)
                {
                    default: return Command.BackToMain;
                }
            } while (true);
        }

        // view existing order
        public static void OrderReceipt ( int size, int meats, int vegies, int sauces, int cheese, int delivery, int price )
        {
            switch (size)
            {
                case 2: Console.WriteLine("Small size"); break;
                case 3: Console.WriteLine("Medium size"); break;
                case 4: Console.WriteLine("Large size"); break;
            }
            switch (meats)
            {
                case 1: Console.WriteLine("Bacon added"); break;
                case 2: Console.WriteLine("Pepperoni added "); break;
            }
            switch (vegies)
            {
                case 1: Console.WriteLine("Peppers added"); break;
                case 2: Console.WriteLine("Onions added"); break;
            }
            switch (sauces)
            {
                case 0: Console.WriteLine("Traditional sauce"); break;
                case 1: Console.WriteLine("Garlic sauce"); break;
                case 2: Console.WriteLine("Oregano sauce"); break;
            }
            switch (cheese)
            {
                case 0: Console.WriteLine("Regular cheese"); break;
                case 1: Console.WriteLine("Extra cheese"); break;
            }
            switch (delivery)
            {
                case 0: Console.WriteLine("TakeOut"); break;
                case 2: Console.WriteLine("Deliver"); break;
            }

            Console.WriteLine("-----------");
            Console.WriteLine(price);

        }

        //adds up the final price for the customer
        public static int FinalPrice (int size, int meat, int vegie, int sauce, int cheese, int delivery)
        {
            int finalPizzaPrice = size + meat + vegie + sauce + cheese + delivery;
            return finalPizzaPrice;
        }

        // sets price depending on size of the pizza
        public static int SetSize ( string pick )
        {
            switch (pick.ToLower())
            {
                case "small":
                case "s":
                pick = "2"; break;

                case "medium":
                case "m":
                pick = "3"; break;

                case "large":
                case "l":
                pick = "4"; break;
            }

            /* convert the string into an actual value so that-
            prices of the toppings can be added all together*/

            var temp = Int32.TryParse(pick, out var price);
            //Console.WriteLine(price);
            return price;
        }

        // sets price depending on the meats added to pizza
        public static int SetMeats ( string pick )
        {
            switch (pick.ToLower())
            {
                case "bacon":
                case "b":
                pick = "1"; break;

                case "pepperoni":
                case "p":
                pick = "2"; break;
            }

            var temp = Int32.TryParse(pick, out var price);
            //Console.WriteLine(price);
            return price;
        }

        // sets price depending on the vegetable added to pizza
        public static int SetVegetables ( string pick )
        {
            switch (pick.ToLower())
            {
                case "onions":
                case "o":
                pick = "1"; break;

                case "peppers":
                case "p":
                pick = "2"; break;
            }
            var temp = Int32.TryParse(pick, out var price);
            //Console.WriteLine(price);
            return price;
        }

        // sets price depending on the sauce added to pizza
        public static int SetSauce ( string pick )
        {
            switch (pick.ToLower())
            {
                case "traditional":
                case "t":
                pick = "0"; break;

                case "garlic":
                case "g":
                pick = "1"; break;

                case "oregano":
                case "o":
                pick = "2"; break;

            }

            var temp = Int32.TryParse(pick, out var price);
            //Console.WriteLine(price);
            return price;
        }

        // sets price depending on the amount of cheese added to pizza
        public static int SetCheese ( string pick )
        {
            switch (pick.ToLower())
            {
                case "regular":
                case "r":
                pick = "0"; break;

                case "extra":
                case "e":
                pick = "1"; break;

            }

            var temp = Int32.TryParse(pick, out var price);
            //Console.WriteLine(price);
            return price;
        }

        // sets price for delivery
        public static int SetDelivery ( string pick )
        {
            switch (pick.ToLower())
            {
                case "take out":
                case "t":
                pick = "0"; break;

                case "delivery":
                case "d":
                pick = "2"; break;

            }

            var temp = Int32.TryParse(pick, out var price);
            //Console.WriteLine(price);
            return price;
        }
    }
}