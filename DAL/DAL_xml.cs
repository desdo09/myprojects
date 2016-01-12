using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class DAL_xml : IDAL
    {
        ClientToXmlClass StudentXml = new ClientToXmlClass();
        public void AddBranch(Branch add)
        {
            throw new NotImplementedException();
        }

        public void AddClient(Client add)
        {
            
            StudentXml.AddClient(add);
         
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

        public void DeleteBranch(Branch delete)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(Client delete)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(Dish DishId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order delete)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrdered_Dish(Ordered_Dish delete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Branch> GetAllBranch()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return StudentXml.GetAllClients();
        }

        public IEnumerable<Dish> GetAllDish()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ordered_Dish> GetAllOrdersDish()
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
