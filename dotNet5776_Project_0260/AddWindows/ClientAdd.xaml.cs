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
    /// Interaction logic for ClientAdd.xaml
    /// </summary>
    public partial class ClientAdd : Window
    {
        BL.IBL BlObject = BL.FactoryBL.GetBL();
        public ClientAdd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(IdBox.Text))
                    throw new Exception("Id is requiered!");
                if (string.IsNullOrEmpty(NameBox.Text))
                    throw new Exception("Name is requiered!");
                if (string.IsNullOrEmpty(AddressBox.Text))
                    throw new Exception("Address is requiered!");
                if (string.IsNullOrEmpty(CardNumBox.Text))
                    throw new Exception("Card is requiered!");
                if (string.IsNullOrEmpty(PhoneBox.Text))
                    throw new Exception("Phone is requiered!");
                if (string.IsNullOrEmpty(AgeBox.Text))
                    throw new Exception("Age is requiered!");


                BlObject.AddClient(new BE.Client(int.Parse(IdBox.Text), NameBox.Text, AddressBox.Text, CardNumBox.Text, int.Parse(PhoneBox.Text), int.Parse(AgeBox.Text)));
                this.Close();
            }
            catch (Exception)
            {

               
            }


        }
    }
}
