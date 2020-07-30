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

namespace FinalProject
{
	/// <summary>
	/// Interaction logic for ColorChange.xaml
	/// </summary>
	public partial class ColorChange : Window
	{
		public ColorChange()
		{
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
		}

		private void Blue_Click(object sender, RoutedEventArgs e)
		{
			//MainWindow mw = new MainWindow();
			BrushConverter bc = new BrushConverter();
			NoteManager nm = new NoteManager();
			Brush brush = (Brush)bc.ConvertFrom("#FF3BC5CC");
			brush.Freeze();
			Brush brush1 = (Brush)bc.ConvertFrom("#FF0051FF");
			brush.Freeze();
			this.Background = brush;
			this.Foreground = brush1;
			this.Close();
		}

		private void Red_Click(object sender, RoutedEventArgs e)
		{
			//MainWindow mw = new MainWindow();
			BrushConverter bc = new BrushConverter();
			NoteManager nm = new NoteManager();
			Brush brush = (Brush)bc.ConvertFrom("#FFCA1F1F");
			brush.Freeze();
			Brush brush1 = (Brush)bc.ConvertFrom("#961919");
			brush.Freeze();
			this.Background = brush;
			this.Foreground = brush1;
			this.Close();

		}

		private void Green_Click(object sender, RoutedEventArgs e)
		{
			//MainWindow mw = new MainWindow();
			BrushConverter bc = new BrushConverter();
			NoteManager nm = new NoteManager();
			Brush brush = (Brush)bc.ConvertFrom("#FF3ED01E");
			brush.Freeze();
			Brush brush1 = (Brush)bc.ConvertFrom("#1E8402");
			brush.Freeze();
			this.Background = brush;
			this.Foreground = brush1;
			this.Close();
		}

		private void Pink_Click(object sender, RoutedEventArgs e)
		{
			//MainWindow mw = new MainWindow();
			BrushConverter bc = new BrushConverter();
			NoteManager nm = new NoteManager();
			Brush brush = (Brush)bc.ConvertFrom("#FFB90ECF");
			brush.Freeze();
			Brush brush1 = (Brush)bc.ConvertFrom("#710378");
			brush.Freeze();
			this.Background = brush;
			this.Foreground = brush1;
			this.Close();
		}

		private void Orange_Click(object sender, RoutedEventArgs e)
		{
			//MainWindow mw = new MainWindow();
			BrushConverter bc = new BrushConverter();
			NoteManager nm = new NoteManager();
			Brush brush = (Brush)bc.ConvertFrom("#FFD68C16");
			brush.Freeze();
			Brush brush1 = (Brush)bc.ConvertFrom("#8C5F00");
			brush.Freeze();
			this.Background = brush;
			this.Foreground = brush1;
			this.Close();
		}

		private void DarkGreen_Click(object sender, RoutedEventArgs e)
		{
			//MainWindow mw = new MainWindow();
			BrushConverter bc = new BrushConverter();
			NoteManager nm = new NoteManager();
			Brush brush = (Brush)bc.ConvertFrom("#FF14551D");
			brush.Freeze();
			Brush brush1 = (Brush)bc.ConvertFrom("#072500");
			brush.Freeze();
			this.Background = brush;
			this.Foreground = brush1;
			this.Close();
		}
	}
}
