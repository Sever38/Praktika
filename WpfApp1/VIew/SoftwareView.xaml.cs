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

namespace WpfApp1.VIew
{
	/// <summary>
	/// Логика взаимодействия для SoftwareView.xaml
	/// </summary>
	public partial class SoftwareView : Window
	{
		public SoftwareView()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MainWindow main = new MainWindow();
			main.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			InstalledSoftwareView soft = new InstalledSoftwareView();
			soft.Show();
			this.Close();
		}
	}
}
