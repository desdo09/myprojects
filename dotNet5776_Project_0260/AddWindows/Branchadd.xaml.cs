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

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for Branch.xaml
    /// </summary>
    public partial class BranchAdd : Window
    {
        IBL BlObject;
        public BranchAdd()
        {
            InitializeComponent();
            BlObject = FactoryBL.GetBL();
            HashagachaBox.ItemsSource = Enum.GetValues(typeof(BE.Hashgacha));
            HashagachaBox.SelectedIndex = 1;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (IdBox.Text == "")
                    throw new Exception("Id is required");
                if (NameBox.Text == "")
                    throw new Exception("Name is required");
                if (AddressBox.Text == "")
                    throw new Exception("Address is required");
                if (ManagerBox.Text == "")
                    throw new Exception("Manager is required");
                if (WorkersBox.Text == "")
                    throw new Exception("Workers is required");
                if (DeliverysBox.Text == "")
                    throw new Exception("Delivery is required");
                if (PhoneBox.Text == "")
                    throw new Exception("Phone required");
                BlObject.AddBranch(new Branch(int.Parse(IdBox.Text), NameBox.Text, AddressBox.Text, int.Parse(PhoneBox.Text), ManagerBox.Text, int.Parse(WorkersBox.Text), int.Parse(DeliverysBox.Text), (BE.Hashgacha)HashagachaBox.SelectedItem));
                MessageBox.Show("Data added successful!", "Branch Add");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("The fields: Id, Employers, Delivery persons and phone can only get numbers", "Branch add", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Branch add", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Source is TextBox && e.Key == Key.Enter)
                (e.Source as TextBox).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            if(e.Source is ComboBox && e.Key == Key.Enter)
                (e.Source as ComboBox).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            if (e.Source is Button && (e.Source as Button).Name == "AddButton" && e.Key == Key.Enter)
                 AddButton_Click(e.Source, null);
                
        }
    }
}
