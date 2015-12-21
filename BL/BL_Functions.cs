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

        IDAL DalObject = FactoryDal.getDal();
        #region adds
        public void AddBranch(Branch add)
        {
            DalObject.AddBranch(add);
        }

        public void AddClient(Client add)
        {
            if (add.ClientAge >= 18)
                DalObject.AddClient(add);
            else
                throw new InvalidOperationException("BL error: Client can not be under 18 old");

        }

        public void AddDish(Dish add)
        {
            DalObject.AddDish(add);
        }

        public void AddOrder(Order add)
        {
            if (add.OrderPrice > 1000)
                throw new InvalidOperationException("BL error: Order can't be bigger than 1000");
            else
                DalObject.AddOrder(add);
        }

        public void AddOrdered_Dish(Ordered_Dish add)
        {
            if (SearchOrderById(add.OrderId).HashgachaPlace < SearchDishById(add.DishId).HashgachaDish)
                throw new InvalidOperationException("BL error: The Hashgacha not match");
            else
                DalObject.AddOrdered_Dish(add);
        }
        #endregion
        #region Deletes
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
        #endregion
        #region gets All lists
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
            return DalObject.GetAllDish();
        }

        public List<Order> GetAllOrders()
        {
            return DalObject.GetAllOrder();
        }

        public List<Ordered_Dish> GetAllOrdersDish()
        {
            return DalObject.GetAllOrdersDish();
        }
        #endregion
        #region searchById
        public Branch SearchBranchById(int id)
        {
            return DalObject.SearchBranchById(id);
        }

        public Client SearchClientById(int id)
        {
           return DalObject.SearchClientById(id);
        }

        public Dish SearchDishById(int id)
        {
            return DalObject.SearchDishById(id);
        }

        public Order SearchOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Ordered_Dish SearchOrdered_DishById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Ordered_Dish> SearchAllOrderId(int id)
        {
            List<Ordered_Dish> orders = new List<Ordered_Dish>();
            var list = from item in DalObject.GetAllOrdersDish()
                       where item.OrderId == id
                       select item;
            foreach (var item in list)
            {
                if (item.OrderId == id)
                {
                    orders.Add(item);
                }
            }
            return orders;
        }
        #endregion
        #region updates
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
        #endregion
        #region other functions
        public float CalculateOrderPrice(Order a)
        {
            float price = 0;
            List<Ordered_Dish> AllDish = SearchAllOrderId(a.OrderId);
            if (AllDish == null)
                throw new NullReferenceException("There no dish in order " + a.OrderId);
            foreach (Ordered_Dish item in AllDish)
            {
                price += (SearchDishById(item.DishId)).DishPrice * item.DishAmount;
            }
            return price;
        }
        #endregion
        #region Search
        public List<Dish> SearchInDish(Func<Dish, bool> search)
        {
            var items = from x in GetAllDish()
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Branch> SearchBranch(Func<Branch, bool> search)
        {
            var items = from x in GetAllBranch()
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Order> SearchOrder(Func<Order, bool> search)
        {
            var items = from x in GetAllOrders()
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Client> SearchClient(Func<Client, bool> search)
        {
            var items = from x in GetAllClients()
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Ordered_Dish> SearchOrdered_Dish(Func<Ordered_Dish, bool> search)
        {
            var items = from x in GetAllOrdersDish()
                        where search(x)
                        select x;
            return items.ToList();
        }
        #endregion
    }
}
