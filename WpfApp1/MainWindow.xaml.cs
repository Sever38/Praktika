﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.VIew;
using WpfApp1.ViewModel;

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		
		public MainWindow()
		{
			InitializeComponent();
		}

		private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SoftwareView soft = new SoftwareView();
			soft.Show();
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
