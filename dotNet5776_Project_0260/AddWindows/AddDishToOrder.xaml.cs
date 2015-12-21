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
using System.Threading;
using System.Collections.ObjectModel;

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for AddDishToOrder.xaml
    /// </summary>
    public partial class AddDishToOrder : Window
    {
        static IBL Bl_Object = BL.FactoryBL.GetBL();
        public event EventHandler<BE.Dish> SendDish = null;
        ObservableCollection<BE.Dish> items;
        public AddDishToOrder()
        {
            InitializeComponent();
            items = new ObservableCollection<BE.Dish>(Bl_Object.GetAllDish());
            DishData.ItemsSource = items;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse((sender as Button).Tag.ToString());
                if (SendDish != null)
                {
                    SendDish(this, Bl_Object.SearchDishById(id));
                    // new Thread(() => { MessageBox.Show("Added successful"); }).Start();
                }
                else
                    new NullReferenceException("SendDish null");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType() + ": " + ex.Message);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {


            TextBox search = sender as TextBox;
            if (string.IsNullOrEmpty(search.Text))
            {
                foreach (var item in Bl_Object.GetAllDish())
                {
                    items.Add(item);
                }
                DishData.ItemsSource = items;
                return;
            }
            items.Clear();


            var dishes = from item in Bl_Object.GetAllDish()
                         where item.DishId.ToString().Contains(search.Text) || item.DishName.Contains(search.Text) || item.DishPrice.ToString().Contains(search.Text) || item.DishSize.ToString().Contains(search.Text) || item.HashgachaDish.ToString().Contains(search.Text)
                         select item;
            if (dishes != null)
            {

                foreach (var item in dishes)
                {
                    items.Add(item);
                }
            }




        }
    }
}
