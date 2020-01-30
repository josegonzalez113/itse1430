// Jose Gonzalez 

using System;

namespace lab1_pizza
{
    class Program
    {

        // commands will be used for-
        // adding and removing from pizza
        enum Command
        {
            Add = 0,
            Remove = 1,
            Checkout = 2,
            Quit = 3
        }   

        public static void mainMenu()
        {

            var title = "Build your pizza";
            char pad = ' ';
            Console.WriteLine(title.PadLeft(10, pad));

            Console.WriteLine("Sizes : S)mall = $2.50 | M)edium = $3.50 | L)arge = $4.50");
            string sizeOp = Console.ReadLine();
            SetSize(sizeOp);

            Console.WriteLine("Meats : B)acon = $2 | HAM = $1 | P)epperoni = $2  S)ausage = 1");
            string meatOp = Console.ReadLine();
            SetMeats(meatOp);

            Console.WriteLine("Vegetables : B)lack Olives = $1 | M)ushrooms = $1 | O)nions = $1 | P)eppers = $1");
            string vegeOp = Console.ReadLine();
            SetVegetables(vegeOp);

            Console.WriteLine("Sauce : T)raditional = $0 | G)arlic = $1 | O)regano = $2");
            string sauceOp = Console.ReadLine();
            SetSauce(sauceOp);

            Console.WriteLine("Cheese : R)egular = $0 | E)xtra = $1");
            string cheeseOp = Console.ReadLine();
            SetCheese(cheeseOp);

            Console.WriteLine("Delivery Option : T)ake Out = $0 | D)elivery = $3");
            string deliveryOp = Console.ReadLine();
            SetDelivery(deliveryOp);

        }

        // set price depending on size of the pizza
        public static void SetSize ( string pick )
        {
                switch (pick.ToLower())
                {
                    case "small":
                    case "s":
                    pick = "2.50"; break;

                    case "medium":
                    case "m":
                    pick = "3.50"; break;

                    case "large":
                    case "l":
                    pick = "4.50"; break;
                }

            Console.WriteLine(pick);

            // convert the string into actual value
            // Int32.TryParse(pick, out var value);
            // Console.WriteLine(value + pick);
        }

        // set price depending on the meats added to pizza
        public static void SetMeats ( string pick )
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
            Console.WriteLine(pick);
        }

        // set price depending on the vegetable added to pizza
        public static void SetVegetables ( string pick )
        {
            switch (pick.ToLower())
            {
                case "black olives":
                case "b":
                pick = "1"; break;

                case "mushrooms":
                case "m":
                pick = "1"; break;

                case "onions":
                case "o":
                pick = "1"; break;

                case "peppers":
                case "p":
                pick = "1"; break;

            }
            Console.WriteLine(pick);
        }

        // set price depending on the sauce added to pizza
        public static void SetSauce ( string pick )
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

            Console.WriteLine(pick);
        }

        // set price depending on the amount of cheese added to pizza
        public static void SetCheese ( string pick )
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

            Console.WriteLine(pick);
        }

        // set price for delivery
        public static void SetDelivery ( string pick )
        {
            switch (pick.ToLower())
            {
                case "take out":
                case "t":
                pick = "0"; break;

                case "pickup":
                case "p":
                pick = "1"; break;

            }

            Console.WriteLine(pick);
        }




        static void Main(string[] args)
        {
            mainMenu();
        }

    }
}

// how to push online

//version control->Review Solution and Commit-> Write a comment
//commint all and push

//version control->push changes