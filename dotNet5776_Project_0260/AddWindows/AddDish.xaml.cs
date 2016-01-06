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

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for AddDish.xaml
    /// </summary>
    public partial class AddDish : Window
    {
        BL.IBL BlObject = BL.FactoryBL.GetBL();
        public AddDish()
        {
            InitializeComponent();
           
            SizeBox.ItemsSource = Enum.GetValues(typeof(BE.Dish.size));
            SizeBox.SelectedIndex = 0;
            HashagachaBox.ItemsSource = Enum.GetValues(typeof(BE.Hashgacha));
            HashagachaBox.SelectedIndex = 1;
            IdBox.Text = BlObject.GetDishValidId().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry image is not enable yet.\nWe working to improve it", "Add image");
           // image.Source = new BitmapImage(new Uri("\\dotNet5776_Project_0260;component\\Images\\ExportButton.fw.png", UriKind.RelativeOrAbsolute));
        }

        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(IdBox.Text))
                    throw new Exception("Id is required");
                if (string.IsNullOrEmpty(NameBox.Text))
                    throw new Exception("Name is required");
               
                if (string.IsNullOrEmpty(PriceBox.Text))
                    throw new Exception("Price is required");
                BlObject.AddDish(new BE.Dish(int.Parse(IdBox.Text), NameBox.Text, (BE.Dish.size)SizeBox.SelectedItem, float.Parse(PriceBox.Text), (BE.Hashgacha)HashagachaBox.SelectedItem));
                MessageBox.Show("Dish added successfully");
                this.Close();
            } catch(FormatException)
            {
                MessageBox.Show("The field: Id, Size and Price, can only get numbers");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.GetType() + ": " + ex.Message);

            }
        }
    }
}
