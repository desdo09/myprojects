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



            if (!File.Exists(OrderPath))
            {
                Root = new XElement("Clients");
                Root.Save(OrderPath);
            }
            else
                LoadData(OrderPath);

            if (!File.Exists(OrderPath))
            {
                Root = new XElement("Branches");
                Root.Save(OrderPath);
            }
            else
                LoadData(OrderPath);

            if (!File.Exists(OrderPath))
            {
                Root = new XElement("Dishes");
                Root.Save(OrderPath);
            }
            else
                LoadData(OrderPath);

            if (!File.Exists(OrderPath))
            {
                Root = new XElement("OrderDishes");
                Root.Save(OrderPath);
            }
            else
                LoadData(OrderPath);
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







        public void AddBranch(Branch add)
        {

            LoadData(BranchPath);

            XElement id = new XElement("id", add.BranchId);
            XElement Name = new XElement("Name", add.BranchName);
            XElement Address = new XElement("Address", add.BranchAddres);
            XElement Phone = new XElement("Phone", add.BranchPhone);
            XElement BranchManager = new XElement("Card", add.BranchManager);
            XElement BranchWorkers = new XElement("Card", add.BranchWorkers);
            XElement NumOfDeliveryPerson = new XElement("Card", add.NumOfDeliveryPerson);
            XElement BranchHashgacha = new XElement("Card", add.BranchHashgacha);

            Root.Add(new XElement("Clients", id, Name, Address, Phone, BranchManager, BranchWorkers, NumOfDeliveryPerson, BranchHashgacha));
            Root.Save(BranchPath);
        }

        public void AddClient(Client add)
        {

            XElement id = new XElement("id", add.ClientId);
            XElement Name = new XElement("Name", add.ClientName);
            XElement Age = new XElement("Age", add.ClientAge);
            XElement Address = new XElement("Address", add.ClientAddress);
            XElement Phone = new XElement("Phone", add.ClientPhone);
            XElement Card = new XElement("Card", add.ClientCard);
            XElement Client = new XElement("Client_Details", Name, Age, Address, Phone);

            Root.Add(new XElement("Clients", id, Client, Card));
            Root.Save(ClientPath);

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
