// Jose Gonzalez 

using System;

namespace lab1_pizza
{
    class Program
    {

        /*public static int thePizza(double size, int meats, double vegetables, int sauces, int cheese, int delivery)
        { // parameters 
        }*/

        public static void mainMenu()
        {

            // user inputs
            string sizeOp;
            string meatOp;
            string vegeOp;
            string sauceOp;
            string cheeseOp;
            string deliveryOp;

            Console.WriteLine("              Build your pizza");

            Console.WriteLine("Sizes : SMALL = $2.50, MEDIUM = $3.50, LARGE = $4.50");
            sizeOp = Console.ReadLine();

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

        public static void setName (string name)
        {
            var customer = name;
            Console.WriteLine(name);
        }

        static void Main(string[] args)
        {
            mainMenu();
        }

    }
}