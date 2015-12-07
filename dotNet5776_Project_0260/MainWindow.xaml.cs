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
using BE;
using BL;
using System.Threading;

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL Bl_Object = BL.FactoryBL.GetBL();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                Bl_Object.addBranch(new Branch(i+1000009, "Havaad Haleumi " + i % 10, "b" + (i * 3) % 15, 33, "a", 4566576, 5, BE.Hashgacha.Kosher));
            }
            dataGrid.ItemsSource = Bl_Object.GetAllBranch();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = Bl_Object.GetAllBranch();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = Bl_Object.GetAllClients();
        }



        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            
          // MessageBox.Show(e.Column.Header.ToString());
            for (int i = 0; i < Branch.NameOfObjects.Length; i++)
            {
                if (e.Column.Header.ToString() == Branch.NameOfObjects[i])
                {
                    e.Column.Header = Branch.NameOfObjects[i + 1];
                    break;
                }
            }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            //new Thread(() => MessageBox.Show("Pressed")).Start();
        }
    }

}
