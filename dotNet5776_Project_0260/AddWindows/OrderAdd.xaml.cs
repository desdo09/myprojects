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
using BL;
using BE;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for Branch.xaml
    /// </summary>
    public partial class OrderAdd : Window, INotifyPropertyChanged
    {
        #region Objects
        IBL BlObject;
        int OrderId;
        ObservableCollection<Dishamount> CurrentDish;
        AddDishToOrder order = new AddDishToOrder();
        Client currentClient;
        Branch currentBranch;
        float price;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        public OrderAdd(Order update = null)
        {
            InitializeComponent();
            BlObject = FactoryBL.GetBL();
            CurrentDish = new ObservableCollection<Dishamount>();
            DishList.ItemsSource = CurrentDish;
            order.SendDish += AddDish;
            OrderId = BlObject.GetOrderValidId();
            foreach (Branch items in BlObject.GetAllBranch())
            {
                ComboBoxItem temp = new ComboBoxItem();
                temp.Content = items.BranchName;
                temp.Tag = items.BranchId;
                BranchBox.Items.Add(temp);
            }
        }
        void AddDish(object a, Dish b)
        {
            if (CurrentDish.FirstOrDefault(item => item.DishId == b.DishId) == null)
                CurrentDish.Add(new Dishamount(b, 1));
            else
                MessageBox.Show("Dish already exist!");
            Price();

        }
        void Price()
        {
            float sum = 0;
            foreach (Dishamount item in CurrentDish)
            {
                sum += item.DishPrice * item.amount;
            }
            price = sum;
            PriceBox.Text = "₪ " + sum;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int id = BlObject.GetOrderValidId();
            try
            {
                if (currentBranch == null)
                    throw new Exception("Please choice a Branch");
                if (currentClient == null)
                    throw new Exception("Please choice a client");
                if (CurrentDish == null)
                    throw new Exception("No dish added");
                if (DayBox.SelectedDate == null)
                    throw new Exception("Please select the Order Day");
                if (HourBox.Value == null)
                    throw new Exception("Please select the Order time");

                var dishes = from x in CurrentDish
                             select new Ordered_Dish(BlObject.GetOrdered_DishValidId(), OrderId, x.DishId, x.amount);

                DateTime DeliveryTime = new DateTime(
                                                    ((DateTime)DayBox.SelectedDate).Year,
                                                    ((DateTime)DayBox.SelectedDate).Month,
                                                    ((DateTime)DayBox.SelectedDate).Day,
                                                    ((DateTime)HourBox.Value).Hour,
                                                    ((DateTime)HourBox.Value).Minute,
                                                    0);


                Order temp = new Order(OrderId, DeliveryTime, currentBranch.BranchId, currentBranch.BranchHashgacha, currentClient.ClientId, price, RemarksBox.Text.ToString());

                BlObject.AddOrder(temp, dishes.ToList());
                PropertyChanged(this, new PropertyChangedEventArgs("OrderAdd#"));

                MessageBox.Show("Order added successful");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Source is TextBox && e.Key == Key.Enter)
                (e.Source as TextBox).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            if (e.Source is ComboBox && e.Key == Key.Enter)
                (e.Source as ComboBox).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            if (e.Source is Button && (e.Source as Button).Name == "AddButton")
                AddButton_Click(e.Source, null);

        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            try
            {

                int id = (int)(sender as Button).Tag;
                CurrentDish.Remove(CurrentDish.FirstOrDefault(item => item.DishId == id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Price();
        }

        private void UpdateAmount(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.IntegerUpDown text = sender as Xceed.Wpf.Toolkit.IntegerUpDown;
            int id = (int)text.Tag;
            int amount;
            try
            {
                amount = int.Parse(text.Text.ToString());
                if (amount < 1)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                amount = 1;
                text.Text = "1";
            }


            Dishamount current = CurrentDish.FirstOrDefault(item => item.DishId == id);
            if (current != null)
            {
                current.amount = amount;
            }
            Price();
        }

        private void AddDishToOrder(object sender, RoutedEventArgs e)
        {

            order.Show();
            order = new AddDishToOrder();
            order.SendDish += AddDish;

        }

        private void IdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;

            if (string.IsNullOrEmpty(text.Text))
                return;

            try
            {

                if (text.Name != "PhoneBox")
                    currentClient = BlObject.SearchClientById(int.Parse(text.Text));
                else
                {
                    try
                    {
                        currentClient = BlObject.SearchInClient(client => client.ClientPhone == int.Parse(text.Text))[0];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        currentClient = null;
                    }
                }



                if (currentClient != null)
                {
                    AddressBox.Text = currentClient.ClientAddress;
                    string CardNum = currentClient.ClientCard.Split('+')[0];

                    CardBox.Text = "**********" + CardNum.Substring(11);
                    CardChange.IsEnabled = true;
                    if (text.Name != "PhoneBox")
                        PhoneBox.Text = currentClient.ClientPhone.ToString();
                    else
                        IdBox.Text = currentClient.ClientId.ToString();
                    AddButton.IsEnabled = true;
                }
                else
                {
                    CardChange.IsEnabled = false;
                    AddressBox.Text = " ";
                    CardBox.Text = " ";
                    AddButton.IsEnabled = false;
                }
            }
            catch (FormatException)
            {
                text.Text = "";
            }

        }

        private void CardChange_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry, but that option are not available yet");
            (sender as CheckBox).IsChecked = false;
        }

        private void BranchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ComboBoxItem temp = ((sender as ComboBox).SelectedItem) as ComboBoxItem;
            if (temp != null)
            {
                currentBranch = BlObject.SearchBranchById(int.Parse(temp.Tag.ToString()));
                KashrutBox.Content = currentBranch.BranchHashgacha.ToString();
            }

        }
    }
    public class Dishamount
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public Dish.size DishSize { get; set; }
        public float DishPrice { get; set; }
        public Hashgacha HashgachaDish { get; set; }
        public int amount { get; set; }

        public Dishamount(Dish Dish, int amount)
        {
            this.DishId = Dish.DishId;
            DishName = Dish.DishName;
            DishSize = Dish.DishSize;
            DishPrice = Dish.DishPrice;
            HashgachaDish = Dish.HashgachaDish;
            this.amount = amount;
        }
    }
}
