using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

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

        }

        public void AddClient(Client add)
        {
            if (SearchClientById(add.ClientId) == null)
                DataSource.ClientData.Add(add);

        }

        public void AddDish(Dish add)
        {
            if (SearchDishById(add.DishId) == null)
                DataSource.dishData.Add(add);

        }

        public void AddOrder(Order add)
        {
            if (SearchOrderById(add.BranchId) == null)
                DataSource.OrderData.Add(add);

        }

        public void AddOrdered_Dish(Ordered_Dish add)
        {
            if (SearchOrdered_DishById(add.DishId) == null)
                DataSource.Ordered_DishData.Add(add);
        }
        #endregion
        #region Update Functions
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
        #region SearchById functions
        public Branch SearchBranchById(int id)
        {
            return DataSource.BranchData.FirstOrDefault(a => a.BranchId == id);
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
            throw new NotImplementedException();
        }

        public void DeleteClient(Client delete)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(int DishId)
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
        #endregion
        #region Get List Functions
        public List<Branch> GetAllBranch()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public List<Dish> GetAllDish()
        {
            throw new NotImplementedException();
        }

        public List<Ordered_Dish> GetAllOrdersDish()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
