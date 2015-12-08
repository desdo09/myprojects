using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BL_Functions : IBL
    {
        //Test
        IDAL DalObject = FactoryDal.getDal();

        public void AddBranch(Branch add)
        {
            DalObject.AddBranch(add);
        }

        public void AddClient(Client add)
        {
            DalObject.AddClient(add);
        }

        public void AddDish(Dish add)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order add)
        {
            throw new NotImplementedException();
        }

        public void AddOrdered_Dish(Ordered_Dish add)
        {
            throw new NotImplementedException();
        }

        public void DeleteBranch(int delete)
        {

            DalObject.DeleteBranch(DalObject.SearchBranchById(delete));
        }

        public void DeleteClient(int delete)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(int DishId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int delete)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrdered_Dish(int delete)
        {
            throw new NotImplementedException();
        }

        public List<Branch> GetAllBranch()
        {
            return DalObject.GetAllBranch();
        }

        public List<Client> GetAllClients()
        {
            return DalObject.GetAllClients();
        }

        public List<Dish> GetAllDish()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<Ordered_Dish> GetAllOrdersDish()
        {
            throw new NotImplementedException();
        }

        public Branch SearchBranchById(int id)
        {
            throw new NotImplementedException();
        }

        public Client SearchClientById(int id)
        {
            throw new NotImplementedException();
        }

        public Dish SearchDishById(int id)
        {
            throw new NotImplementedException();
        }

        public Order SearchOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Ordered_Dish SearchOrdered_DishById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBranch(Branch updete)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client updete)
        {
            throw new NotImplementedException();
        }

        public void UpdateDish(Dish update)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order updete)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrdered_Dish(Ordered_Dish updete)
        {
            throw new NotImplementedException();
        }
    }
}
