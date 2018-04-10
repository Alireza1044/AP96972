using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        private const string RecipeFilePath = @"recipe.txt";
        private const string ingFilePath = @"ingredient.txt";
        static void Main(string[] args)
        {
            
            //RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);

            ConsoleKeyInfo cki;
            //creating the Recipebook object
            Console.WriteLine("Enter title of the recipe book:");
            string titleOfTheBook = Console.ReadLine();
            Console.WriteLine("Enter capacity of the recipe book:");
            int capacity = int.Parse(Console.ReadLine());
            RecipeBook recipeBook = new RecipeBook(titleOfTheBook, capacity);
            int NumberOfRceipies = 0;
            do
            {   
                Console.WriteLine($"Press (N)ew, (D)el, (S)earch, (L)ist, sa(V)e or l(O)ad");
                cki = Console.ReadKey();
                Console.WriteLine();
                Recipe recipe;
                switch (cki.Key)
                {
                    case ConsoleKey.N:
                        if (NumberOfRceipies < capacity)
                        {
                            Console.WriteLine("New Recipe");
                            // بر عهده دانشجو
                            //reading the requirements
                            Console.WriteLine("Enter instructions:");
                            string instructions = Console.ReadLine();
                            Console.WriteLine("Enter servingCount:");
                            int servingCount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter cuisine:");
                            string cuisine = Console.ReadLine();
                            Console.WriteLine("Enter keywords:");
                            string[] keywords = (Console.ReadLine()).Split();
                            Console.WriteLine("Enter ingredientCount:");
                            int ingredientCount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter title:");
                            string title = Console.ReadLine();
                            //creating object of Recipe Class
                            recipe = new Recipe(title, instructions,
                            new Ingredient[ingredientCount], servingCount, cuisine, keywords);
                            //adding ingredeints
                            for (int i = 0; i < ingredientCount; i++)
                            {
                                Console.WriteLine($"adding ingredient {i + 1}");
                                Console.WriteLine("add description");
                                string description = Console.ReadLine();
                                Console.WriteLine("unit");
                                string unit = Console.ReadLine();
                                Console.WriteLine("name");
                                string ingredientName = Console.ReadLine();
                                Console.WriteLine("quantity");
                                double quantity = double.Parse(Console.ReadLine());
                                Ingredient ingredientTemp = new Ingredient(ingredientName, description, quantity, unit);
                                recipe.AddIngredient(ingredientTemp);
                            }
                            do
                            {
                                Console.WriteLine("Do you want to remove an ingredient? Y or N");
                                cki = Console.ReadKey();
                                if (cki.Key == ConsoleKey.Y)
                                {
                                    Console.WriteLine("Remove Ingredient \nEnter the name: ");
                                    string nameToDelete = Console.ReadLine();
                                    recipe.RemoveIngredient(nameToDelete);
                                }
                                else
                                    break;
                            } while (true);
                            recipeBook.Add(recipe);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Recipe Book is full!");
                            break;
                        }
                    case ConsoleKey.D:
                        Console.WriteLine("Delete Recipe");
                        // بر عهده دانشجو
                        string recipeToDelete = Console.ReadLine();
                        recipeBook.Remove(recipeToDelete);
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Search Recipe");
                        // بر عهده دانشجو
                        Console.WriteLine("Which one do you want to search? \ntitle \nkeyword \ncuisine");
                        string action = Console.ReadLine();
                        switch (action)
                        {
                            case "title":
                                string titleToSearch = Console.ReadLine();
                                Recipe recipeTitle = recipeBook.LookupByTitle(titleToSearch);
                                    Console.WriteLine(recipeTitle.title);
                                Console.WriteLine("Do you want to remove the following recipe or update the serving count? Y or N or U");
                                cki = Console.ReadKey();
                                switch (cki.Key)
                                {
                                    case ConsoleKey.Y:
                                        recipeBook.Remove(recipeTitle.title);
                                        break;
                                    case ConsoleKey.U:
                                        Console.WriteLine("Enter the new Serving count:");
                                        int newServingCount = int.Parse(Console.ReadLine());
                                        recipeTitle.UpdateServingCount(newServingCount);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "keyword":
                                string keywordToSearch = Console.ReadLine();
                                Recipe[] recipeKeyword = recipeBook.LookupByKeyword(keywordToSearch);
                                for(int i = 0; i < recipeKeyword.Length && recipeKeyword[i] != null; i++)
                                {
                                    Console.WriteLine(recipeKeyword[i].title);
                                }
                                Console.WriteLine("Do you want to remove the following recipies? Y or N");
                                cki = Console.ReadKey();
                                switch (cki.Key)
                                {
                                    case ConsoleKey.Y:
                                        for(int i = 0; i < recipeKeyword.Length; i++)
                                        {
                                            recipeBook.Remove(recipeKeyword[i].title);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "cuisine":
                                string cuisineToSearch = Console.ReadLine();
                                Recipe[] recipeCuisine = recipeBook.LookupByCuisine(cuisineToSearch);
                                for(int i = 0; i < recipeCuisine.Length && recipeCuisine[i]!=null;i++)
                                {
                                    Console.WriteLine(recipeCuisine[i].title);
                                }
                                Console.WriteLine("Do you want to remove the following recipies? Y or N");
                                cki = Console.ReadKey();
                                switch (cki.Key)
                                {
                                    case ConsoleKey.Y:
                                        for(int i =0;i < recipeCuisine.Length; i++)
                                        {
                                            recipeBook.Remove(recipeCuisine[i].title);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Wrong entry! \nPlease try again!");
                                break;
                        }
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("List Recipes");
                        // بر عهده دانشجو
                        Console.WriteLine(recipeBook.ToString());
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Esc");
                        break;
                    case ConsoleKey.V:
                        recipeBook.Save(RecipeFilePath,ingFilePath);
                        break;
                    case ConsoleKey.O:
                        recipeBook.Load(RecipeFilePath,ingFilePath);
                        break;
                    default:
                        Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                        break;
                }

                Console.WriteLine("Press any key to continue, Esc to exit");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }


    }
}
