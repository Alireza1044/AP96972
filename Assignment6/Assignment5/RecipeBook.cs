using System;
using System.Collections.Generic;
using System.IO;
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
            Title = title;
            Capacity = capacity;
        }
        List<Recipe> recipeList  = new List<Recipe>();

        /// <summary>
        /// the title of the recipe book
        /// </summary>
        public string Title
        {
            get;
            set;
        }
         /// <summary>
         /// capacity of the recipe book
         /// </summary>
        public int Capacity
        {
            get;
            set;
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
            return true;
        }

        /// <summary>
        /// حذف دستور پخت
        /// </summary>
        /// <param name="recipeTitle">عنوان دستور پخت</param>
        /// <returns>آیا حذف دستور پخت درست انجام شد؟</returns>
        public bool Remove(string recipeTitle)
        {
            // بر عهده دانشجو
            for(int i =0;i<recipeList.Count; i++)
            {
                if (recipeList[i].Title == recipeTitle)
                {
                    recipeList.RemoveAt(i);
                    return true;
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
            for(int i = 0;i < recipeList.Count && recipeList[i] != null; i++)
            {
                if(recipeList[i].Title == title)
                {
                    return recipeList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// ذخیره لیست دستور پخت غذاها در فایل.
        /// </summary>
        /// <param name="recipeFilePath">آدرس فایل</param>
        public void Save(string recipeFilePath,string ingFilePath)
        {
            using (StreamWriter writer = new StreamWriter(recipeFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine(Capacity);
                foreach (var r in this.recipeList)
                {
                    if (r != null)
                    {
                        r.Serialize(writer,ingFilePath);
                    }
                }
            }
        }


        /// <summary>
        /// بارگزاری اطلاعات از فایل ذخیره شده
        /// </summary>
        /// <param name="recipeFilePath">آدرس فایل</param>
        /// <returns>آیا بارگزاری با موفقیت انجام شد؟</returns>
        public bool Load(string recipeFilePath,string ingFilePath)
        {
            if (!File.Exists(recipeFilePath))
                return false;

            using (StreamReader reader = new StreamReader(recipeFilePath))
            {
                int recipeCount = int.Parse(reader.ReadLine());
                this.recipeList = new List<Recipe>();
                for (int i = 0; i < recipeCount ; i++)
                {
                    Recipe r = Recipe.Deserialize(reader,recipeFilePath,ingFilePath);
                    //if (null == r)
                    //{
                    //    // Deserialize returns null if it reaches end of file.
                    //    break;
                    //}
                    recipeList.Add(r);
                }
            }
            return true;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public Recipe[] LookupByKeyword(string keyword)
        {
            // بر عهده دانشجو
            
            List<Recipe> foundRecipe = new List<Recipe>();
            for(int i = 0; i < recipeList.Count && recipeList[i] != null ; i++)
            {
                for(int j = 0; j < recipeList[i].Keywords.Length && recipeList[i].Keywords[j] != null ; j++)
                {
                    if(recipeList[i].Keywords[j] == keyword)
                    {
                        foundRecipe.Add(recipeList[i]);
                    }
                }
            }
            return foundRecipe.ToArray();
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public Recipe[] LookupByCuisine(string cuisine)
        {
            // بر عهده دانشجو
            List<Recipe> recipeSearchByCuisine = new List<Recipe>();
            for (int i = 0; i < recipeList.Count && recipeList[i] != null; i++)
            {
                if(recipeList[i].Cuisine == cuisine)
                {
                    recipeSearchByCuisine.Add(recipeList[i]);
                }
            }
            return recipeSearchByCuisine.ToArray();
        }
    }
}
