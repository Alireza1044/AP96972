using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// یک جزء از ترکیبات دستور غذا
    /// </summary>
    public class Ingredient
    {
        private double quantity;
        private string unit;
        private string name;
        private string description;
        /// <summary>
        /// ایجاد شئ مشخصات یکی از مواد اولیه دستور غذا
        /// </summary>
        /// <param name="name">نام</param>
        /// <param name="description">توضیح</param>
        /// <param name="quantity">مقدار</param>
        /// <param name="unit">واحد مقدار</param>
        public Ingredient(string name, string description, double quantity, string unit)
        {
            // بر عهده دانشجو
            this.unit = unit;
            this.quantity = quantity;
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// نام ماده اولیه
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// توضیح: از کجا پیدا کنیم یا اگر نداشتیم جایگزین چه چیزی استفاده کنیم
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// مقدار
        /// </summary>
        public double Quantity {
            get
            {
                return quantity;
            }
            set
            {
                if(value >= 0)
                {
                    quantity = value;
                }
            }
        }

        /// <summary>
        /// واحد مقدار: مثلا گرم، کیلوگرم، عدد
        /// </summary>
        public string Unit {
            get
            {
                return unit;
            }
            set
            {
                if (value == "kg" || value == "gr" || value == "lbs" || value == "No.")
                    unit = value;
            }
        }

        /// <summary>
        /// تبدیل به متن
        /// </summary>
        /// <returns>متن معادل برای این ماده اولیه - قابل استفاده برای چاپ در خروجی</returns>
        public override string ToString()
        {
            return $"{Name}:\t{Quantity} {Unit} - {Description}";
        }
    }
}
