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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        BL.IBL BlObject = BL.FactoryBL.GetBL();
        public Report(classes a)
        {
            InitializeComponent();


            switch (a)
            {
                case classes.Branch:

                    break;
                case classes.Client:

                    var resultClient =
                from item in BlObject.GetAllOrders()
                group item.OrderPrice by new { item.ClientId, BlObject.SearchClientById(item.ClientId).ClientName }
                into ClientGroup
                select new
                {

                    Id = ClientGroup.Key.ClientId,
                    Name = ClientGroup.Key.ClientName,
                    Sum = ClientGroup.Sum()
                };
                    datagrid.ItemsSource = resultClient;
                    break;


                case classes.Dish:
                    var resultDish =
                from item in BlObject.GetAllOrdersDish()
                let d = BlObject.SearchDishById(item.DishId)
                group item.DishAmount * d.DishPrice by new { item.DishId, d.DishName,  }
                into DishGroup
                select new
                {


                    Id = DishGroup.Key.DishId,
                    Name = DishGroup.Key.DishName,
                    Sum = DishGroup.Sum()
                };
                    datagrid.ItemsSource = resultDish;

                    break;
                case classes.Order:
                    break;
                case classes.Order_dish:
                    break;
                default:
                    break;
            }

            
                

           
        }
    }
}




