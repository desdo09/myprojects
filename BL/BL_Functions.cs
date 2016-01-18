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
        public void AddOrder(Order Orderadd, List<Ordered_Dish> DishAdd)
        {

            #region Condition

            if (Orderadd.OrderTime.Day > DateTime.Now.Day + 2)
                throw new InvalidOperationException("Does not allowed add an order to 24 hours early");
            if (Orderadd.OrderTime.Hour > 23 || Orderadd.OrderTime.Hour < 9)
                throw new InvalidProgramException("Branch closed");
            if (Orderadd.OrderTime.Hour < DateTime.Now.Hour - 1)
                throw new InvalidOperationException("Time not allowed");

            IEnumerable<Order> OrderInHour = SearchInOrder(x => x.OrderTime.Hour == Orderadd.OrderTime.Hour);
            Branch tempBranch = SearchBranchById(Orderadd.BranchId);

            if(!(OrderInHour != null && OrderInHour.Count()>tempBranch.NumOfDeliveryPerson) )
                throw new InvalidOperationException("Delivery full at " + Orderadd.OrderTime.Hour + "hs");

            if (SearchClientById(Orderadd.ClientId) == null)
                throw new NullReferenceException("Client does not found");
            if (Orderadd.OrderPrice > 1000)
                throw new InvalidOperationException("Price to hight");

            #endregion

            // The i will save the position where the will catch received the throw
            int i = 0;

            try
            {
                // If all order dish is fine then add Order 
                DalObject.AddOrder(Orderadd);

                for (; i < DishAdd.Count(); i++)
                {
                    AddOrdered_Dish(DishAdd[i]);
                }

            }catch(NullReferenceException ex)
            {
                throw new Exception("BL error:\n" + ex.Source + ":" + ex.Message);
            }
            catch (Exception ex)
            {
                DalObject.DeleteOrder(Orderadd);
                for (int j = 0; j < i; j++)
                {
                    DalObject.DeleteOrdered_Dish(DishAdd[j]);
                }
                throw ex;
            }
        }
        public void AddOrdered_Dish(Ordered_Dish add)
        {
            if (SearchOrderById(add.OrderId).HashgachaPlace > SearchDishById(add.DishId).HashgachaDish)
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
            foreach (Ordered_Dish item in SearchInOrdered_Dish(x => x.OrderId == delete))
            {
                DalObject.DeleteOrdered_Dish(item);
            }
        }
        public void DeleteOrdered_Dish(int delete)
        {
            DalObject.DeleteOrdered_Dish(SearchOrdered_DishById(delete));
        }
        #endregion

        #region gets All lists
        public IEnumerable<Branch> GetAllBranch()
        {
            return DalObject.GetAllBranch();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return DalObject.GetAllClients();
        }

        public IEnumerable<Dish> GetAllDish()
        {
            return DalObject.GetAllDish();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return DalObject.GetAllOrder();
        }

        public IEnumerable<Ordered_Dish> GetAllOrdersDish()
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

        public void UpdateOrder(Order updete, List<Ordered_Dish> DishAdd)
        {

            #region Condition
            if (updete.OrderTime.Day > DateTime.Now.Day + 2)
                throw new InvalidOperationException("Does not allowed add an order to 24 hours early");
            if (updete.OrderTime.Hour > 23 || updete.OrderTime.Hour < 9)
                throw new InvalidProgramException("Branch closed");
            if (updete.OrderTime.Hour < DateTime.Now.Hour - 1)
                throw new InvalidOperationException("Time not allowed");


            if (updete.OrderPrice > 1000)
                throw new InvalidOperationException("Price to hight");
            #endregion

            IEnumerable<Ordered_Dish> OrdersDishInDabase = SearchInOrdered_Dish(x => x.OrderId == updete.OrderId);
          
            foreach (Ordered_Dish item in OrdersDishInDabase)
            {
                Ordered_Dish ToUpdate = (from x in DishAdd where x.DishId == item.DishId select x).FirstOrDefault();

                try
                {

                    if (ToUpdate != null)
                    {
                        DalObject.UpdateOrdered_Dish(ToUpdate);
                        DishAdd.Remove(ToUpdate);
                    }
                    else
                        DalObject.DeleteOrdered_Dish(item);
                }
                catch (NullReferenceException ex)
               {
                    throw new NullReferenceException(ex.Source + " Error:\n"+ ex.Message);
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            DalObject.UpdateOrder(updete);

            foreach (Ordered_Dish item in DishAdd)
            {
                try
                {
                    AddOrdered_Dish(item);
                }
                catch (Exception ex) 
                {

                    throw new Exception("BL error:" + ex.Message + "\nThe another dishes was updated");
                }

            }
         
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
            StringBuilder tempCard = new StringBuilder(card.Split('+')[0]);

            if (tempCard.Length < 15)
                return false;


            try
            {
                int sum = 0;
                for (int i = 0; i < tempCard.Length; i += 2)
                {
                    sum = int.Parse(tempCard[i].ToString()) * 2;
                    if (sum > 10)
                        sum -= 9;
                    tempCard[i] = sum.ToString()[0];
                }
                sum = 0;
                for (int i = 0; i < tempCard.Length; i++)
                    sum += int.Parse(tempCard[i].ToString());
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
        public IEnumerable<Dish> GettAllDishInBranch(int IdBranch)
        {



            Branch currentBranch = SearchBranchById(IdBranch);
            if (currentBranch.BranchDishes == null)
                return currentBranch.BranchDishes as IEnumerable<Dish>;
            try
            {
                var Dishes = from x in GetAllDish()
                             where currentBranch.BranchDishes.Contains(x.DishId)
                             select x;
                return Dishes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Branch> SearchInBranch(Func<Branch, bool> search)
        {
            IEnumerable<Branch> temp = GetAllBranch();

            if (temp == null || temp.Count() == 0)
                return null;

            var items = from x in temp
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Order> SearchInOrder(Func<Order, bool> search)
        {
            IEnumerable<Order> temp = GetAllOrders();

            if (temp == null || temp.Count() == 0)
                return null;


            var items = from x in temp
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Client> SearchInClient(Func<Client, bool> search)
        {
            IEnumerable<Client> temp = GetAllClients();

            if (temp == null || temp.Count() == 0)
                return null;

            var items = from x in temp
                        where search(x)
                        select x;
            return items.ToList();
        }
        public List<Ordered_Dish> SearchInOrdered_Dish(Func<Ordered_Dish, bool> search)
        {

            IEnumerable<Ordered_Dish> temp = GetAllOrdersDish();

            if (temp == null || temp.Count() == 0)
                return null;

            var items = from x in temp
                        where search(x)
                        select x;
            return items.ToList();
        }
        #endregion

        #region GetValidId
        public int GetDishValidId()
        {
            return (DalObject.GetAllDish() != null && DalObject.GetAllDish().Count() > 0) ? DalObject.GetAllDish().Max(x => x.DishId) + 1 : 1;
        }
        public int GetBranchValidId()
        {
            return (DalObject.GetAllBranch() != null && DalObject.GetAllBranch().Count() > 0) ? DalObject.GetAllBranch().Max(x => x.BranchId) + 1 : 1;
        }
        public int GetOrderValidId()
        {
            return (GetAllOrders() != null && GetAllOrders().Count() > 0) ? GetAllOrders().Max(x => x.OrderId) + 1 : 1;
        }
        public int GetClientValidId()
        {
            return (GetAllClients() != null && GetAllClients().Count() > 0) ? GetAllClients().Max(x => x.ClientId) + 1 : 1;
        }
        public int GetOrdered_DishValidId()
        {
            return (GetAllOrdersDish() != null && GetAllOrdersDish().Count() > 0) ? GetAllOrdersDish().Max(x => x.Ordered_DishId) + 1 : 1;
        }




        #endregion
    }
}
