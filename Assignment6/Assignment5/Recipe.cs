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
        private const string IngredientFilePath = @"ingredient.txt";
        public string title;
        private string instructions;
        private int servingCount;
        private string cuisine;
        private string[] keywords;
        private int ingredientCount;
        /// <summary>
        /// ایجاد دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredients">لیست مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, Ingredient[] ingredients, int servingCount, string cuisine, string[] keywords)
        {
            // بر عهده دانشجو
            this.title = title;
            this.instructions = instructions;
            this.servingCount = servingCount;
            this.cuisine = cuisine;
            this.keywords = new string [keywords.Length];
            for(int i = 0; i < keywords.Length; i++)
            {
                this.keywords[i] = keywords[i];
            }
                Ingredients = new Ingredient[ingredients.Length];
            for(int i = 0; i < ingredients.Length; i++)
            {
                Ingredients[i] = ingredients[i];
            }
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
            this.title = title;
            this.instructions = instructions;
            this.servingCount = servingCount;
            this.cuisine = cuisine;
            this.keywords = keywords;
            this.ingredientCount = ingredientCount;
        }

        /// <summary>
        /// ذخیره اطلاعات دستور پخت غذای این شیء در فایل.
        /// </summary>
        /// <param name="writer">شیء مورد استفاده برای نوشتن در فایل</param>
        public void Serialize(StreamWriter writer)
        {
            // بر عهده دانشجو
            writer.WriteLine(title);
            writer.WriteLine(instructions);
            writer.WriteLine(servingCount);
            writer.WriteLine(cuisine);
            writer.WriteLine(keywords.Length);
            for (int i = 0;i<keywords.Length;i++)
            {
                writer.WriteLine(keywords[i]);
            }
            writer.WriteLine(this.ingredients.Length);
            using (StreamWriter write = new StreamWriter(IngredientFilePath, true, Encoding.UTF8))
            {
                write.WriteLine(this.ingredients.Length);
                foreach (var i in ingredients)
                {
                    if (i != null)
                    {
                        i.Serialize(write,IngredientFilePath);
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
        public static Recipe Deserialize(StreamReader reader, string recipeFilePath)
        {
            // بر عهده دانشجو
            if (File.Exists(recipeFilePath))
            {
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
                using (StreamReader read = new StreamReader(IngredientFilePath))
                {
                    int ingCount = int.Parse(read.ReadLine());
                    Ingredient[] ing = new Ingredient[ingCount];
                    for (int i = 0; i < ing.Length; i++)
                    {
                        ing[i] = Ingredient.Deserialize(read, IngredientFilePath);
                    }
                    return new Recipe(title, instructions, ing, servingCount, cuisine, keywords);
                }
            }
            else
            return null;
        }

        public string Instructions
        {
            get
            {
                return instructions;
            }
            set
            {
                instructions = value;
            }
        }

        public int ServingCount
        {
            get
            {
                return servingCount;
            }
            set
            {
                servingCount = value;
            }
        }

        public string Cuisine
        {
            get
            {
                return cuisine;
            }
            set
            {
                cuisine = value;
            }
        }

        public int IngredientCount
        {
            get
            {
                return ingredientCount;
            }
            set
            {
                ingredientCount = value;
            }
        }

        public string[] Keywords
        {
            get
            {
                return keywords;
            }
            set
            {
                keywords = value;
            }
        }

        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            // بر عهده دانشجو
            for (int i = 0; i < Ingredients.Length ; i++)
            {
                if (Ingredients[i] == null)
                {
                    Ingredients[i] = ingredient;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            // بر عهده دانشجو
            for (int i = 0; i < Ingredients.Length; i++)
            {
                if (Ingredients[i].Name == name)
                {
                    for(int j = i; j < Ingredients.Length-1; j++)
                    {
                        Ingredients[j] = Ingredients[j + 1];
                    }
                    Ingredients[Ingredients.Length - 1] = null;
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
            for(int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity *= newServingCount / servingCount;
            }
            servingCount = newServingCount;
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
        private Ingredient[] ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public Ingredient[] Ingredients {
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

        public override string ToString()
        {
            // بر عهده دانشجو
            return null;
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
    }
}
