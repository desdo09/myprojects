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
                Bl_Object.addBranch(new Branch(i + 1000009, "Havaad Haleumi " + i % 10, "b" + (i * 3) % 15, 33, "a", 4566576, 5, BE.Hashgacha.Kosher));
            }
            //for (int i = 0; i < 40; i++)
            //{
            //    Bl_Object.addClient(new Client(i + 5900009, "Name " + i % 10, "Havaad Haleumi" + (i * 3) % 150, 33, (i*482)%27));
            //}
            SearchBox.Text = "Search branch";
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


            if ((dataGrid.ItemsSource.ToString()).Contains("Branch"))
                for (int i = 0; i < Branch.NameOfObjects.Length; i++)
                {
                    if (e.Column.Header.ToString() == Branch.NameOfObjects[i])
                    {
                        e.Column.Header = Branch.NameOfObjects[i + 1];
                        break;
                    }
                }
            if ((dataGrid.ItemsSource.ToString()).Contains("Client"))
                for (int i = 0; i < Client.NameOfObjects.Length; i++)
                {
                    if (e.Column.Header.ToString() == Client.NameOfObjects[i])
                    {
                        e.Column.Header = Client.NameOfObjects[i + 1];
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
