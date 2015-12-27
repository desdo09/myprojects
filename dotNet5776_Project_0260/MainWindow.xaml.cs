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
using System.ComponentModel;

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Objects
        /// <summary>
        /// function to get changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        void propertychanged(object sender, PropertyChangedEventArgs ev)
        {
            dataGrid.Items.Refresh();
        }
        /// <summary>
        /// Classes enum to know the current class
        /// </summary>
        enum classes { Branch, Client, Dish, Order, Order_dish };
        /// <summary>
        /// Classes (enum) object to save the current class
        /// </summary>
        classes _current;
        /// <summary>
        /// Current object propriety
        /// The propriety will change:
        /// 1. Image to current place
        /// 2. Change datagrid source
        /// </summary>
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
        //BL object
        static IBL Bl_Object = FactoryBL.GetBL();
        #endregion
        public MainWindow()
        {

            InitializeComponent();
            //Set start class
            Current = classes.Order;

            #region Test Only

            for (int i = 0; i < 100; i++)
            {
                Bl_Object.AddBranch(new Branch(i + 1000009, "Havaad Haleumi " + i % 10, "b" + (i * 3) % 15, 33, "a", 4566576, 5, Hashgacha.Kosher));
            }
            Bl_Object.DeleteBranch(1000009);
            for (int i = 0; i < 40; i++)
            {
                Bl_Object.AddClient(new Client(i + 509, "Name " + i % 10, "Havaad Haleumi" + (i * 3) % 150, "4998774833737162", (i * 482) % 27, 22));
            }

            for (int i = 0; i < 40; i++)
            {
                Bl_Object.AddDish(new Dish(i, "aa", (float)1.5, 20, (Hashgacha)(i % 4)));
            }


            #endregion

            //UserPrint a = new UserPrint(new Client(509, "Desdo Hambres ", "Havaad Haleumi 21", "4998774833737162", 0584160414, 22));
            //a.Show();

        }
        /// <summary>
        /// The function will verify how is the current class and change the datagrid header name.
        /// </summary>
        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //switch to know how is the current
            switch (Current)
            {
                #region  case classes.Branch:
                // All classes have an array with the Propriety name NameOfObjects[i] and what is reference NameOfObjects[i+1]
                // So the function will get the current name in header then a loop will search the reference
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
        #region Main menu click
        //function to change the current class when is clicked

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
        /// <summary>
        /// Search function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            // new Thread(() => MessageBox.Show("Pressed")).Start();
        }
        #region Buttons
        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            switch (Current)
            {
                case classes.Branch:
                    BranchAdd B = new BranchAdd();
                    B.PropertyChanged += propertychanged;
                    B.Show();
                    break;
                case classes.Client:
                    break;
                case classes.Dish:
                    AddDish D = new AddDish();
                    D.Show();
                    break;
                case classes.Order:
                    OrderAdd O = new OrderAdd();
                    O.Show();
                    break;
                case classes.Order_dish:
                    MessageBox.Show("Dish order can not insert a new row or changes\nTo change, please go to Order");
                    break;
                default:
                    break;
            }

        }
        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by David Aben-Athar & David Uzan\nAll Copyright © 2015\nVersion 1.0", "About");
        }
        #endregion
        #region Print functions
        private void Print_button_Click(object sender, RoutedEventArgs e)
        {
            PrintGrid(dataGrid, Current.ToString());
        }
        public void PrintGrid(object param, string name)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == false)
                return;
            Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
            CustomDataGridDocumentPaginator paginator = new CustomDataGridDocumentPaginator(param as DataGrid, name, pageSize, new Thickness(30, 20, 30, 20));
            printDialog.PrintDocument(paginator, name);
        }
        #endregion
        private void Remove_Click(object sender, RoutedEventArgs e)
        {


            int id = 0;

            string IdsDeleted = "";

            int size = dataGrid.SelectedCells.Count / dataGrid.Columns.Count;

            if (size == 0)
            {
                MessageBox.Show("No item selected!", "Delete item", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }

            if (size > 1)
                MessageBox.Show("Can not delete more than one item", "Delete item", MessageBoxButton.OK, MessageBoxImage.Hand);


            try
            {
                for (int i = 0; i < 1; i++)
                {
                    switch (Current)
                    {
                        case classes.Branch:
                            var BranchToDelete = (Branch)dataGrid.SelectedCells[0].Item;
                            id = BranchToDelete.BranchId;
                            if (MessageBox.Show("Are you sure you want to delete Branch id " + id + " ?\nPress no to cancel", "Delete items", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                return;
                            Bl_Object.DeleteBranch(id);
                            break;
                        case classes.Client:
                            var ClientToDelete = (Client)dataGrid.SelectedCells[0].Item;
                            id = ClientToDelete.ClientId;
                            if (MessageBox.Show("Are you sure you want to delete Client id " + id + " ?\nPress no to cancel", "Delete items", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                return;
                            Bl_Object.DeleteClient(id);
                            break;
                        case classes.Dish:
                            var DishToDelete = (Dish)dataGrid.SelectedCells[0].Item;
                            id = DishToDelete.DishId;
                            if (MessageBox.Show("Are you sure you want to delete Dish id " + id + " ?\nPress no to cancel", "Delete items", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                return;
                            Bl_Object.DeleteDish(id);
                            break;
                        case classes.Order:
                            var OrderToDelete = (Order)dataGrid.SelectedCells[0].Item;
                            id = OrderToDelete.OrderId;
                            if (MessageBox.Show("Are you sure you want to delete Order id " + id + " ?\nPress no to cancel", "Delete items", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                return;
                            Bl_Object.DeleteOrder(id);
                            break;
                        case classes.Order_dish:
                            var Order_dishToDelete = (Ordered_Dish)dataGrid.SelectedCells[0].Item;
                            id = Order_dishToDelete.Ordered_DishId;
                            if (MessageBox.Show("Are you sure you want to delete Order dish id " + id + " ?\nPress no to cancel", "Delete items", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                                return;
                            Bl_Object.DeleteOrdered_Dish(id);
                            break;
                        default:
                            break;
                    }
                    IdsDeleted += id.ToString() + " ";
                }
                dataGrid.Items.Refresh();
                MessageBox.Show("Id: " + IdsDeleted + " deleted!");
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(IdsDeleted))
                    MessageBox.Show("Error: " + ex.HResult.ToString() + "\nNo items removed ");
                else
                    MessageBox.Show("Error: " + ex.HResult.ToString() + "\nThe " + IdsDeleted + "are removed ");

            }




        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {

            int size = dataGrid.SelectedCells.Count / dataGrid.Columns.Count;
            if (size == 0)
                return;

            string ToPrint = "";

            Label temp = new Label();
            temp.Content = dataGrid.SelectedCells[0].Item;

            for (int i = 0; i < size; i++)
            {
                ToPrint += dataGrid.SelectedCells[0].Item;
                ToPrint += "\n\n\n";
            }

            temp.Content = ToPrint;
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(temp, "Window Printing.");

        }
    }

}
