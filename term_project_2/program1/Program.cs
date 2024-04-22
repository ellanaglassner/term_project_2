// Ellana Glassner
// .NET 8.0.201
// Compile program with command 'dotnet build'
// Run program with command 'dotnet run'

// Tells the compiler to include the "system" namespace in the current file's scope.
using System;

// Defines a namespace called ATM to organize and encapsulate all related ATM code.
namespace ATM                                                                                   
{
    
    // Declares Program class for intended user interaction.
    class Program
    {
        
        // Defines a dictionary called accounts with each key as a string and each value an account.
        static Dictionary<string, Account> accounts = new Dictionary<string, Account>();        // Declares a dictionary called accounts with strings as keys and Account classes as values.
        
        // Declares main method of the program, belongs to the class, returns nothing.
        static void Main()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Welcome to the C# ATM!");
            options();
        }
        
        // Displays options of the ATM to the user, returns nothing.
        static void options()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("HOME");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Deposit funds");
            Console.WriteLine("3. Withdraw funds");
            Console.WriteLine("4. View account information");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-------------------------");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();
            
            switch (choice)                                                                     // Switch statment that evaluates an expression and executes corresponding code based on user input.
            {
                case "1":                                                                       // If user enters 1, create_account is called.
                    create_account();
                    break;
                case "2":                                                                       // If user enters 2, deposit_funds is called.
                    deposit_funds();
                    break;
                case "3":                                                                       // If user enters 3, withdraw_funds is called.
                    withdraw_funds();
                    break;
                case "4":                                                                       // If user enters 4, view_account_information is called.
                    view_account_information();
                    break;
                case "5":                                                                       // If user enters 5, the program exits.
                    Environment.Exit(0);
                    break;
                default:                                                                        // If the user does not enter any of the previous options, default response.
                    Console.WriteLine("Invalid option. Please enter 1-5.");
                    options();
                    break;
            }
        }
        
        // Creates a new account in the ATM, returns nothing.
        static void create_account()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("CREATING ACCOUNT");
            Console.WriteLine("-------------------------");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Create a PIN: ");
            string pin = Console.ReadLine();
            if (accounts.ContainsKey(pin)) {
                Console.WriteLine("An account with this PIN already exits. Try again.");
                create_account();
            }
            Console.Write("Enter initial balance: ");
            double balance;
            if (!double.TryParse(Console.ReadLine(), out balance) || balance < 0)               // If user input is not of data type double or is below zero, prints error message.
            {
                Console.WriteLine("Invalid amount. Please enter positive integer. Try again.");
                create_account();
            }
            Account new_account = new Account(name, pin, balance);                              // Creates a new account in the accounts class with given name, PIN, and balance.
            accounts.Add(pin, new_account);                                                     // Adds a new pair to the dictionary with PIN as the key and new account as its value.
            Console.WriteLine("-------------------------");
            Console.WriteLine("Account successfully created!");
            return_or_exit();
        }
        
        // Deposits funds into accounts in the ATM, returns nothing.
        static void deposit_funds()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("DEPOSITING FUNDS");
            Console.WriteLine("-------------------------");
            Console.Write("Enter your PIN: ");
            string pin = Console.ReadLine();
            if(!accounts.ContainsKey(pin))                                                      // If given PIN is not a key within the dictionary, prints error message.
            {
                Console.WriteLine("Account does not exist. Try again.");
                options();
            }
            Console.WriteLine($"Hello {accounts[pin].Name}!");
            Console.Write("Enter amount to deposit: ");
            double amount;
            if (!double.TryParse(Console.ReadLine(), out amount) || amount < 0)                 // If the user input is not of data type double or is below zero, prints error message.
            {
                Console.WriteLine("Invalid amount. Please enter positive integer. Try again.");
                deposit_funds();
            }
            accounts[pin].Deposit(amount);                                                      // Deposits indicated amount to account of specified user.
            Console.WriteLine("-------------------------");
            Console.WriteLine($"${amount} successfully deposited!");
            return_or_exit();
        }
        
        // Withdraws funds from accounts in the ATM, returns nothing.
        static void withdraw_funds()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("WITHDRAWING FUNDS");
            Console.WriteLine("-------------------------");
            Console.Write("Enter your PIN: ");
            string pin = Console.ReadLine();
            if(!accounts.ContainsKey(pin))                                                      // If given PIN is not a key within the dictionary, prints error message. 
            {
                Console.WriteLine("Account does not exist. Try again.");
                options();
            }
            Console.WriteLine($"Hello {accounts[pin].Name}!");
            Console.Write("Enter amount to withdraw: ");
            double amount;
            if (!double.TryParse(Console.ReadLine(), out amount) || amount < 0)                 // If the user input is not of data type double or is below zero, prints error message.
            {
                Console.WriteLine("Invalid amount. Please enter positive integer. Try again.");
                withdraw_funds();
            }
            if (accounts[pin].Withdraw(amount))                                                 // If indicated amount can be withdrawn from account of specified user, amount is withdrawn.

            {
                Console.WriteLine("-------------------------");
                Console.WriteLine($"${amount} successfully withdrawn!");
                return_or_exit();
            }
            else                                                                                // If indicated amount cannot be withdrawn from account of specified user, prints error message.
            {
                Console.WriteLine($"Insufficient funds. Try again.");
                options();
            }  
        }
        
        // Displays account information given PIN number, returns nothing.
        static void view_account_information()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("VIEWING ACCOUNT INFORMATION");
            Console.WriteLine("-------------------------");
            Console.Write("Enter your PIN: ");
            string pin = Console.ReadLine();
            if (!accounts.ContainsKey(pin))                                                     // If given PIN is not a key within the dictionary, prints error message. 
            {
                Console.WriteLine("Account does not exist. Try again.");
                options();
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Name: {accounts[pin].Name}");
            Console.WriteLine($"Balance: ${accounts[pin].Balance}");
            return_or_exit();
        }
        
        // Asks the user if they would like to return to home or exit the program.
        static void return_or_exit()
        {
            Console.Write("Return to home (1) or exit (2): ");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    options();                                                                  // If user enters 1, returns to home page.
                    break;
                case "2":                                                                       // If user enters 2, exits program.
                    Environment.Exit(0);
                    break;
            }
        }
    }

    // Declares Account class that create accounts in the ATM.
    class Account
    {
        
        public string Name { get; }                                                             // Declares read-only property called Name, retrieves value of name from user, accessed but not modified.
        public string Pin { get; }                                                              // Declares read-only property called Pin, retrieves value of PIN from user, accessed but not modified.
        public double Balance { get; private set; }                                             // Declares property called Balance, retrieves value of balance from user, read-only externally but modified internally.
        
        // Constructor class that intializes variables of the account class.
        public Account(string name, string pin, double balance)
        {
            Name = name;
            Pin = pin;
            Balance = balance;
        }
        
        // Adds given amount to balance, returns nothing.
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        
        // Subtracts given amount from balance, returns a boolean.
        public bool Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;                                                                    // If given amount is less than balance, performs operation and returns true.
            }
            return false;                                                                       // If given amount is greater than balance, returns false.
        }
    }
}

// CITE: CodeAcademy
// URL: https://www.codecademy.com/resources/docs/c-sharp/switch#
// HELP: Switch

// CITE: GeeksForGeeks
// URL: https://www.geeksforgeeks.org/c-sharp-dictionary-add-method/
// HELP: C# | Dictionary.Add() Method

// CITE: Microsoft Build
// URL: https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse?view=net-8.0
// HELP: Double.TryParse Method

// CITE: Microsoft Build
// URL: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
// HELP: Properties (C# Programming Guide)

// CITE: SLacks
// URL: https://stackoverflow.com/questions/8235840/dictionary-keys-contains-vs-containskey-are-they-functionally-equivalent
// HELP: Dictionary Keys.Contains vs ContainsKey
