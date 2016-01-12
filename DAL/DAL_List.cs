using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.Runtime.Serialization;

namespace DAL
{
    sealed class DAL_List : IDAL
    {
        #region Constructor
        private DAL_List()
        {

        }
        static DAL_List()
        {

        }

        private static readonly DAL_List instance = new DAL_List();
        public static DAL_List Instance { get { return instance; } private set { } }
        #endregion
        #region Add functions
        public void AddBranch(Branch add)
        {

            if (SearchBranchById(add.BranchId) == null)
                DataSource.BranchData.Add(add);
            else
                throw new IdAlreadyExists("DAL error: Id " + add.BranchId + " already exists in data source");

        }

        public void AddClient(Client add)
        {
           


            if (SearchClientById(add.ClientId) == null)
                DataSource.ClientData.Add(add);
            else
                throw new IdAlreadyExists("DAL error: Id " + add.ClientId + " already exists in data source");
        }

        public void AddDish(Dish add)
        {
            if (SearchDishById(add.DishId) == null)
                DataSource.dishData.Add(add);
            else
                throw new IdAlreadyExists("DAL error: Id " + add.DishId + " already exists in data source");

        }

        public void AddOrder(Order add)
        {
            if (SearchOrderById(add.OrderId) == null)
                DataSource.OrderData.Add(add);
            else
                throw new IdAlreadyExists("DAL error: Id " + add.OrderId + " already exists in data source");
        }

        public void AddOrdered_Dish(Ordered_Dish add)
        {
            if (SearchOrdered_DishById(add.Ordered_DishId) == null)
                DataSource.Ordered_DishData.Add(add);
            else
                throw new IdAlreadyExists("DAL error: Id " + add.Ordered_DishId + " already exists in data source");
        }
        #endregion
        #region Update Functions
        public void UpdateBranch(Branch update)
        {

            Branch a = SearchBranchById(update.BranchId);
            if (a != null)
                a.copy(update);
            else
                throw new NullReferenceException("Id does not found!");

        }

        public void UpdateClient(Client update)
        {
            Client a = SearchClientById(update.ClientId);
            if (a != null)
                a.copy(update);
            else
                throw new NullReferenceException("Id does not found!");
        }

        public void UpdateDish(Dish update)
        {
            Dish a = SearchDishById(update.DishId);
            if (a != null)
                a.Copy(update);
            else
                throw new NullReferenceException("Dal Error: Id does not found!");
        }

        public void UpdateOrder(Order update)
        {
            Order a = SearchOrderById(update.OrderId);
            if (a != null)
                a.Copy(update);
            else
                throw new NullReferenceException("Dal Error:Id does not found!");
        }

        public void UpdateOrdered_Dish(Ordered_Dish update)
        {
            Ordered_Dish a = SearchOrdered_DishById(update.Ordered_DishId);
            if (a != null)
                a.copy(update);
            else
                throw new NullReferenceException("Dal Error: Id does not found!");
        }
        #endregion
        #region SearchById functions
        public Branch SearchBranchById(int id)
        {
            return DataSource.BranchData.FirstOrDefault(item => item.BranchId == id);
        
            
        }

        public Client SearchClientById(int id)
        {
            return DataSource.ClientData.FirstOrDefault(c => c.ClientId == id);
        }

        public Dish SearchDishById(int id)
        {
            return DataSource.dishData.FirstOrDefault(d => d.DishId == id);
        }

        public Order SearchOrderById(int id)
        {
            return DataSource.OrderData.FirstOrDefault(o => o.OrderId == id);
        }

        public Ordered_Dish SearchOrdered_DishById(int id)
        {
            return DataSource.Ordered_DishData.FirstOrDefault(O_D => O_D.OrderId == id);
        }
        #endregion
        #region Delete Functions
        public void DeleteBranch(Branch delete)
        {

            if (delete == null)
                throw new NullReferenceException("Branch does not found!");
           if(!DataSource.BranchData.Remove(delete))
            {
                throw new NullReferenceException("Branch does not found!");
            }

        }

        public void DeleteClient(Client delete)
        {
            if (DataSource.ClientData.Remove(delete) == false)
                throw new NullReferenceException("Client does not found!");
        }

        public void DeleteDish(Dish DishId)
        {
            if (!DataSource.dishData.Remove(DishId))
                throw new NullReferenceException("Dish does not found!");
        }

        public void DeleteOrder(Order delete)
        {
              DataSource.OrderData.Remove(delete);
            if (SearchOrderById(delete.OrderId)  != null)
                throw new NullReferenceException("Order does not found!");
        }

        public void DeleteOrdered_Dish(Ordered_Dish delete)
        {
            if (!DataSource.Ordered_DishData.Remove(delete))
                throw new NullReferenceException("Order Dish does not found!");
        }
        #endregion
        #region Get List Functions
        public IEnumerable<Branch> GetAllBranch()
        {
            return DataSource.BranchData;
        }

        public IEnumerable<Client> GetAllClients()
        {
           return DataSource.ClientData;
        }

        public IEnumerable<Dish> GetAllDish()
        {
            return DataSource.dishData;
        }

        public IEnumerable<Ordered_Dish> GetAllOrdersDish()
        {
            return DataSource.Ordered_DishData;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return DataSource.OrderData;
        }
        #endregion
    }

    #region Exceptions
    public class IdAlreadyExists : Exception, ISerializable
    {

        public IdAlreadyExists(string message) : base(message)
        {
        }

        public IdAlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override string ToString()
        {
            return "Id already exists on data base";
        }
    }
    #endregion
}
