using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50
            var numbers = new int[50];

            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(numbers); //Populater was a method created down further in this assignment.. just fyi

            //Print the first number of the array
            Console.WriteLine($"{numbers[0]}");

            //Print the last number of the array --
            Console.WriteLine($"{numbers[numbers.Length-1]}"); //numbers.Length you can use instead of 49 if you don't know how long it is, but make sure to do -1
                                                               //because it would see length which is 50 and not the index 49 
            Console.WriteLine("All Numbers Original");
            //Use this method to print out your numbers from arrays or lists
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*     Hint: Array._____(); Create a custom method     */

            Console.WriteLine("All Numbers Reversed:");

            Console.WriteLine("---------REVERSE CUSTOM------------");
            
            ReverseArray(numbers); //doing this means it will now start with the number in index 49 and last number is what is in index 0

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");

            ThreeKiller(numbers);

            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");

            Array.Sort(numbers); //so.. there was no method below for sorting array so we can actually just do it here
            NumberPrinter(numbers); //I tried Console.WriteLine($"{numbers}"); and it did not work.. why?

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            
            
            
            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List
            var numList = new List<int>();

            //Print the capacity of the list to the console
            Console.WriteLine($"{numList.Count}"); //should I do count or capacity?

            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(numList);

            //Print the new capacity
            Console.WriteLine($"{numList.Capacity}"); //adds 64 at the end of the list since I guess that is the capacity - does this default?
                                                         //maybe add that it is a New Capacity..
            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            //Console.WriteLine("What number will you search for in the number list?"); //move into do scope

            int userInput;
            bool aNumber;

            do
            {
                Console.WriteLine("What number will you search for in the number list?");
                aNumber = int.TryParse(Console.ReadLine(), out userInput);
            } while (aNumber == false);

            NumberChecker(numList, userInput);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list
            NumberPrinter(numList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(numList);

            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            numList.Sort();
            NumberPrinter(numList);

            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable
            var myArray = numList.ToArray();

            //Clear the list
            numList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++) //is there an easier way to do this?
            {
                if(numbers[i] % 3 == 0) //I'm also confused here as to why it is modulus 3.. does this mean divisible by 3?
                {
                    numbers[i] = 0;
                }
            }
            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            for(int i = numberList.Count-1; i >= 0; i--)
            {
                if(numberList[i] % 2 != 0)
                {
                    numberList.RemoveAt(i); //why is remove not working for me?
                }
            }
            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine($"Yes");
            }
            else
            {
                Console.WriteLine($"No");
            }
        }

        private static void Populater(List<int> numberList)
        {
            while (numberList.Count < 51) //didn't want to do a while loop, but this appears to be the best way? should maybe ask why
            {
                Random rng = new Random();
                var number = rng.Next(0, 50);
                numberList.Add(number);
            }
            NumberPrinter(numberList);

            //for (int j = 0; j < numberList.Count; j++) //I really don't know how to implement the for loop in this..
            //{
            //    Random rng = new Random();
            //    numberList[j] = rng.Next(0, 50);
            //    numberList.Add(j);
            //}
            //NumberPrinter(numberList);
        }

        private static void Populater(int[] numbers)
        {
            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            
            for(int i = 0; i < numbers.Length; i++)
            {
                Random rng = new Random();
                numbers[i] = rng.Next(0, 50);
            }

        }        

        private static void ReverseArray(int[] array)
        {
            Array.Reverse(array);
            NumberPrinter(array);
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
