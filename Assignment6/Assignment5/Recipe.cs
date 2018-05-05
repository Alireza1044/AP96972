using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// دستور پخت 
    /// </summary>
    public class Recipe
    {
        public string title;
        private string[] keywords;
        /// <summary>
        /// ایجاد دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredients">لیست مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions,List<Ingredient> ingredients, int servingCount, string cuisine, string[] keywords)
        {
            // بر عهده دانشجو
            Title = title;
            Instructions = instructions;
            ServingCount = servingCount;
            Cuisine = cuisine;
            this.keywords = new string [keywords.Length];
            Keywords = keywords;
            Ingredients = new List<Ingredient>();
            Ingredients = ingredients;
        }

        /// <summary>
        /// ایجاد شئ دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredientCount">تعداد مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, int ingredientCount, int servingCount, string cuisine, string[] keywords)
        {
            // بر عهده دانشجو
            Title = title;
            Instructions = instructions;
            ServingCount = servingCount;
            Cuisine = cuisine;
            Keywords = keywords;
            IngredientCount = ingredientCount;
        }

        /// <summary>
        /// ذخیره اطلاعات دستور پخت غذای این شیء در فایل.
        /// </summary>
        /// <param name="writer">شیء مورد استفاده برای نوشتن در فایل</param>
        public void Serialize(StreamWriter writer,string ingFilePath)
        {
            // بر عهده دانشجو
            writer.WriteLine(Title);
            writer.WriteLine(Instructions);
            writer.WriteLine(ServingCount);
            writer.WriteLine(Cuisine);
            writer.WriteLine(Keywords.Length);
            for (int i = 0;i<Keywords.Length;i++)
            {
                writer.WriteLine(Keywords[i]);
            }
            writer.WriteLine(Ingredients.Count);
            using (StreamWriter write = new StreamWriter(ingFilePath, true, Encoding.UTF8))
            {
                write.WriteLine(this.Ingredients.Count);
                foreach (var i in Ingredients)
                {
                    if (i != null)
                    {
                        i.Serialize(write,ingFilePath);
                    }
                }
                //write.Close();
                //write.Dispose();
            }
        }

        /// <summary>
        ///  خواندن اطلاعات دستور پخت غذا از فایل و ایجاد شیء جدید از نوع این کلاس 
        /// </summary>
        /// <param name="reader">شیء مورد استفاده برای خواندن از فایل</param>
        /// <returns>شیء جدید از نوع Recipe</returns>
        public static Recipe Deserialize(StreamReader reader, string recipeFilePath,string ingFilePath)
        {
            // بر عهده دانشجو
            //if (File.Exists(recipeFilePath))
            //{
                //int recipeListLen = int.Parse(reader.ReadLine());
                string title = reader.ReadLine();
                string instructions = reader.ReadLine();
                int servingCount = int.Parse(reader.ReadLine());
                string cuisine = reader.ReadLine();
                //string[] keywords = reader.ReadLine().Split();
                int keywordsLen = int.Parse(reader.ReadLine());
                string[] keywords = new string[keywordsLen];
                for(int i = 0; i < keywordsLen; i++)
                {
                    keywords[i] = reader.ReadLine();
                }
                int ingredientCount = int.Parse(reader.ReadLine());
                using (StreamReader read = new StreamReader(ingFilePath))
                {
                    int ingCount = int.Parse(read.ReadLine());
                    List<Ingredient> ing = new List<Ingredient>();
                    for (int i = 0; i < ingCount; i++)
                    {
                        ing.Add(Ingredient.Deserialize(read, ingFilePath));
                    }
                    return new Recipe(title, instructions, ing, servingCount, cuisine, keywords);
                }
            //}
            //else
            //return null;
        }

        /// <summary>
        /// recipe's instructions
        /// </summary>
        public string Instructions
        {
            get;
            set;
        }

        /// <summary>
        /// recipe's serving count
        /// </summary>
        public int ServingCount
        {
            get;
            set;
        }

        /// <summary>
        /// recipe's cuisine
        /// </summary>
        public string Cuisine
        {
            get;
            set;
        }

        /// <summary>
        /// the number of ingredients in a recipe
        /// </summary>
        public int IngredientCount
        {
            get;
            set;
        }

        /// <summary>
        /// keywords of the recipe
        /// </summary>
        public string[] Keywords
        {
            get;
            set;
        }

        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            // بر عهده دانشجو
            ingredients.Add(ingredient);
            return true;
        }

        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            // بر عهده دانشجو
            for(int i =0;i<ingredients.Count && ingredients[i] != null; i++)
            {
                if(ingredients[i].Name == name)
                {
                    ingredients.RemoveAt(i);
                    return true;
                }
            }
                return false;
        }

        /// <summary>
        /// بروز کردن تعداد افرادی که این دستور غذا برای آن تعداد مناسب است
        /// مقادیر مواد اولیه به نسبت لازم اضافه میشود
        /// </summary>
        /// <param name="newServingCount">تعداد افراد جدید</param>
        public void UpdateServingCount(int newServingCount)
        {
            // بر عهده دانشجو\
            for(int i = 0; i < Ingredients.Count && Ingredients[i] != null; i++)
            {
                Ingredients[i].Quantity *= newServingCount / ServingCount;
            }
            ServingCount = newServingCount;
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
        private List<Ingredient> ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public List<Ingredient> Ingredients {
            get
            {
                return ingredients;
            }
            private set
            {
                ingredients = value;
                // بر عهده دانشجو
            }
        }

        /// <summary>
        /// Converts some recipe info into string
        /// </summary>
        /// <returns> a string of the selected recipe info </returns>
        public override string ToString()
        {
            // بر عهده دانشجو
            string info = "Title: " + Title + "\nInstructions: " + Instructions
                + "\nCuisine: " + Cuisine + "\nKeywords:\n";
            for (int i = 0; i < Ingredients.Count && Ingredients[i] != null; i++)
            {
                info += Ingredients[i].Name + "\n";
            }
            info += "Keywords:\n";
            for (int i = 0; i < Keywords.Length && Keywords[i] != null; i++)
            {
                info += Keywords[i] + "\n";
            }
            return info;
        }

        /// <summary>
        /// The title of recipe
        /// </summary>
        public string Title
        {
            get;
            set;
        }
    }
}
