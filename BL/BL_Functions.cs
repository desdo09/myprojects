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
            if (add.ClientAge < 18)
                throw new InvalidOperationException("BL error: Client can not be under 18 old");
            if (!ValidateCard(add.ClientCard))
                throw new InvalidOperationException("BL error: Invalid credit card");
            DalObject.AddClient(add);

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
            DalObject.DeleteClient(SearchClientById(delete));
        }
        public void DeleteDish(int DishId)
        {
            DalObject.DeleteDish(SearchDishById(DishId));
        }
        public void DeleteOrder(int delete)
        {
            DalObject.DeleteOrder(SearchOrderById(delete));
        }
        public void DeleteOrdered_Dish(int delete)
        {
            DalObject.DeleteOrdered_Dish(SearchOrdered_DishById(delete));
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
            return DalObject.SearchOrderById(id);
        }

        public Ordered_Dish SearchOrdered_DishById(int id)
        {
            return DalObject.SearchOrdered_DishById(id);
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
            DalObject.UpdateBranch(updete);
        }

        public void UpdateClient(Client updete)
        {
            DalObject.UpdateClient(updete);
        }

        public void UpdateDish(Dish update)
        {
            DalObject.UpdateDish(update);
        }

        public void UpdateOrder(Order updete)
        {
            DalObject.UpdateOrder(updete);
        }

        public void UpdateOrdered_Dish(Ordered_Dish updete)
        {
            DalObject.UpdateOrdered_Dish(updete);
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
        internal bool ValidateCard(string card)
        {
            if (card.Length < 15)
                return false;

            try
            {
                int sum = 0;
                for (int i = 0; i < 15; i += 2)
                {
                    sum = int.Parse(card[i].ToString());
                    if (sum > 10)
                        sum -= 9;
                    card = sum.ToString() + card.Substring(1);
                }
                sum = 0;
                for (int i = 0; i < 16; i++)
                    sum += int.Parse(card[i].ToString());
                return (sum % 10 == 0) ? true : false;
            }
            catch (FormatException)
            {
                throw new FormatException("BL error: Card number missing!");
            }
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
        public List<Branch> SearchInBranch(Func<Branch, bool> search)
        {
            var items = from x in GetAllBranch()
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Order> SearchInOrder(Func<Order, bool> search)
        {
            var items = from x in GetAllOrders()
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Client> SearchInClient(Func<Client, bool> search)
        {
            var items = from x in GetAllClients()
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Ordered_Dish> SearchInOrdered_Dish(Func<Ordered_Dish, bool> search)
        {
            var items = from x in GetAllOrdersDish()
                        where search(x)
                        select x;
            return items.ToList();
        }
        #endregion
        #region GetValidId
        public int GetDishValidId()
        {
            if (DalObject.GetAllDish() == null)
                return 0;
            int prevId = DalObject.GetAllDish()[0].DishId;
            foreach (Dish item in DalObject.GetAllDish())
            {
                if (item.DishId > prevId + 1)
                    return prevId;
                else
                    prevId = item.DishId;
            }
            return prevId+1;
        }
        public int GetBranchValidId()
        {
            if (DalObject.GetAllBranch() == null)
                return 0;
            int prevId = DalObject.GetAllBranch()[0].BranchId;
            foreach(Branch item in DalObject.GetAllBranch())
            {
                if (item.BranchId > prevId + 1)
                    return prevId;
                else
                    prevId = item.BranchId;
            }
            return prevId+1;
        }
        public int GetOrderValidId()
        {
            if (DalObject.GetAllOrder() == null || DalObject.GetAllOrder().Count == 0)
                return 0;
            int prevId = DalObject.GetAllOrder()[0].OrderId;
            foreach (Order item in DalObject.GetAllOrder())
            {
                if (item.OrderId > prevId + 1)
                    return prevId;
                else
                    prevId = item.OrderId;
            }
            return prevId+1;
        }
        public int GetClientValidId()
        {
            if (DalObject.GetAllClients() == null)
                return 0;
            int prevId = DalObject.GetAllClients()[0].ClientId;
            foreach (Client item in DalObject.GetAllClients())
            {
                if (item.ClientId > prevId + 1)
                    return prevId;
                else
                    prevId = item.ClientId;
            }
            return prevId+1;
        }
        public int GetOrdered_DishValidId()
        {
            if (DalObject.GetAllOrdersDish() == null)
                return 0;
            int prevId = DalObject.GetAllOrdersDish()[0].Ordered_DishId;
            foreach (Ordered_Dish item in DalObject.GetAllOrdersDish())
            {
                if (item.Ordered_DishId > prevId + 1)
                    return prevId;
                else
                    prevId = item.Ordered_DishId;
            }
            return prevId+1;
        }
        #endregion
    }
}
