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

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for Branch.xaml
    /// </summary>
    public partial class OrderAdd : Window
    {
        IBL BlObject;
        ObservableCollection<Dishamount> CurrentDish;
        AddDishToOrder order = new AddDishToOrder();
        public OrderAdd()
        {
            InitializeComponent();
            BlObject = FactoryBL.GetBL();
            CurrentDish = new ObservableCollection<Dishamount>();
            DishList.ItemsSource = CurrentDish;
            order.SendDish += AddDish;
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
            PriceBox.Text = "₪ " + sum;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {


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

        private void DishList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Width = 85;
            for (int i = 0; i < Dish.NameOfObjects.Length; i++)
            {
                if (e.Column.Header.ToString() == Dish.NameOfObjects[i])
                {
                    e.Column.Header = Dish.NameOfObjects[i + 1];
                    break;
                }
            }
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
            TextBox text = sender as TextBox;
            int id = (int)text.Tag;
            int amount = int.Parse(text.Text.ToString());
            Dishamount current = CurrentDish.FirstOrDefault(item => item.DishId == id);
            if (current != null)
            {
                current.amount = amount;
            }
            Price();
        }

        private void AddDishToOrder(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("hi");
            order.Show();
            order = new AddDishToOrder();
            order.SendDish += AddDish;
        }

        private void IdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;

            if (string.IsNullOrEmpty(text.Text))
                return;

            try {
                Client client = BlObject.SearchClientById(int.Parse(text.Text));
                if (client != null)
                {
                    ClientDetails.Text = client.ClientName + " in " + client.ClientAddress;
                    NameBox.Text = client.ClientPhone.ToString();
                }
           }catch(FormatException)
            {
                text.Text = "";
            }
        }
    }
    public class Dishamount
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public float DishSize { get; set; }
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
