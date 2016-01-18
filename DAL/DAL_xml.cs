using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;

namespace DAL
{
    internal class DAL_xml : IDAL
    {


        private static readonly DAL_xml instance = new DAL_xml();
        public static DAL_xml Instance { get { return instance; } private set { } }



        XElement Root;
        string OrderPath = @"xml/Order.xml";
        string ClientPath = @"xml/Clients.xml";
        string BranchPath = @"xml/Branch.xml";
        string DishPath = @"xml/Dish.xml";
        string OrderDishPath = @"xml/OrderDish.xml";


        public DAL_xml()
        {
            if (!Directory.Exists(@"xml"))
                Directory.CreateDirectory(@"xml");


            if (!File.Exists(OrderPath))
            {
                Root = new XElement("Orders");
                Root.Save(OrderPath);
            }
            else
                LoadData(OrderPath);



            if (!File.Exists(ClientPath))
            {
                Root = new XElement("Clients");
                Root.Save(ClientPath);
            }
            else
                LoadData(ClientPath);

            if (!File.Exists(BranchPath))
            {
                Root = new XElement("Branches");
                Root.Save(BranchPath);
            }
            else
                LoadData(BranchPath);

            if (!File.Exists(DishPath))
            {
                Root = new XElement("Dishes");
                Root.Save(DishPath);
            }
            else
                LoadData(DishPath);

            if (!File.Exists(OrderDishPath))
            {
                Root = new XElement("OrderDishes");
                Root.Save(OrderDishPath);
            }
            else
                LoadData(OrderDishPath);
        }

