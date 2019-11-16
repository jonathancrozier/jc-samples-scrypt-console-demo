using JC.Samples.ScryptConsoleDemo.Providers;
using System;

namespace JC.Samples.ScryptConsoleDemo
{
    /// <summary>
    /// Main Program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            while (true)
            {
                // Request a plain text value from the user.
                string enterValuePrompt = "Enter a value to hash (press Ctrl+C to exit)";

                Console.WriteLine(enterValuePrompt);
                Console.WriteLine("".PadLeft(enterValuePrompt.Length, '='));
                Console.WriteLine();

                string plainValue = Console.ReadLine();

                // If the value entered is null (Ctrl+C), 
                // break from the loop to close the program.
                if (plainValue == null) break;

                // Display a title above the hashed value output.
                string hashedValueTitle = "Hashed Value";

                Console.WriteLine();
                Console.WriteLine(hashedValueTitle);
                Console.WriteLine("".PadLeft(hashedValueTitle.Length, '='));
                Console.WriteLine();

                // Compute the hashed value.
                IHashProvider hashProvider = new HashProvider();

                string hashedValue = hashProvider.ComputeHash(plainValue);

                // Display the hashed value.
                Console.WriteLine(hashedValue);
                Console.WriteLine();
            }
        }
    }
}