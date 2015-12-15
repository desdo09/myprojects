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

        enum classes { Branch, Client, Dish, Order, Order_dish };
        classes _current;
        classes Current
        {
            get { return _current; }
            set
            {
                SearchBox.Text = "Search in " + ( (value != classes.Order_dish) ? value.ToString():"Ordered dish");
                _current = value;
                switch (value)
                {
                    case classes.Branch:
                        dataGrid.ItemsSource = Bl_Object.GetAllBranch();
                        break;
                    case classes.Client:
                        dataGrid.ItemsSource = Bl_Object.GetAllClients();
                        break;
                    case classes.Dish:
                        dataGrid.ItemsSource = Bl_Object.GetAllDish();
                        break;
                    case classes.Order:
                        dataGrid.ItemsSource = Bl_Object.GetAllOrders();
                        break;
                    case classes.Order_dish:
                        dataGrid.ItemsSource = Bl_Object.GetAllOrdersDish();
                        break;
                    default:
                        break;
                }
            }
        }
        static IBL Bl_Object = BL.FactoryBL.GetBL();
        public MainWindow()
        {
        
            InitializeComponent();
         
            #region Test Only
            Current = classes.Branch;

            for (int i = 0; i < 100; i++)
            {
                Bl_Object.AddBranch(new Branch(i + 1000009, "Havaad Haleumi " + i % 10, "b" + (i * 3) % 15, 33, "a", 4566576, 5, BE.Hashgacha.Kosher));
            }
            for (int i = 0; i < 40; i++)
            {
                Bl_Object.AddClient(new Client(i + 5900009, "Name " + i % 10, "Havaad Haleumi" + (i * 3) % 150, 33, (i * 482) % 27));
            }

            #endregion

            dataGrid.ItemsSource = Bl_Object.GetAllBranch();
            OrderAdd a = new OrderAdd();
            a.Show();

        }
        #region Main menu click
        private void BranchClick(object sender, RoutedEventArgs e)
        {
            Current = classes.Branch;
         

        }

        private void ClientClick(object sender, RoutedEventArgs e)
        {
            Current = classes.Client;

        }

        private void DishClick(object sender, RoutedEventArgs e)
        {
            Current = classes.Dish;
        }
        private void Ordered_DishClick(object sender, RoutedEventArgs e)
        {
            Current = classes.Order_dish;
        }
        private void OrderClick(object sender, RoutedEventArgs e)
        {
            Current = classes.Order;
        }
        #endregion
        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            switch (Current)
            {
                #region  case classes.Branch:
                case classes.Branch:
                    for (int i = 0; i < Branch.NameOfObjects.Length; i++)
                    {
                        if (e.Column.Header.ToString() == Branch.NameOfObjects[i])
                        {
                            e.Column.Header = Branch.NameOfObjects[i + 1];
                            break;
                        }
                    }
                    break;
                #endregion
                #region  case classes.Client:
                case classes.Client:
                    for (int i = 0; i < Client.NameOfObjects.Length; i++)
                    {
                        if (e.Column.Header.ToString() == Client.NameOfObjects[i])
                        {
                            e.Column.Header = Client.NameOfObjects[i + 1];
                            break;
                        }
                    }
                    break;
                #endregion
                #region case classes.Dish:
                case classes.Dish:
                    break;
                #endregion
                #region  case classes.Order:
                case classes.Order:
                    break;
                #endregion
                #region case classes.Order_dish:
                case classes.Order_dish:
                    break;
                #endregion
                default:
                    break;
            }




        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            // new Thread(() => MessageBox.Show("Pressed")).Start();
        }
        private void Branch_button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = Bl_Object.GetAllClients();
        }
        #region AddButtons
        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            switch (Current)
            {
                case classes.Branch:
                    BranchAdd a = new BranchAdd();
                    a.Show();
                    break;
                case classes.Client:
                    break;
                case classes.Dish:
                    break;
                case classes.Order:
                    break;
                case classes.Order_dish:
                    break;
                default:
                    break;
            }

        }
        #endregion
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }


    }

}