        private void LoadData(string Path)
        {
            try
            {
                Root = XElement.Load(Path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        #region Add
        public void AddBranch(Branch add)
        {
            if (SearchBranchById(add.BranchId) != null)
                throw new IdAlreadyExists("Branch already exist");


            LoadData(BranchPath);


           

            XElement id = new XElement("id", add.BranchId);
            XElement Name = new XElement("Name", add.BranchName);
            XElement Address = new XElement("Address", add.BranchAddres);
            XElement Phone = new XElement("Phone", add.BranchPhone);
            XElement BranchManager = new XElement("Manager", add.BranchManager);
            XElement BranchWorkers = new XElement("Workers", add.BranchWorkers);
            XElement NumOfDeliveryPerson = new XElement("NumOfDeliveryPerson", add.NumOfDeliveryPerson);
            XElement BranchHashgacha = new XElement("Hashgacha", add.BranchHashgacha);

            Root.Add(new XElement("Branch", id, Name, Address, Phone, BranchManager, BranchWorkers, NumOfDeliveryPerson, BranchHashgacha));
            Root.Save(BranchPath);

        }

        public void AddClient(Client add)
        {
            if (SearchClientById(add.ClientId) != null)
                throw new IdAlreadyExists("Client already exist");


            LoadData(ClientPath);

            XElement id = new XElement("id", add.ClientId);
            XElement Name = new XElement("Name", add.ClientName);
            XElement Age = new XElement("Age", add.ClientAge);
            XElement Address = new XElement("Address", add.ClientAddress);
            XElement Phone = new XElement("Phone", add.ClientPhone);
            XElement Card = new XElement("Card", add.ClientCard);
            XElement Client = new XElement("Client_Details", Name, Age, Address, Phone);

            Root.Add(new XElement("Client", id, Client, Card));
            Root.Save(ClientPath);

        }


        public void AddDish(Dish add)
        {
            if (SearchDishById(add.DishId) != null)
                throw new IdAlreadyExists("Dish already exist");


            LoadData(DishPath);

          

            XElement id = new XElement("id", add.DishId);
            XElement Name = new XElement("Name", add.DishName);
            XElement Size = new XElement("Size", add.DishSize);
            XElement Price = new XElement("Price", add.DishPrice);
            XElement Hashgacha = new XElement("Hashgacha", add.HashgachaDish);
            

            Root.Add(new XElement("Dish", id, Name, Size, Price, Hashgacha));
            Root.Save(DishPath);
        }

        public void AddOrder(Order add)
        {
            if (SearchOrderById(add.OrderId) != null)
                throw new IdAlreadyExists("Order already exist");


            LoadData(OrderPath);

            XElement id = new XElement("id", add.OrderId);
            XElement Time = new XElement("Time", add.OrderTime);
            XElement ClientId = new XElement("Client", add.ClientId);
            XElement BranchId = new XElement("Branch", add.BranchId);
            XElement Hashgacha = new XElement("Hashgacha", add.HashgachaPlace);
            XElement Remarks = new XElement("Remarks", add.Remark);
            XElement Price = new XElement("Price", add.OrderPrice);
            XElement Client = new XElement("Client_Details", ClientId, BranchId, Hashgacha);

            Root.Add(new XElement("Order", id, Time, Client, Price, Remarks));
            Root.Save(OrderPath);

        }

        public void AddOrdered_Dish(Ordered_Dish add)
        {
            if (SearchOrdered_DishById(add.Ordered_DishId) != null)
                throw new IdAlreadyExists("Ordered_Dish already exist");


            LoadData(OrderDishPath);



           

            XElement id = new XElement("id", add.Ordered_DishId);
            XElement Order = new XElement("Order", add.OrderId);
            XElement Dish = new XElement("Dish", add.DishId);
            XElement Amount = new XElement("Amount", add.DishAmount);
           

            Root.Add(new XElement("Ordered_Dish", id, Order, Dish, Amount));
            Root.Save(OrderDishPath);
        }
        #endregion

        #region Delete
        public bool DeleteBranch(Branch delete)
        {
            XElement ToRemove;
            LoadData(BranchPath);
            try
            {
                ToRemove = (from p in Root.Elements()
                            where int.Parse(p.Element("id").Value) == delete.BranchId
                            select p).FirstOrDefault();
                ToRemove.Remove();
                Root.Save(BranchPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClient(Client delete)
        {
            XElement ToRemove;
            LoadData(ClientPath);
            try
            {
                ToRemove = (from p in Root.Elements()
                            where int.Parse(p.Element("id").Value) == delete.ClientId
                            select p).FirstOrDefault();
                ToRemove.Remove();
                Root.Save(ClientPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDish(Dish DishId)
        {
            XElement ToRemove;
            LoadData(DishPath);
            try
            {
                ToRemove = (from p in Root.Elements()
                            where int.Parse(p.Element("id").Value) == DishId.DishId
                            select p).FirstOrDefault();
                ToRemove.Remove();
                Root.Save(DishPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrder(Order delete)
        {
            XElement ToRemove;
            LoadData(OrderPath);
            try
            {
                ToRemove = (from p in Root.Elements()
                            where int.Parse(p.Element("id").Value) == delete.OrderId
                            select p).FirstOrDefault();
                ToRemove.Remove();
                Root.Save(OrderPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrdered_Dish(Ordered_Dish delete)
        {
            XElement ToRemove;
            LoadData(OrderDishPath);
            try
            {
                ToRemove = (from p in Root.Elements()
                            where int.Parse(p.Element("id").Value) == delete.Ordered_DishId
                            select p).FirstOrDefault();
                ToRemove.Remove();
                Root.Save(OrderDishPath);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GetAll
        public IEnumerable<Branch> GetAllBranch()
        {
            LoadData(BranchPath);

            IEnumerable<Branch> temp;
         
            try
            {
                temp = from p in Root.Elements()
                        select new Branch(int.Parse(p.Element("id").Value),
                                         p.Element("Name").Value,
                                         p.Element("Address").Value,
                                         p.Element("Phone").Value,
                                         p.Element("Manager").Value,
                                        int.Parse( p.Element("Workers").Value),
                                         int.Parse(p.Element("NumOfDeliveryPerson").Value),
                                        (BE.Hashgacha) Enum.Parse(typeof( BE.Hashgacha) , (p.Element("Hashgacha").Value)));

                if (temp.Count() == 0) return null;


                return temp;


            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("XML Error: The database " + ClientPath + " is empty or corrupted" + "\n" +
                                                "Error number" + ex.HResult);
            }
        }

        public IEnumerable<Client> GetAllClients()
        {
            LoadData(ClientPath);

            try
            {
                IEnumerable<Client> temp = (from p in Root.Elements()
                        select new Client(int.Parse(p.Element("id").Value),
                                         p.Element("Client_Details").Element("Name").Value,
                                         p.Element("Client_Details").Element("Address").Value,
                                         p.Element("Card").Value,
                                         p.Element("Client_Details").Element("Phone").Value,
                                          int.Parse(p.Element("Client_Details").Element("Age").Value)));
                return (temp.Count() > 0) ? temp : null;

            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("XML Error: The database " + ClientPath + " is empty or corrupted" + "\n" +
                                                "Error number" + ex.HResult);
            }
        }

        public IEnumerable<Dish> GetAllDish()
        {
            LoadData(DishPath);

            IEnumerable<Dish> temp;

            try
            {

            

                temp = from p in Root.Elements()
                       select new Dish(int.Parse(p.Element("id").Value),
                                        p.Element("Name").Value,
                                       (BE.Dish.size) Enum.Parse( typeof(BE.Dish.size), p.Element("Size").Value),
                                      float.Parse(  p.Element("Price").Value),
                                       (BE.Hashgacha)Enum.Parse(typeof(BE.Hashgacha), (p.Element("Hashgacha").Value)));

                if (temp.Count() == 0) return null;


                return temp;


            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("XML Error: The database " + ClientPath + " is empty or corrupted" + "\n" +
                                                "Error number" + ex.HResult);
            }
        }

        public IEnumerable<Order> GetAllOrder()
        {
            LoadData(OrderPath);

            IEnumerable<Order> temp;


         
            try
            {
                temp= from p in Root.Elements()
                       select new Order(int.Parse(p.Element("id").Value),                                                     // int _OrderId;
                                            DateTime.Parse(p.Element("Time").Value),                                          // DateTime _OrderTime;
                                            int.Parse(p.Element("Client_Details").Element("Branch").Value),                   // int _BranchId;


                                           (BE.Hashgacha) Enum.Parse(typeof(BE.Hashgacha), 
                                                                   p.Element("Client_Details").Element("Hashgacha").Value),   // Hashgacha _HashgachaPlace;


                                            int.Parse(p.Element("Client_Details").Element("Client").Value),                   // int _ClientId;
                                            float.Parse(p.Element("Price").Value),                                            // float _OrderPrice;
                                             p.Element("Remarks").Value);                                                     //  String remark;

                return (temp.Count() > 0) ? temp : null;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("XML Error: The database " + OrderPath + " is empty or corrupted" + "\n" +
                                               "Error number" + ex.HResult +"/nError type"+ ex.GetType());
            }
        }

        public IEnumerable<Ordered_Dish> GetAllOrdersDish()
        {
          
            LoadData(OrderDishPath);

           


            try
            {
                IEnumerable<Ordered_Dish> temp = from p in Root.Elements()
                       select new Ordered_Dish(
                                            int.Parse(p.Element("id").Value),                                                  
                                            int.Parse(p.Element("Order").Value),                                          
                                            int.Parse(p.Element("Dish").Value),                  
                                            float.Parse(p.Element("Amount").Value)                                           
                                             );

                return (temp != null && temp.Count() > 0) ? temp : null;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("XML Error: The database " + OrderPath + " is empty or corrupted" + "\n" +
                                               "Error number" + ex.HResult);
            }

        }
        #endregion

        #region Search
        public Branch SearchBranchById(int id)
        {
            LoadData(BranchPath);


            return (from p in Root.Elements()
                    where (int.Parse(p.Element("id").Value) == id)
                    select new Branch(int.Parse(p.Element("id").Value),
                                     p.Element("Name").Value,
                                     p.Element("Address").Value,
                                     p.Element("Phone").Value,
                                     p.Element("Manager").Value,
                                    int.Parse(p.Element("Workers").Value),
                                     int.Parse(p.Element("NumOfDeliveryPerson").Value),
                                    (BE.Hashgacha)Enum.Parse(typeof(BE.Hashgacha), (p.Element("Hashgacha").Value)))).FirstOrDefault();

              

            }

        public Client SearchClientById(int id)
        {
            LoadData(ClientPath);

            return (from p in Root.Elements()
                    where (int.Parse(p.Element("id").Value) == id)
                    select new Client(int.Parse(p.Element("id").Value),
                                     p.Element("Client_Details").Element("Name").Value,
                                     p.Element("Client_Details").Element("Address").Value,
                                     p.Element("Card").Value,
                                     p.Element("Client_Details").Element("Phone").Value,
                                      int.Parse(p.Element("Client_Details").Element("Age").Value))).FirstOrDefault();
        }

        public Dish SearchDishById(int id)
        {
            LoadData(DishPath);
            return (from p in Root.Elements()
                    where (int.Parse(p.Element("id").Value) == id)
                    select new Dish(int.Parse(p.Element("id").Value),
                                    p.Element("Name").Value,
                                   (BE.Dish.size)Enum.Parse(typeof(BE.Dish.size), p.Element("Size").Value),
                                  float.Parse(p.Element("Price").Value),
                                   (BE.Hashgacha)Enum.Parse(typeof(BE.Hashgacha), (p.Element("Hashgacha").Value)))).FirstOrDefault();
        }

        public Order SearchOrderById(int id)
        {
            LoadData(OrderPath);
            return (from p in Root.Elements()
                    where (int.Parse(p.Element("id").Value) == id)
                    select new Order(int.Parse(p.Element("id").Value),                                                        // int _OrderId;
                                            DateTime.Parse(p.Element("Time").Value),                                          // DateTime _OrderTime;
                                            int.Parse(p.Element("Client_Details").Element("Branch").Value),                   // int _BranchId;


                                           (BE.Hashgacha)Enum.Parse(typeof(BE.Hashgacha),
                                                                   p.Element("Client_Details").Element("Hashgacha").Value),   // Hashgacha _HashgachaPlace;


                                            int.Parse(p.Element("Client_Details").Element("Client").Value),                   // int _ClientId;
                                            float.Parse(p.Element("Price").Value),                                            // float _OrderPrice;
                                             p.Element("Remarks").Value)).FirstOrDefault();                                   //  String remark;
        }

        public Ordered_Dish SearchOrdered_DishById(int id)
        {
            LoadData(OrderDishPath);

            try
            {
                return (from p in Root.Elements()
                        where (int.Parse(p.Element("id").Value) == id)
                        select new Ordered_Dish(
                                             int.Parse(p.Element("id").Value),
                                             int.Parse(p.Element("Order").Value),
                                             int.Parse(p.Element("Dish").Value),
                                             float.Parse(p.Element("Price").Value)
                                              )).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }

        }
        #endregion

        #region Update
        public void UpdateBranch(Branch updete)
        {
            if (DeleteBranch(updete))
                AddBranch(updete);
            else
                throw new NullReferenceException("Dal Error: Branch does not exist");
        }

        public void UpdateClient(Client updete)
        {
            if (DeleteClient(updete))
                AddClient(updete);
            else
                throw new NullReferenceException("Dal Error: Client does not exist");
        }

        public void UpdateDish(Dish update)
        {
            if (DeleteDish(update))
                AddDish(update);
            else
                throw new NullReferenceException("Dal Error: Dish does not exist");
        }

        public void UpdateOrder(Order updete)
        {
            if (DeleteOrder(updete))
                AddOrder(updete);
            else
                throw new NullReferenceException("Dal Error: Order does not exist");
        }

        public void UpdateOrdered_Dish(Ordered_Dish updete)
        {
            if (DeleteOrdered_Dish(updete))
                AddOrdered_Dish(updete);
            else
                throw new NullReferenceException("Dal dish: Order does not exist");
        }

        #endregion
    }
}
