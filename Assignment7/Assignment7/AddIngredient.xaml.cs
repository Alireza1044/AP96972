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

        private void Unit_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ingUnit = new ComboBox();
        }

        private void IngName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ingName = new TextBox();
        }

        private void IngDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ingDescription = new TextBox();
        }

        private void IngQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ingQuantity = new TextBox();
            //double quantity = double.Parse(ingQuantity.Text);
        }

        private void BtnAddIng_Click(object sender, RoutedEventArgs e)
        {
            ing = new Ingredient(IngName.Text, IngDescription.Text, double.Parse(IngQuantity.Text), IngUnit.Text);
            mw.CloseWindow("Add_Ingredient");
        }

        public Ingredient ingredient
        {
            get
            {
                return ing;
            }
        }
    }
}
