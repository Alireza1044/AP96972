using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// کتابچه دستور غذا
    /// </summary>
    public class RecipeBook
    {
        public string title;
        public int capacity;
        /// <summary>
        /// ایجاد شیء کتابچه دستور غذا
        /// </summary>
        /// <param name="title">عنوان کتابچه غذا</param>
        /// <param name="capacity">ظرفیت کتابچه</param>
        public RecipeBook(string title, int capacity)
        {
            // بر عهده دانشجو
            this.title = title;
            this.capacity = capacity;
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            // بر عهده دانشجو
            recipeList.Add(recipe);
            return false;

        }

        /// <summary>
        /// حذف دستور پخت
        /// </summary>
        /// <param name="recipeTitle">عنوان دستور پخت</param>
        /// <returns>آیا حذف دستور پخت درست انجام شد؟</returns>
        public bool Remove(string recipeTitle)
        {
            // بر عهده دانشجو
            for(int i =0;i<capacity; i++)
            {
                if (recipeList[i].title == recipeTitle)
                {
                    recipeList.RemoveAt(i);
                }
            }
            return false;
        }

        /// <summary>
        /// پیدا کردن دستور پخت با عنوان
        /// </summary>
        /// <param name="title">عنوان دستور پخت</param>
        /// <returns>شیء دستور پخت</returns>
        public Recipe LookupByTitle(string title)
        {
            // بر عهده دانشجو
            for(int i = 0;i < capacity; i++)
            {
                if(recipeList[i].title == title)
                {
                    Console.WriteLine("Found!\n" + recipeList[i]);
                }
            }
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public Recipe[] LookupByKeyword(string keyword)
        {
            // بر عهده دانشجو
            for(int i = 0; i < capacity; i++)
            {
                for(int j = 0; j < capacity; j++)
                {
                    if(recipeList[i].keywords[j] == keyword)
                    {
                        Console.WriteLine("Found!\n" + recipeList[i]);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public Recipe[] LookupByCuisine(string cuisine)
        {
            // بر عهده دانشجو
            for(int i = 0; i < capacity; i++)
            {
                if(recipeList[i].cuisine == cuisine)
                {
                    Console.WriteLine("Found!\n" + recipeList[i]);
                }
            }
            return null;
        }
        List <Recipe> recipeList = new List<Recipe> ();

    }
}
