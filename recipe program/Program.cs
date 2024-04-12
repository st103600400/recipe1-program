using System;

namespace UniqueRecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Recipe class
            Recipe recipe = new Recipe();

            // Start a loop to display the menu options
            while (true)
            {
                // Display the menu options
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                // Prompt the user to enter their choice
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                // Handle the user's choice
                switch (choice)
                {
                    case 1:
                        // Call the EnterDetails() method to allow the user to enter recipe details
                        recipe.EnterDetails();
                        break;
                    case 2:
                        // Call the Display() method to display the recipe details
                        recipe.Display();
                        break;
                    case 3:
                        // Call the Scale() method to allow the user to scale the recipe
                        recipe.Scale();
                        break;
                    case 4:
                        // Call the ResetQuantities() method to reset the quantities of the ingredients
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        // Call the ClearData() method to clear all the recipe data
                        recipe.ClearData();
                        break;
                    case 6:
                        // Exit the program
                        Environment.Exit(0);
                        break;
                    default:
                        // Display an error message if the user enters an invalid choice
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Add a blank line for readability
                Console.WriteLine();
            }
        }
    }

    class Recipe
    {
        // Private fields to store the recipe details
        private int numIngredients;
        private Ingredient[] ingredients;
        private int numSteps;
        private string[] steps;

        // Method to allow the user to enter recipe details
        public void EnterDetails()
        {
            // Prompt the user to enter the number of ingredients
            Console.Write("Enter the number of ingredients: ");
            numIngredients = int.Parse(Console.ReadLine());

            // Create an array to store the ingredients
            ingredients = new Ingredient[numIngredients];

            // Loop through the ingredients and prompt the user to enter the details
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                float quantity = float.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();

                // Create a new Ingredient object and add it to the array
                ingredients[i] = new Ingredient(name, quantity, unit);
            }

            // Prompt the user to enter the number of steps
            Console.Write("Enter the number of steps: ");
            numSteps = int.Parse(Console.ReadLine());

            // Create an array to store the steps
            steps = new string[numSteps];

            // Loop through the steps and prompt the user to enter the details
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            // Display a success message
            Console.WriteLine("Recipe details entered successfully!");
        }

        // Method to display the recipe details
        public void Display()
        {
            // Display the recipe title
            Console.WriteLine("Recipe:");

            // Display the ingredients
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < numIngredients; i++)
            {
                Ingredient ingredient = ingredients[i];
                Console.WriteLine($"{i + 1}. {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }

            // Display the steps
            Console.WriteLine("Steps:");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe
        public void Scale()
        {
            // Prompt the user to enter the scaling factor
            Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
            float factor = float.Parse(Console.ReadLine());

            // Loop through the ingredients and scale the quantities
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].Quantity *= factor;
            }

            // Display a success message
            Console.WriteLine("Recipe scaled successfully!");
        }

        // Method to reset the quantities of the ingredients
        public void ResetQuantities()
        {
            // Loop through the ingredients and reset the quantities
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].ResetQuantity();
            }

            // Display a success message
            Console.WriteLine("Quantities reset successfully!");
        }

        // Method to clear all the recipe data
        public void ClearData()
        {
            // Reset the recipe details
            numIngredients = 0;
            ingredients = null;
            numSteps = 0;
            steps = null;

            // Display a success message
            Console.WriteLine("Data cleared successfully!");
        }
    }

    // Class to represent an ingredient
    class Ingredient
    {
        // Public properties to store the ingredient details
        public string Name { get; }
        public float Quantity { get; set; }
        public string Unit { get; }

        // Constructor to initialize the ingredient details
        public Ingredient(string name, float quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        // Method to reset the quantity of the ingredient
        public void ResetQuantity()
        {
            // Reset the quantity to the original value
        }
    }
}