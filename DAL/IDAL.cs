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
        /*

        void AddBEObject(BEObject add);
           The function will verify if there the same BEObject in the database.
           If the BEObject does not exist then the function will add it, otherwise the function will throw an IdAlreadyExist exception  


        bool DeleteBEObject(BEObject DishId);
           The function will verify if the BEObject exist in the database.
           If the BEObject does not exist then the function throw an exception, otherwise the function will remove it  


        void UpdateBEObject(BEObject update);
           All classes in BE contains a function to copy from another object
           The function will verify if the BEObject exist in the database.
           If the BEObject does not exist then the function will throw an exception, otherwise the function will: 
                    * Use the copy function to update it (DAl List).
                    * Delete the old object then insert the new one (DAl XML). 

        BEObject SearchBEObjectById(int id);
            The function will verify if the BEObject exist in the database.
            If the BEObject does not exist then the function will return null, otherwise the function will return the found object.

        IEnumerable<BEObject> GetAllBEObject()
            The function will return all BEObject found in database.



    */


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
