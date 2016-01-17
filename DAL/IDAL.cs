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
        bool DeleteDish(Dish DishId);
        void UpdateDish(Dish update);
        Dish SearchDishById(int id);

        //Branch
        void AddBranch(Branch add);
        bool DeleteBranch(Branch delete);
        void UpdateBranch(Branch updete);
        Branch SearchBranchById(int id);
        //Order
        void AddOrder(Order add);
        bool DeleteOrder(Order delete);
        void UpdateOrder(Order updete);
        Order SearchOrderById(int id);

        //Clients
        void AddClient(Client add);
        bool DeleteClient(Client delete);
        void UpdateClient(Client updete);
        Client SearchClientById(int id);
        //Ordered_Dish
        void AddOrdered_Dish(Ordered_Dish add);
        bool DeleteOrdered_Dish(Ordered_Dish delete);
        void UpdateOrdered_Dish(Ordered_Dish updete);
        Ordered_Dish SearchOrdered_DishById(int id);


        //lists
        IEnumerable<Ordered_Dish> GetAllOrdersDish();
        IEnumerable<Order> GetAllOrder();
        IEnumerable<Dish> GetAllDish();
        IEnumerable<Branch> GetAllBranch();
        IEnumerable<Client> GetAllClients();


    }
}
