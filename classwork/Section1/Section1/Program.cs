/*
 * ITSE 1430
 * Your name
 */

using System;

namespace Section1
{
    class Program
    {
        static void Main ( string[] args )
        {
            //PlayingWithVariables();
            AddMovie();

        }

        static void AddMovie ()
        {
            string title = ReadString("Enter a tile: ", true);

            int releaseYear = ReadInt32("Enter release year (>=0): ", 0, 2100);

            int runLength = ReadInt32("Enter the run length (>=0): ", 0, 86400);

            string description = ReadString("Enter a decription: ", true);

            bool isClassic = readBoolean("Is this a classic movie? ");
        }

        private static bool readBoolean ( string message )
        {
            Console.Write(message + "(Y/N)");
            string value = Console.ReadLine();

            //TODO: Do this correctly
            char firstChar = value[0];
            return firstChar == 'Y';
        }

        private static string ReadString ( string message, bool required )
        {
            Console.Write(message);
            string value = Console.ReadLine();

            //TODO: Validate
            return value;
        }

        private static int ReadInt32 (string message, int minvalue, int maxValue)
        {
            Console.Write(message);
            string temp = Console.ReadLine();
            //int value = Int32.Parse(temp);

            //TODO: Clean this up
            int value;
            if (Int32.TryParse(temp, out value))
                return value;

            //TODO: Validate input
            return -1;
        }

        private static void PlayingWithVariables ()
        {
            Console.WriteLine("Hello World!");

            int hours;
            double payRate;

            {
                string name;
                bool pass;
            }

            {
                int name = 10;
            }

            //Not cased properly
            //string FirstName;

            //hours = 10;
            //int newHours = hours;

            //Logical block 1     
            int hours2 = 10;
            //int hours3;
            //hours3 = 3;

            int x, y, z;
            int a = 10, b = 20, c = 30;

            //Display a message
            Console.WriteLine("Enter a value");
            string input = Console.ReadLine();
        }
    }
}
