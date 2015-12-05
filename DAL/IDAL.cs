using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        //Dish
        void AddDish(Dish add);
        void DeleteDish(int DishId);
        void UpdateDish(Dish update);

        //Branch
        void AddBranch(Branch add);
        void DeleteBranch(Branch delete);
        void UpdateBranch(Branch updete);

        //Order
        void AddOrder(Order add);
        void DeleteOrder(Order delete);
        void UpdateOrder(Order updete);

        //Clients
        void AddClient(Client add);
        void DeleteClient(Client delete);
        void UpdateClient(Client updete);

        //Ordered_Dish
        void AddOrdered_Dish(Ordered_Dish add);
        void DeleteOrdered_Dish(Ordered_Dish delete);
        void UpdateOrdered_Dish(Ordered_Dish updete);

        List<Ordered_Dish> GetAllOrdersDish();
        List<Dish> GetAllDish();
        List<Branch> GetAllBranch();
        List<Client> GetAllClients();


    }
}
