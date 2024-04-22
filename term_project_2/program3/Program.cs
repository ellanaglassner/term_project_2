// Ellana Glassner
// .NET 8.0.201
// Compile program with command 'dotnet build'
// Run program with command 'dotnet run'

// Tells the compiler to include the "System" namespace in the current file's scope.
using System;

// Defines a namespace called calculator to organize and encapsulate all related calculator code.
namespace calculator
{

    // Declares Program class for intended user interaction
    class Program
    {
        
        // Performs indicated calculations between two given integers, returns nothing.
        static void calculate()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Select an operation:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-----------------------------------");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            if (choice == "5")
            {
                Environment.Exit(0);
            }
            Console.Write("Enter the first number: ");
            double first = double.Parse(Console.ReadLine());                                                        // Converts user input of the first number from string to double.
            Console.Write("Enter the second number: ");
            double second = double.Parse(Console.ReadLine());                                                       // Converts user input of the second number from string to double.
            Func<double, double, double> operation = null;                                                          // Defines a Func delegate called operation that takes two double parameters and returns a double, initialized to null.
            switch (choice)
            {
                case "1":
                    operation = Add;                                                                                // If user enters 1, operation is set to add.
                    break;
                case "2":
                    operation = Subtract;                                                                           // If user enters 2, operation is set to subtract.
                    break;
                case "3":
                    operation = Multiply;                                                                           // If user enters 3, operation is set to multiply.
                    break;
                case "4":
                    operation = Divide;                                                                             // If user enters 4, operation is set to divide.
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try Again.");                                                // If user does not enter any of the previous options, prints error message and runs program again.
                    calculate();
                    break;
            }
            double result = operation(first, second);                                                               // Performs an arithmetic operation between doubles first and second based on the function assigned to operation.
            Console.WriteLine($"RESULT: {result}");
            Console.Write("Repeat (1) or exit (2): ");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    calculate();                                                                                    // If user enters 1, program repeats.
                    break;
                case "2":
                    Environment.Exit(0);                                                                            // If user enters 2, program exits.
                    break;
                default:
                    Environment.Exit(0);                                                                            // If user does not enter any of the previous options, program exits.
                    break;
            }
        }

        // Defines static method Add that takes two double parameters and returns a double.
        static double Add(double first, double second) => first + second;                                           // Uses lambda expression to return their sum.
        
        // Defines static method Subtract that takes two double parameters and returns a double.
        static double Subtract(double first, double second) => first - second;                                      // Uses lambda expression return their difference.
        
        // Defines static method Multiply that takes two double parameters and returns a double.
        static double Multiply(double first, double second) => first * second;                                      // Uses lambda expression to return their product.
        
        // Defines static method Divide that takes two double parameters and returns a double.
        static double Divide(double first, double second)
        {
            if (second != 0)
            {
                return first / second;                                                                              // If second number is not equal to zero, returns quotient.
            }
            else
            {
                Console.WriteLine("Invalid input for operation. Try again.");                                       // Else, prints error message, runs program again, and returns 0.
                calculate();
                return 0;
            }
        }

        // Declares main method of the program, belongs to the class, returns nothing.
        static void Main()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Welcome to the C# calculator!");
            calculate();
        }
    }
}

// CITE: Double.Parse Method
// URL: https://learn.microsoft.com/en-us/dotnet/api/system.double.parse?view=net-8.0
// HELP: Microsoft Build

// CITE: C# Func Delegate
// URL: https://www.tutorialsteacher.com/csharp/csharp-func-delegate#:~:text=Func%3Cint%2C%20int%2C%20int,and%20returns%20an%20int%20value.&text=A%20Func%20delegate%20type%20can,out%20parameter%20for%20the%20result.
// HELP: TutorialsTeacher

// CITE: Lambda Expressions in C#
// URL: https://www.geeksforgeeks.org/lambda-expressions-in-c-sharp/
// HELP: GeeksForGeeks
