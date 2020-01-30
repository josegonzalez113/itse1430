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

            Console.WriteLine("Sizes : SMALL = $2.50, MEDIUM = $3.50, LARGE = $4.50");
            string sizeOp = Console.ReadLine();
            SetSize(sizeOp);

            Console.WriteLine("Meats : BACON = $2, HAM = $1, PEPPERONI = $2, SAUSAGE = 1");
            string meatOp = Console.ReadLine();
            SetMeats(meatOp);

            Console.WriteLine("Vegetables : BLACK OLIVES = $1, MUSHROOMS = $1, ONIONS = $1, PEPPERS = $1");
            string vegeOp = Console.ReadLine();
            SetVegetables(vegeOp);

            Console.WriteLine("Sauce : TRADITIONAL = $0, GARLIC = $1, OREGANO = $2");
            string sauceOp = Console.ReadLine();
            SetSauce(sauceOp);

            Console.WriteLine("Cheese : REGULAR = $0, EXTRA = $1");
            string cheeseOp = Console.ReadLine();
            SetCheese(cheeseOp);

            Console.WriteLine("Delivery Option : TAKE OUT = $0, DELIVERY = $3");
            string deliveryOp = Console.ReadLine();
            SetDelivery(deliveryOp);

        }

        // set price depending on size of the pizza
        public static void SetSize ( string pick )
        {
            switch (pick.ToLower())
            {
                case "small":
                pick = "2.50"; break;

                case "medium":
                pick = "3.50"; break;

                case "large":
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
                pick = "2"; break;

                case "ham":
                pick = "1"; break;

                case "pepperoni":
                pick = "2"; break;

                case "sausage":
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
                pick = "1"; break;

                case "mushrooms":
                pick = "1"; break;

                case "onions":
                pick = "1"; break;

                case "peppers":
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
                pick = "0"; break;

                case "garlic":
                pick = "1"; break;

                case "oregano":
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
                pick = "0"; break;

                case "extra":
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
                pick = "0"; break;

                case "pickup":
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