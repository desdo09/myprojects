using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ClientAdd : Window, INotifyPropertyChanged
    {
        BL.IBL BlObject = BL.FactoryBL.GetBL();
        public event PropertyChangedEventHandler PropertyChanged;
        public ClientAdd(BE.Client update = null)
        {
            InitializeComponent();
            if (update == null)
                IdBox.Text = BlObject.GetClientValidId().ToString();
            else
            {
                IdBox.Text = update.ClientId.ToString();
                IdBox.IsEnabled = false;

                NameBox.Text = update.ClientName;
                AddressBox.Text = update.ClientAddress;
                PhoneBox.Text = update.ClientPhone;
                AgeBox.Text = update.ClientAge.ToString();

                DataContext = update;
                CardNumBox.Text = update.ClientCard.Split('+')[0];
                monthBox.SelectedValue = YearBox.SelectedValue = update.ClientCard.Split('+')[1];
                YearBox.SelectedValue = update.ClientCard.Split('+')[2];
            }
            

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
                

              if(int.Parse(YearBox.SelectedValue.ToString()) == DateTime.Now.Year && int.Parse(monthBox.SelectedValue.ToString()) < DateTime.Now.Month ||  int.Parse(YearBox.SelectedValue.ToString()) < DateTime.Now.Year)
                    throw new Exception("The credit card are expired!");

              if(IdBox.IsEnabled)
                BlObject.AddClient(new BE.Client(int.Parse(IdBox.Text), NameBox.Text, AddressBox.Text, CardNumBox.Text + "+" + monthBox.Text + "+" + YearBox.Text , PhoneBox.Text, int.Parse(AgeBox.Text)));
              else
                BlObject.UpdateClient(new BE.Client(int.Parse(IdBox.Text), NameBox.Text, AddressBox.Text, CardNumBox.Text + "+" + monthBox.Text + "+" + YearBox.Text, PhoneBox.Text, int.Parse(AgeBox.Text)));



                if (PropertyChanged != null)
                    PropertyChanged(this,null);
                MessageBox.Show("Client added successfully", "Client add");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Add client");
               
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientViewSource.Source = [generic data source]
        }
    }
}
