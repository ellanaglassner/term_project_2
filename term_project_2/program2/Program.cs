// Ellana Glassner
// .NET 8.0.201

// Tells the compiler to include the "System" namespace in the current file's scope.
using System;

// Tells the compiler to include the "System.Collections.Generic" namespace in the current file's scope.
using System.Collections.Generic;                                                                               // Provides collection of generic data structures and algorithms for better type safety and performace.                                                                                   // Provides set of standard query operators that allow for querying data.

// Tell the compiler to include the "System.Linq" or Language Integrated Query namespace in the current file's scope.
using System.Linq;                                                                                              // Provides standard query operators that allow for querying data.

// Defines a namespace called number_organizer to organize and encapsulate all related code.
namespace number_organizer
{

    // Declares Program class for intended user interaction
    class Program
    {
        
        // Declares main method of the program, belongs to the class, returns nothing
        static void Main()
        {
            Console.Write("Enter a list of numbers separated by spaces: ");
            string input = Console.ReadLine();
            string[] string_numbers = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);           // Establishes an array of numbers from the user input split by each space and with empty entries removed.
            List<int> numbers = new List<int>();                                                                // Establishes an new empty list of integers called numbers.
            foreach (string string_number in string_numbers)                                                    // Iterates through each string_number in the string_numbers array
            {
                if (int.TryParse(string_number, out int number))                                                // Checks if string_number is an integer and if true, outputs its value into the integer variable number.
                {
                    numbers.Add(number);                                                                        // Appends integer number to list numbers.
                }
                else                                                                                            // Else if string_number is not an integer, prints error message and returns to Main function.
                {
                    Console.WriteLine($"Invalid number: {string_number}. Try again.");
                    Main();
                }
            }
            
            Stack<int> even_numbers_stack = new Stack<int>(numbers.Where (n => n % 2 == 0));                    // Establishes a stack of integers using the Linq expression Where to filter even numbers from numbers list.
            Console.Write("Even numbers stored in a stack: ");
            foreach (var number in even_numbers_stack)                                                          // Iterates through and prints each number in even_numbers_stack stack
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            Queue<int> odd_numbers_queue = new Queue<int>(numbers.Where(n => n % 2 == 1));                      // Establishes a queue of integers using the Linq expression Where to filter odd numbers from numbers list.
            Console.Write("Odd numbers stored in a queue: ");
            foreach (var number in odd_numbers_queue)                                                           // Iterates through and prints each number in odd_numbers_queue queue.
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}

// CITE: C# Corner
// URL: https://www.c-sharpcorner.com/UploadFile/219d4d/queue-collection-and-stack-collection-class-in-C-Sharp/#:~:text=Queue%20and%20stack%20are%20two,in%2Dfirst%2Dout%20algorithm.
// HELP: Queue and Stack Collection in C#

// CITE: Microsoft Build
// URL: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0
// HELP: System.Collections.Generic Namespace

// CITE: Microsoft Build
// URL: https://learn.microsoft.com/en-us/dotnet/api/system.linq?view=net-8.0
// HELP: System.Linq Namespace

// CITE: Microsoft Build
// URL: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// HELP: How to separate strings using String.Split in C#

// CITE: Microsoft Build
// URL: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
// HELP: Lambda expressions and anonymous functions