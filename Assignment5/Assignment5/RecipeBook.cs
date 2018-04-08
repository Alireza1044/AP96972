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
        private string title;
        private int capacity;
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
            recipeList = new Recipe[capacity];
        }
        Recipe[] recipeList;
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

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }
        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            // بر عهده دانشجو
            for(int i = 0; i < recipeList.Length; i++)
            {
                if(recipeList[i] == null) 
                {
                    recipeList[i] = recipe;
                    return true;
                }
            }
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
                if (recipeList[i].title == recipeTitle )
                {
                    for(int j = i; j < recipeList.Length && recipeList[i] != null; j++)
                    {
                        recipeList[j] = recipeList[j + 1];
                    }
                    recipeList[recipeList.Length-1] = null;
                    return true;
                }
                else
                    return false;
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
            for(int i = 0;i < recipeList.Length; i++)
            {
                if(recipeList[i].title == title)
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
        public void Save(string recipeFilePath)
        {
            using (StreamWriter writer = new StreamWriter(recipeFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine(capacity);
                foreach (var r in this.recipeList)
                {
                    if (r != null)
                    {
                        r.Serialize(writer);
                    }
                }
            }
        }


        /// <summary>
        /// بارگزاری اطلاعات از فایل ذخیره شده
        /// </summary>
        /// <param name="recipeFilePath">آدرس فایل</param>
        /// <returns>آیا بارگزاری با موفقیت انجام شد؟</returns>
        public bool Load(string recipeFilePath)
        {
            if (!File.Exists(recipeFilePath))
                return false;

            using (StreamReader reader = new StreamReader(recipeFilePath))
            {
                int recipeCount = int.Parse(reader.ReadLine());
                this.recipeList = new Recipe[recipeCount];
                for (int i = 0; i < recipeCount ; i++)
                {
                    Recipe r = Recipe.Deserialize(reader,recipeFilePath);
                    if (null == r)
                    {
                        // Deserialize returns null if it reaches end of file.
                        break;
                    }
                    this.recipeList[i] = r;
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
            int idx = 0;
            Recipe[] recipeSearchByKeyword = new Recipe[recipeList.Length];
            for(int i = 0; i < recipeSearchByKeyword.Length && recipeList[i] != null ; i++)
            {
                for(int j = 0; j < recipeList[i].Keywords.Length  ; j++)
                {
                    if(recipeList[i].Keywords[j] == keyword)
                    {
                        recipeSearchByKeyword[idx] = recipeList[i];
                        idx++;
                    }
                }
            }
            if (idx > 0)
                return recipeSearchByKeyword;
            else
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
            int idx = 0;
            Recipe[] recipeSearchByCuisine = new Recipe[recipeList.Length];
            for(int i = 0; i < recipeSearchByCuisine.Length && recipeList[i] != null; i++)
            {
                if(recipeList[i].Cuisine == cuisine)
                {
                    recipeSearchByCuisine[idx] = recipeList[i];
                    idx++;
                }
            }
            if (recipeSearchByCuisine[0] != null)
                return recipeSearchByCuisine;
            else
                return null;
        }


        public new string[] ToString()
        {
            string[] RecipeListString = new string[recipeList.Length];
            for(int i = 0; i < RecipeListString.Length && recipeList[i] != null; i++)
            {
                RecipeListString[i] = recipeList[i].title;
            }
            return RecipeListString;
        }
        //List <Recipe> recipeList = new List<Recipe> ();
        //Recipe[] recipeSearchByCuisine = new Recipe[Capacity];
        //Recipe[] LookByKeyword = new Recipe[Capacity];
        //Recipe[] LookByTitle = new Recipe[Capacity];
    }
}
