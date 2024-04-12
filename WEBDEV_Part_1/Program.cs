using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Ingredient
    {
        public string Name { get; set; }            // Name of the ingredient
        public double Quantity { get; set; }        // Quantity of the ingredient
        public string Unit { get; set; }            // Unit of measurement for the ingredient
        public double OriginalQuantity { get; set; } // Original quantity of the ingredient before scaling
    }

    class Recipe
    {
        private Ingredient[] ingredients;            // Array to store ingredients
        private string[] steps;                      // Array to store steps of the recipe

        // Constructor to initialize Recipe with specified number of ingredients and steps
        public Recipe(int numIngredients, int numSteps)
        {
            ingredients = new Ingredient[numIngredients]; // Initialize ingredients array
            steps = new string[numSteps];                 // Initialize steps array
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(int index, string name, double quantity, string unit)
        {
            // Create a new Ingredient object and assign its properties
            ingredients[index] = new Ingredient { Name = name, Quantity = quantity, Unit = unit, OriginalQuantity = quantity };
        }

        // Method to add a step to the recipe
        public void AddStep(int index, string description)
        {
            steps[index] = description; // Assign the step description to the corresponding index in the steps array
        }

        // Method to display the recipe including ingredients and steps
        public void DisplayRecipe()
        {
            // Check if recipe data is available
            if (ingredients == null || steps == null || ingredients.Length == 0 || steps.Length == 0)
            {
                Console.WriteLine("No recipe data available."); // Display message if no data is available
                return;
            }

            // Display ingredients
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            // Display steps
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a specified factor
        public void ScaleRecipe(double factor)
        {
            // Scale each ingredient's quantity by the specified factor
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset ingredient quantities to their original values
        public void ResetQuantities()
        {
            // Restore each ingredient's quantity to its original value
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }
        
        // Method to clear recipe data and prompt user to create a new recipe
        public void ClearData()
        {
            ingredients = null; // Set ingredients array to null
            steps = null;       // Set steps array to null

            // Prompt user to create a new recipe
            Console.WriteLine("Data cleared successfully! Let's create a new recipe.");
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            // Initialize a new recipe with the specified number of ingredients and steps
            ingredients = new Ingredient[numIngredients];
            steps = new string[numSteps];

            // Input ingredients for the new recipe
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                double quantity;
                while (true)
                {
                    Console.Write($"Enter the quantity of {name}: ");
                    string quantityInput = Console.ReadLine();

                    // Validate quantity input
                    if (!double.TryParse(quantityInput, out quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Invalid quantity! Please enter a valid number greater than zero.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit, OriginalQuantity = quantity }; // Add ingredient to the recipe
            }

            // Input steps for the new recipe
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                steps[i] = step; // Add step to the recipe
            }

            Console.WriteLine("\nRecipe entered successfully!");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Recipe App!");

            // Prompt user to enter number of ingredients and steps
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            Recipe recipe = new Recipe(numIngredients, numSteps); // Initialize Recipe object

            // Input ingredients
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                double quantity;
                while (true)
                {
                    Console.Write($"Enter the quantity of {name}: ");
                    string quantityInput = Console.ReadLine();

                    // Validate quantity input
                    if (!double.TryParse(quantityInput, out quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Invalid quantity! Please enter a valid number greater than zero.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(i, name, quantity, unit); // Add ingredient to the recipe
            }

            // Input steps
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                recipe.AddStep(i, step); // Add step to the recipe
            }

            Console.WriteLine("\nRecipe entered successfully!");

            // Main menu loop
            while (true)
            {
                // Display options
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Display Recipe");
                Console.WriteLine("2. Scale Recipe");
                Console.WriteLine("3. Reset Quantities");
                Console.WriteLine("4. Clear Data");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                }

                switch (choice)
                {
                    case 1:
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        Console.WriteLine("Scale Options: 0.5, 2, 3");
                        double factor;
                        while (true)
                        {
                            Console.Write("Enter scale factor: ");
                            string input = Console.ReadLine();
                            if (!double.TryParse(input, out factor) || (factor != 0.5 && factor != 2 && factor != 3))
                            {
                                Console.WriteLine("Invalid scale factor! Please enter 0.5, 2, or 3.");
                            }
                            else
                            {
                                break;
                            }
                        }
                        recipe.ScaleRecipe(factor);
                        Console.WriteLine("Recipe scaled successfully!");
                        break;
                    case 3:
                        recipe.ResetQuantities();
                        Console.WriteLine("Quantities reset successfully!");
                        break;
                    case 4:
                        recipe.ClearData();
                        Console.WriteLine("Data cleared successfully!");

                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }
        }
    }
}
