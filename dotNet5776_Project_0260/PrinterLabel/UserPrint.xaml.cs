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
    /// Interaction logic for UserPrint.xaml
    /// </summary>
    public partial class UserPrint : Window
    {
        public UserPrint(BE.Client c)
        {
            InitializeComponent();

            Id.Text = c.ClientId.ToString();
            Name.Text = c.ClientName;
            Address.Text = c.ClientAddress;
            Card.Text = c.ClientCard.Split('=')[0].Substring(12);
           
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(main, "User printing");

        }
    }
}
