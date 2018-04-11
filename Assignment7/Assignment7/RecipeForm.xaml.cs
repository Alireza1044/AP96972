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
        Ingredient[] ingredients = new Ingredient[5];
        int i = 0;
        public RecipeForm()
        {
            InitializeComponent();
        }

        public  void ListBoxReset()
        {
            IngredientsListBox.Items.Clear();
            for (int i = 0; i < ingredients.Length && ingredients[i] != null; i++)
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

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            Window1 frm = new Window1();
            frm.ShowDialog();
            //if(ingredients[i] == null)
            ingredients[i] = frm.ingredient;
            i++;
            if (!mw.WindowsIsOpen("Add_Ingredient"))
            {
                ListBoxReset();
            }
        }

        private void RecipeConfirm_Click(object sender, RoutedEventArgs e)
        {
            string[] keywords = RecipeKeywords.Text.Split();
            recipe = new Recipe(RecipeName.Text,RecipeInstructions.Text, ingredients, int.Parse(RecipeServingCount.Text), RecipeCuisine.Text, keywords);
            mw.CloseWindow("Add_Recipe");
        }

        public Recipe recipes
        {
            get
            {
                return recipe;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            string ListBoxValue = ((ListBoxItem)IngredientsListBox.SelectedItem).Content.ToString();
            for (int i = 0; i < ingredients.Length && ingredients[i] !=null; i++)
            {
                if (ListBoxValue == ingredients[i].Name)
                {
                    for (int j = i; j < ingredients.Length && ingredients[i] != null; j++)
                {
                        ingredients[i] = ingredients[j + 1];
                        break;
                    }
                }
            }
            ListBoxReset();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            string ListBoxValue = ((ListBoxItem)IngredientsListBox.SelectedItem).Content.ToString();
            for(int i =0;i<ingredients.Length && ingredients[i] != null; i++)
            {
                if(ListBoxValue == ingredients[i].Name)
                {
                    MessageBox.Show("Name: " + ingredients[i].Name + "\nDescription: "
                        + ingredients[i].Description + "\nQuantity: " + ingredients[i].Quantity
                        + "\nUnit: " + ingredients[i].Unit);
                }
            }
        }
    }
}
