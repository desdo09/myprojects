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
        int GetDishValidId();
        void AddDish(Dish add);
        void DeleteDish(int DishId);
        void UpdateDish(Dish update);
        Dish SearchDishById(int id);
        List<Dish> SearchInDish(Func<Dish, bool> search);
        IEnumerable<Dish> GettAllDishInBranch(int IdBranch);
        //Branch
        int GetBranchValidId();
        void AddBranch(Branch add);
        void DeleteBranch(int delete);
        void UpdateBranch(Branch updete);
        Branch SearchBranchById(int id);
        List<Branch> SearchInBranch(Func<Branch, bool> search);
        //  Branch SearchInBranch();
        //Order
        int GetOrderValidId();
        void AddOrder(Order Orderadd, List<Ordered_Dish> DishAdd);
        void DeleteOrder(int delete);
        void UpdateOrder(Order updete);
        Order SearchOrderById(int id);
        float CalculateOrderPrice(Order a);
        List<Order> SearchInOrder(Func<Order, bool> search);

        //Clients
        int GetClientValidId();
        void AddClient(Client add);
        void DeleteClient(int delete);
        void UpdateClient(Client updete);
        Client SearchClientById(int id);
        List<Client> SearchInClient(Func<Client, bool> search);
        //Ordered_Dish
        int GetOrdered_DishValidId();
        void AddOrdered_Dish(Ordered_Dish add);
        void DeleteOrdered_Dish(int delete);
        void UpdateOrdered_Dish(Ordered_Dish updete);
        List<Ordered_Dish> SearchAllOrderId(int id);
        Ordered_Dish SearchOrdered_DishById(int id);
        List<Ordered_Dish> SearchInOrdered_Dish(Func<Ordered_Dish, bool> search);

        //lists
        IEnumerable<Ordered_Dish> GetAllOrdersDish();
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Dish> GetAllDish();
        IEnumerable<Branch> GetAllBranch();
        IEnumerable<Client> GetAllClients();

    }
}
