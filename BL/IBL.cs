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

        /*

        void AddBEObject(BEObject add);
          The function will send BEObject to AddBEObject in DAl
          There a few function that will verify a few condition before:
            
            
          void AddClient(Client add)
            The function will verify if the Credit card is valid and if the client is older than 18 

          AddOrdered_Dish(Ordered_Dish add) 
            The function will verify if the Hashgacha is able to the order 

          void AddOrder(Order Orderadd, List<Ordered_Dish> DishAdd
            The function will verify:
               if the branch still open to delivery
               if the delivery can be done
               if the client exist
               if the price is less than 1000
                    then the function will send the order to AddOrder in DAL
               if all order dish are inserted to the database 

        bool DeleteBEObject(BEObject DishId);
           The function will send BEObject to DeleteBEObject in DAl

        void UpdateBEObject(BEObject update);
          The function will send BEObject to UpdateBEObject in DAl

        BEObject SearchBEObjectById(int id);
          The function will send BEObject to SearchBEObjectById in DAl

        IEnumerable<BEObject> GetAllBEObject()
           The function will ask all BEObject to GetAllBEObject in DAl
       
        List<BEObject> SearchInBEObject(Func<BEObject, bool> search)
            the function will get a predicate and use it into a link to find BEObjects and return a list with the objects founded

        int GetBEObjectValidId();
            The function will return the next valid id 

        Ordered_Dish SearchOrdered_DishById(int id)
            The function will return all Order dish that have same order Id

     */

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
        void UpdateOrder(Order updete, List<Ordered_Dish> DishAdd);
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
