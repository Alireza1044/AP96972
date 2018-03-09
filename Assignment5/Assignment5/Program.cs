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
        static void Main(string[] args)
        {
            
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);

            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("Enter title:");
                string title = Console.ReadLine();
                Console.WriteLine("Enter Capacity:");
                int capacity = int.Parse(Console.ReadLine());
                RecipeBook Recipies = new RecipeBook(title, capacity);
                //Ingredient[] ingredients = new Ingredient();
                
                Console.WriteLine($"Press N(ew), D(el), S(earch)or L(ist)");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.N:
                        Console.WriteLine("New Recipe");
                        // بر عهده دانشجو
                        // reading the requirements
                        Console.WriteLine("Enter instructions:");
                        string instructions = Console.ReadLine();
                        Console.WriteLine("Enter servingCount:");
                        int servingCount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter cuisine:");
                        string cuisine = Console.ReadLine();
                        Console.WriteLine("Enter keywords:");
                        string[] keywords = (Console.ReadLine()).Split();
                        //creating object of class Recipe
                        //Recipe recipe = new Recipe(title, instructions,ingredients, servingCount, cuisine, keywords);
                        //Recipies.Add(title,);
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Delete Recipe");
                        // بر عهده دانشجو
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Search Recipe");
                        // بر عهده دانشجو
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("List Recipes");
                        // بر عهده دانشجو
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Esc");
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
