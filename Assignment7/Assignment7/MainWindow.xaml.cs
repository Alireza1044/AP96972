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
        Recipe[] recipes;
        private const string recipeFilePath = @"recipes.txt";
        private const string ingredientFilePath = @"ingredients.txt";
        public MainWindow()
        {
            InitializeComponent();
            recipes = new Recipe[recipeBook.Capacity];
        }

        public bool WindowsIsOpen(string windowName)
        {
            foreach(Window w in App.Current.Windows)
            {
                if (w.Name == windowName)
                    return true;
            }
            return false;
        }

        public void CloseWindow(string windowName)
        {
            foreach(Window w in App.Current.Windows)
            {
                if (w.Name == windowName)
                    w.Close();
            }
        }

        public void ListBoxReset()
        {
            RecipeListBox.Items.Clear();
            for (int i = 0; i < recipeBook.Capacity; i++)
            {
                ListBoxItem item = new ListBoxItem();
                //item.Content = $"دستور غذای شماره {i+1}";
                if (recipes[i] != null)
                {
                    item.Content = recipes[i].title;
                    RecipeListBox.Items.Add(item);
                }
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            //recipes = new Recipe[recipeBook.Capacity];
            RecipeForm frm = new RecipeForm();
            frm.ShowDialog();
            recipes[i] = frm.recipes;
            recipeBook.Add(recipes[i]);
            i++;
            if (!WindowsIsOpen("Add_Recipe"))
            {
                ListBoxReset();
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //string loadFileName = null;
            //openFileDialog.ShowDialog();
            //loadFileName = openFileDialog.FileName;
            recipeBook.Load(recipeFilePath, ingredientFilePath);
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            string ListBoxValue = ((ListBoxItem)RecipeListBox.SelectedItem).Content.ToString();
            string keywords = null;
            for (int i =0;i<recipeBook.Capacity && recipes[i] != null; i++)
            {
                if (ListBoxValue == recipes[i].title)
                {
                    for (int j = 0; j < recipes[i].Keywords.Length && recipes[i].Keywords[j] != null && recipes[i] != null; j++)
                    {
                        keywords = keywords + "\n "+ recipes[i].Keywords[j];
                    }
                    MessageBox.Show("Name: " + recipes[i].title + "\nServing Count: " + recipes[i].ServingCount + "\nKeywords: " + keywords + "\nInstructions: " + recipes[i].Instructions);
                    break;
                }
            }
        }

        private void SearchKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            RecipeListBox.Items.Clear();
            switch (SearchKind.Text)
            {
                case "Title":
                    ListBoxItem item = new ListBoxItem();
                    item.Content = recipeBook.LookupByTitle(SearchTextBox.Text).title;
                    RecipeListBox.Items.Add(item);
                    break;

                case "Keyword":
                    Recipe[] recipeSearchByKeyword;
                    recipeSearchByKeyword = recipeBook.LookupByKeyword(SearchTextBox.Text);
                    for(int i =0;i<recipeSearchByKeyword.Length && recipeSearchByKeyword[i] != null; i++)
                    {
                        ListBoxItem items = new ListBoxItem();
                        items.Content = recipeSearchByKeyword[i].title;
                        RecipeListBox.Items.Add(items);
                    }
                    break;

                case "Cuisine":
                    Recipe[] recipeSearchByCuisine;
                    recipeSearchByCuisine = recipeBook.LookupByCuisine(SearchTextBox.Text);
                    for(int i = 0;i<recipeSearchByCuisine.Length && recipeSearchByCuisine[i] != null; i++)
                    {
                        ListBoxItem items = new ListBoxItem();
                        items.Content = recipeSearchByCuisine[i].title;
                        RecipeListBox.Items.Add(items);
                    }
                    break;
                default:
                    break;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            string ListBoxValue =  ((ListBoxItem)RecipeListBox.SelectedItem).Content.ToString();
            for (int i = 0; i < recipeBook.Capacity && recipes[i] != null; i++)
            {
                if (ListBoxValue == recipes[i].title)
                {
                    flag = recipeBook.Remove(recipes[i].title);
                    recipes[i] = null;
                    ListBoxReset();
                    if (flag)
                        MessageBox.Show("Deleted successfully!");
                    else
                        MessageBox.Show("Failed to delete!");
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            recipeBook.Save(recipeFilePath, ingredientFilePath);
        }
    }
}
