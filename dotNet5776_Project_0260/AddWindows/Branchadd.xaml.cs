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
using System.ComponentModel;

namespace dotNet5776_Project_0260
{
    /// <summary>
    /// Interaction logic for Branch.xaml
    /// </summary>
    public partial class BranchAdd : Window, INotifyPropertyChanged
    {
        //Bl object
        IBL BlObject = FactoryBL.GetBL();

        bool Update = false;
        public BranchAdd(Branch update = null )
        {
            InitializeComponent();
            //Insert number in Id box
            IdBox.Text = BlObject.GetBranchValidId().ToString();
            //insert in ComboBox all Hashgacha 
            HashagachaBox.ItemsSource = Enum.GetValues(typeof(BE.Hashgacha));
            //Kosher is selected
            HashagachaBox.SelectedIndex = 1;



            if(update != null)
            {
                Update = true;
                IdBox.Text = update.BranchId.ToString();
                IdBox.IsEnabled = false;
                NameBox.Text = update.BranchName;
                AddressBox.Text = update.BranchAddres.ToString();
                ManagerBox.Text = update.BranchManager;
                WorkersBox.Text = update.BranchWorkers.ToString();
                DeliverysBox.Text = update.NumOfDeliveryPerson.ToString();
                PhoneBox.Text =  update.BranchPhone ;
                HashagachaBox.SelectedIndex = (int)update.BranchHashgacha;
                AddButton.Content = "Update Branch";
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(PhoneBox.Text + "\n"  + "\n");
                // Verify if the textbox are empty
                if (string.IsNullOrEmpty(IdBox.Text))
                    throw new Exception("Id is required");
                if (string.IsNullOrEmpty(NameBox.Text))
                    throw new Exception("Name is required");
                if (string.IsNullOrEmpty(AddressBox.Text))
                    throw new Exception("Address is required");
                if (string.IsNullOrEmpty(ManagerBox.Text))
                    throw new Exception("Manager is required");
                if (string.IsNullOrEmpty(WorkersBox.Text))
                    throw new Exception("Workers is required");
                if (string.IsNullOrEmpty(DeliverysBox.Text))
                    throw new Exception("Delivery is required");
                if (string.IsNullOrEmpty(PhoneBox.Text))
                    throw new Exception("Phone required");
                
                if(Update)
                    BlObject.UpdateBranch(new Branch(int.Parse(IdBox.Text), NameBox.Text, AddressBox.Text, PhoneBox.Text, ManagerBox.Text, int.Parse(WorkersBox.Text), int.Parse(DeliverysBox.Text), (BE.Hashgacha)HashagachaBox.SelectedItem));
                else
                    //If all textbox are something then the program will send to bl to verify
                    BlObject.AddBranch(new Branch(int.Parse(IdBox.Text), NameBox.Text, AddressBox.Text, PhoneBox.Text, ManagerBox.Text, int.Parse(WorkersBox.Text), int.Parse(DeliverysBox.Text), (BE.Hashgacha)HashagachaBox.SelectedItem));


               
                //If Bl didn't send error then the program will show a message that  data are added and close the window
                MessageBox.Show("Data " + ((Update)?"Updated" : "added") +" successful!", "Branch Add");
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BranchAdd#id=" + IdBox.Text + "Name=" + NameBox.Text));
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
        /// <summary>
        /// The function will change the box when the user press enter
        /// </summary>
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
