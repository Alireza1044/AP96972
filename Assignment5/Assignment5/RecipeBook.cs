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
        /// <summary>
        /// ایجاد شیء کتابچه دستور غذا
        /// </summary>
        /// <param name="title">عنوان کتابچه غذا</param>
        /// <param name="capacity">ظرفیت کتابچه</param>
        public RecipeBook(string title, int capacity)
        {
            // بر عهده دانشجو
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            // بر عهده دانشجو
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
            return null;
        }

    }
}
