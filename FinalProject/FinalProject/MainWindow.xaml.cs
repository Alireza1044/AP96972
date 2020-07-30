using Business;
using Repository;
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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NoteLogic noteLogic = new NoteLogic();

        public MainWindow()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			UpdateListBox();
        }

        private void AddBtnMain_Click(object sender, RoutedEventArgs e)
        {
            NoteManager nm;
            if (NotesTitlesListBox.SelectedIndex < 0)
            {
                nm = new NoteManager();
            }
            else
            {
                string name = NotesTitlesListBox.SelectedItem.ToString();
                int index = name.IndexOf('>');
                nm = new NoteManager(name.Substring(index + 2));
            }
            this.Close();
            nm.ShowDialog();
            UpdateListBox();
        }

        public void UpdateListBox()
        {
            NotesTitlesListBox.Items.Clear();
            foreach(var n in noteLogic.NotesList())
            {
                NotesTitlesListBox.Items.Add(n.Name.ToString() + " => " + n.ID.ToString());
            }
        }

		private void NoteTitlesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
