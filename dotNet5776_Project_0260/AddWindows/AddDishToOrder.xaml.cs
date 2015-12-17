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

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for AddDishToOrder.xaml
    /// </summary>
    public partial class AddDishToOrder : Window
    {
        static IBL Bl_Object = BL.FactoryBL.GetBL();
        public event EventHandler<BE.Dish> SendDish = null;
        public AddDishToOrder()
        {
            InitializeComponent();
            DishData.ItemsSource = Bl_Object.GetAllDish();
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
    }
}
