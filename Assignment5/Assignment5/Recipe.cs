using System;
using System.Collections.Generic;
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
            this.keywords = new string[keywords.Length];
            this.keywords = keywords;
            Ingredients = new Ingredient[ingredients.Length];
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
            this.title = title;
            this.instructions = instructions;
            this.servingCount = servingCount;
            this.cuisine = cuisine;
            this.keywords = keywords;
            this.ingredientCount = ingredientCount;
            Ingredients = new Ingredient[ingredientCount];
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
            for (int i = 0; i < Ingredients.Length; i++)
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
            string info = "Title: " + title + "\nInstructions: " + instructions
                + "\nCuisine: " + cuisine + "\nKeywords:\n";
            for(int i =0;i<Ingredients.Length && Ingredients[i] != null; i++)
            {
                info += Ingredients[i] + "\n";
            }
            info += "Keywords:\n";
            for(int i =0;i<keywords.Length && keywords[i] != null; i++)
            {
                info += keywords[i] + "\n";
            }
            return info;
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
