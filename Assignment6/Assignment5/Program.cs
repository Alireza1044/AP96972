using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Program
    {
        private const string RecipeFilePath = @"recipe.txt";
        private const string ingFilePath = @"ingredient.txt";
         /// <summary>
         /// reads the reqiured info of recipe book
         /// </summary>
         /// <returns></returns>
        public static RecipeBook GetBookInput()
        {
            Console.WriteLine("Enter title of the recipe book:");
            string titleOfTheBook = Console.ReadLine();
            Console.WriteLine("Enter capacity of the recipe book:");
            int capacity = int.Parse(Console.ReadLine());
            return new RecipeBook(titleOfTheBook, capacity);
        }

        /// <summary>
        /// reads the reqiured info of the recipe
        /// </summary>
        /// <returns></returns>
        public static Recipe GetRecipeInput()
        {
            Console.WriteLine("New Recipe");
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
            return new Recipe(title, instructions,
            new List<Ingredient>(), servingCount, cuisine, keywords);
        }

        /// <summary>
        /// reads the reqiured info of ingredient
        /// </summary>
        /// <returns></returns>
        public static Ingredient GetIngredientInput()
        {
                Console.WriteLine("add description");
                string description = Console.ReadLine();
                Console.WriteLine("unit");
                string unit = Console.ReadLine();
                Console.WriteLine("name");
                string ingredientName = Console.ReadLine();
                Console.WriteLine("quantity");
                double quantity = double.Parse(Console.ReadLine());
                return new Ingredient(ingredientName, description, quantity, unit);
        }

        /// <summary>
        /// Removes a recipe from recipe book by title
        /// </summary>
        /// <param name="recipeBook"></param>
        /// <returns></returns>
        public static Recipe RemoveByTitle(RecipeBook recipeBook)
        {
            string titleToSearch = Console.ReadLine();
            Recipe recipeTitle = recipeBook.LookupByTitle(titleToSearch);
            Console.WriteLine(recipeTitle.ToString());
            Console.WriteLine("Do you want to remove the following recipe or update the serving count? Y or N or U");
            return recipeTitle;
        }
        
        /// <summary>
        /// Removes recipes from recipe book by keyword
        /// </summary>
        /// <param name="recipeBook"></param>
        /// <returns></returns>
        public static Recipe[] RemoveByKeyword(RecipeBook recipeBook)
        {
            string keywordToSearch = Console.ReadLine();
            Recipe[] recipeKeyword = recipeBook.LookupByKeyword(keywordToSearch);
            for (int i = 0; i < recipeKeyword.Length && recipeKeyword[i] != null; i++)
            {
                Console.WriteLine(recipeKeyword[i].ToString());
            }
            Console.WriteLine("Do you want to remove the following recipies? Y or N");
            return recipeKeyword;
        }

        /// <summary>
        /// updates the serving count
        /// </summary>
        /// <returns></returns>
        public static int UpdateServingCount()
        {
            Console.WriteLine("Enter the new Serving count:");
            int newServingCount = int.Parse(Console.ReadLine());
            return newServingCount;
        }

        /// <summary>
        /// Removes recipes from recipe book by cuisine
        /// </summary>
        /// <param name="recipeBook"></param>
        /// <returns></returns>
        public static Recipe[] RemoveByCuisine(RecipeBook recipeBook)
        {
            string cuisineToSearch = Console.ReadLine();
            Recipe[] recipeCuisine = recipeBook.LookupByCuisine(cuisineToSearch);
            for (int i = 0; i < recipeCuisine.Length && recipeCuisine[i] != null; i++)
            {
                Console.WriteLine(recipeCuisine[i].ToString());
            }
            Console.WriteLine("Do you want to remove the following recipies? Y or N");
            return recipeCuisine;
        }

        /// <summary>
        /// removes the selected recipe
        /// </summary>
        /// <param name="recipeBook"></param>
        /// <returns></returns>
        public static string DeleteRecipe(ref RecipeBook recipeBook)
        {
            string nameToDelete = Console.ReadLine();
            recipeBook.Remove(nameToDelete);
            return nameToDelete;
        }

        /// <summary>
        /// removes the selected ingredient
        /// </summary>
        /// <returns></returns>
        public static string RemoveIngredient()
        {
            string nameToDelete;
            Console.WriteLine("Remove Ingredient \nEnter the name: ");
            nameToDelete = Console.ReadLine();
            return nameToDelete;
        }


        public static string ReadAction()
        {
            string action = Console.ReadLine();
            return action;
        }

        /// <summary>
        /// loads the saved files
        /// </summary>
        /// <param name="recipeBook"></param>
        /// <param name="recipeFilePath">save path for recipes</param>
        /// <param name="ingFilePath">save path for ingredients</param>
        /// <returns></returns>
        public static bool LoadRecipes(ref RecipeBook recipeBook,string recipeFilePath,string ingFilePath)
        {
            bool flag = recipeBook.Load(recipeFilePath, ingFilePath);
            if (flag)
            {
                Console.WriteLine("Loaded successfuly!");
            }
            else
            {
                Console.WriteLine("Failed to load!");
            }
            return flag;
        }

        static void Main(string[] args)
        {
            //RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);
            ConsoleKeyInfo cki;
            //creating the Recipebook object
            RecipeBook recipeBook = GetBookInput();
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
                        if (NumberOfRceipies < recipeBook.Capacity)
                        {
                            // بر عهده دانشجو
                            recipe = GetRecipeInput();
                            //adding ingredeints
                            for (int i = 0; i < recipe.IngredientCount; i++)
                            {
                                Console.WriteLine($"adding ingredient {i + 1}");
                                Ingredient ingredientTemp = GetIngredientInput();
                                recipe.AddIngredient(ingredientTemp);
                            }
                            do
                            {
                                Console.WriteLine("Do you want to remove an ingredient? Y or N");
                                cki = Console.ReadKey();
                                string nameToDelete = RemoveIngredient();
                                if (cki.Key == ConsoleKey.Y)
                                {
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
                        DeleteRecipe(ref recipeBook);
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Search Recipe");
                        // بر عهده دانشجو
                        Console.WriteLine("Which one do you want to search? \ntitle \nkeyword \ncuisine");
                        string action = ReadAction();
                        switch (action)
                        {
                            case "title":
                                Recipe recipeTitle = RemoveByTitle(recipeBook);
                                cki = Console.ReadKey();
                                switch (cki.Key)
                                {
                                    case ConsoleKey.Y:
                                        recipeBook.Remove(recipeTitle.title);
                                        break;
                                    case ConsoleKey.U:
                                        recipeTitle.UpdateServingCount(UpdateServingCount());
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "keyword":
                                Recipe[] recipeKeyword = RemoveByKeyword(recipeBook);
                                cki = Console.ReadKey();
                                switch (cki.Key)
                                {
                                    case ConsoleKey.Y:
                                        for(int i = 0; i < recipeKeyword.Length; i++)
                                        {
                                            recipeBook.Remove(recipeKeyword[i].ToString());
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "cuisine":
                                Recipe[] recipeCuisine = RemoveByCuisine(recipeBook); 
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
                        //bool flag = recipeBook.Load(RecipeFilePath,ingFilePath);
                        //if (flag)
                        //{
                        //    Console.WriteLine("Loaded successfuly!");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Failed to load!");
                        //}
                        LoadRecipes(ref recipeBook,RecipeFilePath,ingFilePath);
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
