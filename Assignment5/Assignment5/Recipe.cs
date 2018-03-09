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
        public string instructions;
        public int servingCount;
        public string cuisine;
        public string[] keywords;
        public int ingredientCount;
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
            this.keywords = keywords;
            this.Ingredients = ingredients;

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
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            // بر عهده دانشجو
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
            return false;
        }

        /// <summary>
        /// بروز کردن تعداد افرادی که این دستور غذا برای آن تعداد مناسب است
        /// مقادیر مواد اولیه به نسبت لازم اضافه میشود
        /// </summary>
        /// <param name="newServingCount">تعداد افراد جدید</param>
        public void UpdateServingCount(int newServingCount)
        {
            // بر عهده دانشجو
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
        private Ingredient[] _Ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public Ingredient[] Ingredients {
            get
            {
                return _Ingredients;
            }
            private set
            {
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
                return this.title;
            }
            set
            {
                title = value;
            }
        }
    }
}
