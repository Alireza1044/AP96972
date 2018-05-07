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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment5;

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        RecipeBook recipeBook = new RecipeBook("reBook", 20);
        List<Recipe> recipes;
        //private const string recipeFilePath = @"recipes.txt";
        //private const string ingredientFilePath = @"ingredients.txt";
        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>(recipeBook.Capacity);
        }

        /// <summary>
        /// checks if a window is open
        /// </summary>
        /// <param name="windowName"></param>
        /// <returns> false if not open and true if is open </returns>
        public bool WindowsIsOpen(string windowName)
        {
            foreach (Window w in App.Current.Windows)
            {
                if (w.Name == windowName)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// closes the window
        /// </summary>
        /// <param name="windowName"></param>
        public void CloseWindow(string windowName)
        {
            foreach (Window w in App.Current.Windows)
            {
                if (w.Name == windowName)
                    w.Close();
            }
        }

        /// <summary>
        /// shows the recipes
        /// </summary>
        public void ListBoxReset()
        {
            RecipeListBox.Items.Clear();
            for (int i = 0; i < recipes.Count && recipes[i] != null; i++)
            {
                ListBoxItem item = new ListBoxItem();
                //item.Content = $"دستور غذای شماره {i+1}";
                item.Content = recipes[i].Title;
                RecipeListBox.Items.Add(item);
            }
        }

        /// <summary>
        /// creates a new recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            RecipeForm frm = new RecipeForm();
            frm.ShowDialog();
            recipes.Add(frm.recipes);
            recipeBook.Add(recipes[i]);
            i++;
            if (!WindowsIsOpen("Add_Recipe"))
            {
                ListBoxReset();
            }
        }

        /// <summary>
        /// loads all the recipes if there is a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string recipeFilePath = null;
            string ingredientFilePath = null;
            if (openFileDialog.ShowDialog().Value)
            {
                recipeFilePath = openFileDialog.FileName;
                if (openFileDialog1.ShowDialog().Value)
                {
                    ingredientFilePath = openFileDialog1.FileName;
                }
                recipeBook.Load(recipeFilePath, ingredientFilePath);
            }
            foreach (var r in recipeBook.recipeList)
            recipes.Add(r);
            ListBoxReset();
        }

        /// <summary>
        /// shows some info of the selected recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ListBoxValue = ((ListBoxItem)RecipeListBox.SelectedItem).Content.ToString();
                string keywords = null;
                for (int i = 0; i < recipes.Count && recipes[i] != null; i++)
                {
                    if (ListBoxValue == recipes[i].Title)
                    {
                        for (int j = 0; j < recipes[i].Keywords.Length && recipes[i].Keywords[j] != null && recipes[i] != null; j++)
                        {
                            keywords = keywords + "\n " + recipes[i].Keywords[j];
                        }
                        MessageBox.Show("Name: " + recipes[i].Title + "\nServing Count: " + recipes[i].ServingCount + "\nKeywords: " + keywords + "\nInstructions: " + recipes[i].Instructions);
                        break;
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select an item!");
            }
        }

        //private void SearchKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}


        /// <summary>
        /// searches in recipes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (SearchKind.Text)
                {
                    case "Title":
                        RecipeListBox.Items.Clear();
                        ListBoxItem item = new ListBoxItem();
                        item.Content = recipeBook.LookupByTitle(SearchTextBox.Text).Title;
                        RecipeListBox.Items.Add(item);
                        break;

                    case "Keyword":
                        RecipeListBox.Items.Clear();
                        Recipe[] recipeSearchByKeyword;
                        recipeSearchByKeyword = recipeBook.LookupByKeyword(SearchTextBox.Text);
                        for (int i = 0; i < recipeSearchByKeyword.Length && recipeSearchByKeyword[i] != null; i++)
                        {
                            ListBoxItem items = new ListBoxItem();
                            items.Content = recipeSearchByKeyword[i].Title;
                            RecipeListBox.Items.Add(items);
                        }
                        break;

                    case "Cuisine":
                        RecipeListBox.Items.Clear();
                        Recipe[] recipeSearchByCuisine;
                        recipeSearchByCuisine = recipeBook.LookupByCuisine(SearchTextBox.Text);
                        for (int i = 0; i < recipeSearchByCuisine.Length && recipeSearchByCuisine[i] != null; i++)
                        {
                            ListBoxItem items = new ListBoxItem();
                            items.Content = recipeSearchByCuisine[i].Title;
                            RecipeListBox.Items.Add(items);
                        }
                        break;
                    default:
                        MessageBox.Show("How do you want to search?");
                        break;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please try again!");
            }
        }

        /// <summary>
        /// removes the selected recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            string ListBoxValue = ((ListBoxItem)RecipeListBox.SelectedItem).Content.ToString();
            for (int i = 0; i < recipes.Count && recipes[i] != null; i++)
            {
                if (ListBoxValue == recipes[i].Title)
                {
                    flag = recipeBook.Remove(recipes[i].Title);
                    recipes.RemoveAt(i);
                    if (flag)
                        MessageBox.Show("Deleted successfully!");
                    else
                        MessageBox.Show("Failed to delete!");
                    break;
                }
            }
            ListBoxReset();
        }

        /// <summary>
        /// saves all the recipes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveFileDialog SaveDialog1 = new SaveFileDialog();
            string recipeFilePath = null;
            string ingredientFilePath = null;
            if (SaveDialog.ShowDialog().Value)
            {
                recipeFilePath = SaveDialog.FileName;
                if (SaveDialog1.ShowDialog().Value)
                {
                    ingredientFilePath = SaveDialog1.FileName;
                }
                recipeBook.Save(recipeFilePath, ingredientFilePath);
            }
        }
    }
}
