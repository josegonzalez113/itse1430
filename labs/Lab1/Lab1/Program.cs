// Jose Gonzalez 

using System;

namespace lab1_pizza
{
    class Program
    {

        enum Command
        {
            NewOrder = 0,
            ExistingOrder = 1,
            Quit = 2,
            Invalid = 3,
        }

        private static Command MainMenu ()
        {
            do
            {
                // Header
                Console.WriteLine("       Main Menu");
                Console.WriteLine("0.) Create new order");
                Console.WriteLine("1.) Modify Existing Order");
                Console.WriteLine("2.) Quit program");
                Console.Write("Select an option to proceed: ");
                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "0": return Command.NewOrder; break;
                    case "1": return Command.ExistingOrder; break;
                    case "2": return Command.Quit; break;
                    case "3": return Command.Invalid; break;

                }
            } while (!false);
        }

        public static void BuildPizzaMenu ()
        {

            // Header
            var title = "Build your pizza";
            char pad = ' ';
            Console.WriteLine(title.PadLeft(10, pad));

            // Size
            Console.WriteLine("Sizes : S)mall = $2 | M)edium = $3 | L)arge = $4");
            string sizeOp = Console.ReadLine();
            var currentPrice = SetSize(sizeOp);
            Console.WriteLine(currentPrice);

            // Meats
            Console.WriteLine("Meats : B)acon = $2 | H)am = $1 | P)epperoni = $2  S)ausage = 1");
            string meatOp = Console.ReadLine();
            var currentPrice2 = SetMeats(meatOp);
            Console.WriteLine(currentPrice2);

            // Vegetables
            Console.WriteLine("Vegetables : B)lack Olives = $1 | M)ushrooms = $1 | O)nions = $1 | P)eppers = $1");
            string vegeOp = Console.ReadLine();
            var currentPrice3 = SetVegetables(vegeOp);
            Console.WriteLine(currentPrice3);

            // Sauce
            Console.WriteLine("Sauce : T)raditional = $0 | G)arlic = $1 | O)regano = $2");
            string sauceOp = Console.ReadLine();
            var currentPrice4 = SetSauce(sauceOp);
            Console.WriteLine(currentPrice4);

            // Cheese
            Console.WriteLine("Cheese : R)egular = $0 | E)xtra = $1");
            string cheeseOp = Console.ReadLine();
            var currentPrice5 = SetCheese(cheeseOp);
            Console.WriteLine(currentPrice5);

            // Delivery option
            Console.WriteLine("Delivery Option : T)ake Out = $0 | D)elivery = $3");
            string deliveryOp = Console.ReadLine();
            var currentPrice6 = SetDelivery(deliveryOp);
            Console.WriteLine(currentPrice6);

            var final = FinalPrice(currentPrice, currentPrice2, currentPrice3, currentPrice4, currentPrice5, currentPrice6);
            Console.WriteLine(final);

        }

        //adds up the final price for the customer
        public static int FinalPrice (int p1, int p2, int p3, int p4, int p5, int p6)
        {
            int finalPizzaPrice = p1 + p2 + p3 + p4 + p5 + p6;
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
                pick = "2"; break;

                case "ham":
                case "h":
                pick = "1"; break;

                case "pepperoni":
                case "p":
                pick = "2"; break;

                case "sausage":
                case "s":
                pick = "1"; break;

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
                case "black olives":
                case "b":
                //pick = "1"; break;

                case "mushrooms":
                case "m":
                //pick = "1"; break;

                case "onions":
                case "o":
                //pick = "1"; break;

                case "peppers":
                case "p":
                pick = "1"; break;

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
                pick = "3"; break;

            }

            var temp = Int32.TryParse(pick, out var price);
            //Console.WriteLine(price);
            return price;
        }

        static void Main ( string[] args )
        {
            MainMenu();
            BuildPizzaMenu();
        }
    }
}