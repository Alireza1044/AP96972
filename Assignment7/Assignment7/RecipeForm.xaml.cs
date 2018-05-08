using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Assignment5;

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for RecipeForm.xaml
    /// </summary>
    public partial class RecipeForm : Window
    {
        MainWindow mw = new MainWindow();
        Recipe recipe;
        List<Ingredient> ingredients = new List<Ingredient>();
        public RecipeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// shows the ingredients in the listbox
        /// </summary>
        public void ListBoxReset()
        {
            IngredientsListBox.Items.Clear();
            for (int i = 0; i < ingredients.Count && ingredients[i] != null; i++)
            {
                ListBoxItem item = new ListBoxItem();
                //item.Content = $"دستور غذای شماره {i+1}";
                if (ingredients[i] != null)
                {
                    item.Content = ingredients[i].Name;
                    IngredientsListBox.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// creates a new ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            Window1 frm = new Window1();
            frm.ShowDialog();
            //if(ingredients[i] == null)
            ingredients.Add(frm.ingredient);
            if (!mw.WindowsIsOpen("Add_Ingredient"))
            {
                ListBoxReset();
            }
        }

        /// <summary>
        /// creates the recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecipeConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] keywords = RecipeKeywords.Text.Split();
                recipe = new Recipe(RecipeName.Text, RecipeInstructions.Text, ingredients,
                    int.Parse(RecipeServingCount.Text), RecipeCuisine.Text, keywords);
                mw.CloseWindow("Add_Recipe");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please fill all the fields!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill all the fields!");
            }
        }

        /// <summary>
        /// public field for recipe
        /// </summary>
        public Recipe recipes
        {
            get
            {
                return recipe;
            }
            set
            {
                recipe = value;
            }
        }

        /// <summary>
        /// removes the selected ingredient from recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            string ListBoxValue = ((ListBoxItem)IngredientsListBox.SelectedItem).Content.ToString();
            for (int i = 0; i < ingredients.Count && ingredients[i] !=null; i++)
            {
                if (ListBoxValue == ingredients[i].Name)
                {
                    for (int j = i; j < ingredients.Count && ingredients[j] != null; j++)
                    {
                        ingredients[j] = ingredients[j + 1];
                    }
                }
            }
            ListBoxReset();
        }

        /// <summary>
        /// shows some info of the selected ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            string ListBoxValue = ((ListBoxItem)IngredientsListBox.SelectedItem).Content.ToString();
            if (ListBoxValue == null)
            {
                MessageBox.Show("Please select an ingredient!");
            }
            else
            {
                for (int i = 0; i < ingredients.Count && ingredients[i] != null; i++)
                {
                    if (ListBoxValue == ingredients[i].Name)
                    {
                        MessageBox.Show("Name: " + ingredients[i].Name + "\nDescription: "
                            + ingredients[i].Description + "\nQuantity: " + ingredients[i].Quantity
                            + "\nUnit: " + ingredients[i].Unit);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mw.CloseWindow("Add_Recipe");
        }
    }
}
