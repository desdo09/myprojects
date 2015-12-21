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
        
        #region Objects
        enum classes { Branch, Client, Dish, Order, Order_dish };
        classes _current;
        classes Current
        {
            get { return _current; }
            set
            {
                switch (Current)
                {
                    case classes.Branch:
                        Branch_button_image_selected.Visibility = Visibility.Collapsed;
                        Branch_button_image.Visibility = Visibility.Visible;
                        break;
                    case classes.Client:
                        Clients_button_image.Visibility = Visibility.Visible;
                        Clients_button_image_selected.Visibility = Visibility.Collapsed;
                        break;
                    case classes.Dish:
                        Dish_button_image.Visibility = Visibility.Visible;
                        Dish_button_image_selected.Visibility = Visibility.Collapsed;
                        break;
                    case classes.Order:
                        Order_button_image.Visibility = Visibility.Visible;
                        Order_button_image_selected.Visibility = Visibility.Collapsed;
                        break;
                    case classes.Order_dish:
                        DishOrders_button_image.Visibility = Visibility.Visible;
                        DishOrders_button_image_selected.Visibility = Visibility.Collapsed;
                        break;
                    default:
                        break;
                }

                SearchBox.Text = "Search in " + ((value != classes.Order_dish) ? value.ToString() : "Ordered dish");
                _current = value;
                switch (value)
                {
                    case classes.Branch:
                        dataGrid.ItemsSource = Bl_Object.GetAllBranch();
                        Branch_button_image.Visibility = Visibility.Collapsed;
                        Branch_button_image_selected.Visibility = Visibility.Visible;
                        break;
                    case classes.Client:
                        dataGrid.ItemsSource = Bl_Object.GetAllClients();
                        Clients_button_image.Visibility = Visibility.Collapsed;
                        Clients_button_image_selected.Visibility = Visibility.Visible;
                        break;
                    case classes.Dish:
                        dataGrid.ItemsSource = Bl_Object.GetAllDish();
                        Dish_button_image.Visibility = Visibility.Collapsed;
                        Dish_button_image_selected.Visibility = Visibility.Visible;
                        break;
                    case classes.Order:
                        dataGrid.ItemsSource = Bl_Object.GetAllOrders();
                        Order_button_image.Visibility = Visibility.Collapsed;
                        Order_button_image_selected.Visibility = Visibility.Visible;
                        break;
                    case classes.Order_dish:
                        dataGrid.ItemsSource = Bl_Object.GetAllOrdersDish();
                        DishOrders_button_image.Visibility = Visibility.Collapsed;
                        DishOrders_button_image_selected.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }
            }
        }
        static IBL Bl_Object = BL.FactoryBL.GetBL();
        #endregion
        public MainWindow()
        {

            InitializeComponent();
            AddDish aa = new AddDish();
            aa.Show();
            #region Test Only
            Current = classes.Order;

            for (int i = 0; i < 100; i++)
            {
                Bl_Object.AddBranch(new Branch(i + 1000009, "Havaad Haleumi " + i % 10, "b" + (i * 3) % 15, 33, "a", 4566576, 5, Hashgacha.Kosher));
            }
            for (int i = 0; i < 40; i++)
            {
                Bl_Object.AddClient(new Client(i + 509, "Name " + i % 10, "Havaad Haleumi" + (i * 3) % 150, 33, (i * 482) % 27, 22));
            }
            for (int i = 0; i < 40; i++)
            {
                Bl_Object.AddDish(new Dish(i, "aa", (float)1.5, 20, (Hashgacha)(i%4)));
            }


            #endregion

            dataGrid.ItemsSource = Bl_Object.GetAllBranch();
           

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
                    BranchAdd B = new BranchAdd();
                    B.Show();
                    break;
                case classes.Client:
                    break;
                case classes.Dish:
                    break;
                case classes.Order:
                    OrderAdd O = new OrderAdd();
                    O.Show();
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
