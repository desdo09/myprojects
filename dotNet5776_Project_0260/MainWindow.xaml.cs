using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BE;
using BL;
using System.ComponentModel;

namespace dotNet5776_Project_0260
{

    /// <summary>
    /// Classes enum to know the current class
    /// </summary>
    public enum classes { Branch, Client, Dish, Order, Order_dish };

    public partial class MainWindow : Window
    {

        #region Objects



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


                SearchBox.Text = "Search in " + ((value != classes.Order_dish) ? value.ToString() : "Ordered dish");
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
        //BL object
        static IBL Bl_Object = FactoryBL.GetBL();

        #endregion
        public MainWindow()
        {



            #region Test Only

            try
            {
                for (int i = 0; i < 100; i++)
                {
           //         Bl_Object.AddBranch(new Branch(i + 1000009, "Branch " + i, "Havaad Haleumi " + i % 10, "02-645-1000" + i, "a", 4566576, 5, Hashgacha.Kosher));
                }
            //    Bl_Object.DeleteBranch(1000009);
                for (int i = 0; i < 40; i++)
                {
           //         Bl_Object.AddClient(new Client(i + 509, "Name " + i % 10, "Havaad Haleumi" + (i * 3) % 150, "4998774833737162+", (i * 482) % 27, 22));
                }

                for (int i = 0; i < 40; i++)
                {
         //          Bl_Object.AddDish(new Dish(i, "Dish " + i, (Dish.size)(i % 3), 20 * i, (Hashgacha)(i % 4)));
                }
                for (int i = 0; i < 100; i++)
                {
         //          Bl_Object.AddOrder(new Order(i, DateTime.Now, 1000009 + i, Hashgacha.Kosher, i % 4 + 509, i % 8 * 10, " "), new List<Ordered_Dish>());
                }
                for (int i = 0; i < 100; i++)
                {
          //          Bl_Object.AddOrdered_Dish(new Ordered_Dish(i, i % 30, i % 9, i % 4 * 2 + 1));
                }
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show("Constructor error:\n" + ex.GetType() + ": " + ex.Message);
            }
            #endregion
            DataContext = this;
            InitializeComponent();
            OrderClick();
            BranchBox.ItemsSource = Bl_Object.GetAllBranch();
            BranchBox.DisplayMemberPath = "BranchName";
            BranchBox.SelectedValuePath = "BranchId";
            BranchBox.SelectedIndex = 0;



        }//ctor

        /// <summary>
        /// The function will verify how is the current class and change the datagrid header name.
        /// </summary>
        #region Main menu click
        //function to change the current class when is clicked

        #region Click Functions
        private void BranchClick(object sender, RoutedEventArgs e)
        {
            BranchCheck.IsChecked = true;
            Current = classes.Branch;


        }
        private void ClientClick(object sender, RoutedEventArgs e)
        {
            Current = classes.Client;
            ClientCheck.IsChecked = true;
        }

        private void DishClick(object sender, RoutedEventArgs e)
        {
            DishCheck.IsChecked = true;
            Current = classes.Dish;
        }
        private void Ordered_DishClick(object sender, RoutedEventArgs e)
        {
            ODCheck.IsChecked = true;
            Current = classes.Order_dish;

        }
        private void OrderClick(object sender = null, RoutedEventArgs e = null)
        {
            OrderCheck.IsChecked = true;
            Current = classes.Order;

        }
        #endregion
        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (Current)
                {
                    case classes.Branch:

                        Branch ToUpdate = dataGrid.SelectedCells[0].Item as Branch;
                        BranchAdd B = new BranchAdd(Bl_Object.SearchBranchById(ToUpdate.BranchId));
                        B.PropertyChanged += propertychanged;
                        B.Show();
                        break;
                    case classes.Client:
                        Client ClientToUpdate = dataGrid.SelectedCells[0].Item as Client;
                        ClientAdd cl = new ClientAdd(ClientToUpdate);
                        cl.PropertyChanged += propertychanged;
                        cl.Show();
                        break;
                    case classes.Dish:
                        Dish DishToUpdate = dataGrid.SelectedCells[0].Item as Dish;
                        AddDish D = new AddDish(DishToUpdate);
                        D.PropertyChanged += propertychanged;
                        D.Show();
                        break;
                    case classes.Order:
                        Order OrderToUpdate = dataGrid.SelectedCells[0].Item as Order;
                        OrderAdd O = new OrderAdd(OrderToUpdate);
                        O.PropertyChanged += propertychanged;
                        O.Show();
                        break;
                    case classes.Order_dish:
                        MessageBox.Show("Dish order can not insert a new row or changes\nTo change, please go to Order");
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Please select a item");
            }

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ClientReport_Click(object sender, RoutedEventArgs e)
        {
            Report a = new Report(classes.Client);
            a.Show();
        }

        private void DishReport_Click(object sender, RoutedEventArgs e)
        {
            Report a = new Report(classes.Dish);
            a.Show();
        }
        #endregion
        /// <summary>
        /// Search function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    ClientAdd cl = new ClientAdd();
                    cl.PropertyChanged += propertychanged;
                    cl.Show();
                    
                    break;
                case classes.Dish:

                    AddDish D = new AddDish();
                    D.PropertyChanged += propertychanged;
                    D.Show();
                    break;
                case classes.Order:
                    OrderAdd O = new OrderAdd();
                    O.PropertyChanged += propertychanged;
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
        #region Other functions
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            // new Thread(() => MessageBox.Show("Pressed")).Start();
        }
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
                propertychanged(null,null);
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(IdsDeleted))
                    MessageBox.Show("Error: " + ex.HResult.ToString() + "\nNo items removed ");
                else
                    MessageBox.Show("Error: " + ex.HResult.ToString() + "\nThe " + IdsDeleted + "are removed ");

            }




        }
        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Width = new DataGridLength(2.0, DataGridLengthUnitType.Star);
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


        /// <summary>
        /// function to get changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        void propertychanged(object sender, PropertyChangedEventArgs ev)
        {
          // dataGrid.ItemsSource = null;
            
            Current = _current;
        }
        #endregion
    }


    #region Converter functions to wpf

    /// <summary>
    /// When is true, is visible
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }


        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }
    }
    /// <summary>
    /// when is true, is collapsed
    /// </summary>
    public class NotBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }


        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }
    }
    #endregion
}
