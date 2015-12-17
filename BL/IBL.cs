using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL
{
    public interface IBL
    {
        //Dish
        void AddDish(Dish add);
        void DeleteDish(int DishId);
        void UpdateDish(Dish update);
        Dish SearchDishById(int id);

        //Branch
        void AddBranch(Branch add);
        void DeleteBranch(int delete);
        void UpdateBranch(Branch updete);
        Branch SearchBranchById(int id);
        //Order
        void AddOrder(Order add);
        void DeleteOrder(int delete);
        void UpdateOrder(Order updete);
        Order SearchOrderById(int id);
        float CalculateOrderPrice(Order a);

        //Clients
        void AddClient(Client add);
        void DeleteClient(int delete);
        void UpdateClient(Client updete);
        Client SearchClientById(int id);
        //Ordered_Dish
        void AddOrdered_Dish(Ordered_Dish add);
        void DeleteOrdered_Dish(int delete);
        void UpdateOrdered_Dish(Ordered_Dish updete);
        List<Ordered_Dish> SearchAllOrderId(int id);
        Ordered_Dish SearchOrdered_DishById(int id);


        //lists
        List<Ordered_Dish> GetAllOrdersDish();
        List<Order> GetAllOrders();
        List<Dish> GetAllDish();
        List<Branch> GetAllBranch();
        List<Client> GetAllClients();

    }
}
