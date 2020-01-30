// Jose Gonzalez 

using System;

namespace lab1_pizza
{
    class Program
    {

        /*public static int thePizza(double size, int meats, double vegetables, int sauces, int cheese, int delivery)
        { // parameters 
        }*/

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

            // user inputs
            string sizeOp;
            string meatOp;
            string vegeOp;
            string sauceOp;
            string cheeseOp;
            string deliveryOp;

            var title = "Build your pizza";
            char pad = ' ';
            Console.WriteLine(title.PadLeft(10, pad));

            Console.WriteLine("Sizes : SMALL = $2.50, MEDIUM = $3.50, LARGE = $4.50");
            sizeOp = Console.ReadLine();
            setSize(sizeOp);
            
            //Console.WriteLine(value);

            Console.WriteLine("Meats : BACON = $2, HAM = $1, PEPPERONI = $2, SAUSAGE = 1");
            meatOp = Console.ReadLine();

            Console.WriteLine("Vegetables : BLACK OLIVES = $.50, MUSHROOMS = $.55, ONIONS = $.60, PEPPERS = $.55");
            vegeOp = Console.ReadLine();

            Console.WriteLine("Sauce : TRADITIONAL = $0, GARLIC = $1, OREGANO = $1");
            sauceOp = Console.ReadLine();

            Console.WriteLine("Cheese : REGULAR = $0, EXTRA = $1");
            cheeseOp = Console.ReadLine();

            Console.WriteLine("Delivery Option : TAKE OUT = $0, DELIVERY = $3");
            deliveryOp = Console.ReadLine();

        }

        // set price depending on size
        public static void setSize ( string pick )
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
            Int32.TryParse(pick, out var value);

            Console.WriteLine(value + pick);
        }

        // set price depending on meat pick
        public static void setMeats ( string pick )
        {
            switch (pick.ToLower())
            {
                case "BACON":
                pick = "2"; break;

                case "HAM":
                pick = "1"; break;

                case "PEPPERONI":
                pick = "2"; break;

                case "SAUSAGE":
                pick = "1"; break;

            }
            Console.WriteLine(pick);
        }

        public static void addPrices ()
        {
                
        }


        static void Main(string[] args)
        {
            mainMenu();
        }

    }
}