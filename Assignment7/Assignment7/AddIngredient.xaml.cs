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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mw = new MainWindow();
        public Window1()
        {
            InitializeComponent();
        }

        Ingredient ing;

        /// <summary>
        /// a combobox to select allowed units
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Unit_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ingUnit = new ComboBox();
        }

        /// <summary>
        /// name of the ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IngName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ingName = new TextBox();
        }

        /// <summary>
        /// description of the ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IngDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ingDescription = new TextBox();
        }

        /// <summary>
        /// quantity of the ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IngQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ingQuantity = new TextBox();
        }

        /// <summary>
        /// adds the ingredient and closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddIng_Click(object sender, RoutedEventArgs e)
        {
            ing = new Ingredient(IngName.Text, IngDescription.Text, double.Parse(IngQuantity.Text), IngUnit.Text);
            mw.CloseWindow("Add_Ingredient");
        }

        /// <summary>
        /// public field for ingredient
        /// </summary>
        public Ingredient ingredient
        {
            get
            {
                return ing;
            }
        }

        private void BtnCnclIng_Click(object sender, RoutedEventArgs e)
        {
            mw.CloseWindow("Add_Ingredient");
        }
    }
}
