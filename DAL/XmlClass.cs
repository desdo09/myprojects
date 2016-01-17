using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
namespace DAL
{

    internal class ClientToXmlClass
    {
        XElement Root;
        string Path = @"xml/client.xml";

        public ClientToXmlClass()
        {


            if (!File.Exists(Path))
            {
                Root = new XElement("Client");
                Root.Save(Path);
            }
            else
                LoadData();
        }

        private void LoadData()
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

        public void AddClient(Client client)
        {
            XElement id = new XElement("id", client.ClientId);
            XElement Name = new XElement("Name", client.ClientName);
            XElement Age = new XElement("Age", client.ClientAge);
            XElement Address = new XElement("Address", client.ClientAddress);
            XElement Phone = new XElement("Phone", client.ClientPhone);
            XElement Card = new XElement("Card", client.ClientCard);
         //   XElement Client = new XElement("Client_Details", Name, Age, Address, Phone);

            Root.Add(new XElement("Clients", id, Name, Card, Age, Address, Phone, Card));
            Root.Save(Path);
        }

        public IEnumerable<Client> GetAllClients()
        {
            LoadData();

            try
            {
                return (from p in Root.Elements()
                        select new Client(int.Parse(p.Element("id").Value),
                                         p.Element("Client_Details").Element("Name").Value,
                                         p.Element("Client_Details").Element("Address").Value,
                                         p.Element("Card").Value,
                                         p.Element("Client_Details").Element("Phone").Value,
                                         int.Parse(p.Element("Client_Details").Element("Age").Value)));

            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("XML Error: The database " + Path + " is empty or corrupted" + "\n" +
                                                "Error number" + ex.HResult);
            }


        }

        public Client GetClient(int id)
        {
            LoadData();
            Client clients;
            try
            {
                clients = (from p in Root.Elements()
                           where Convert.ToInt32(p.Element("id").Value) == id
                           select new Client(int.Parse(p.Element("id").Value),
                                             p.Element("Client_Details").Element("Name").Value,
                                             p.Element("Client_Details").Element("Address").Value,
                                             p.Element("Card").Value,
                                            p.Element("Client_Details").Element("Phone").Value,
                                             int.Parse(p.Element("Client_Details").Element("Age").Value))).FirstOrDefault();
            }
            catch
            {
                clients = null;
            }
            return clients;
        }


        public bool RemoveClient(int id)
        {
            XElement ClientElement;
            try
            {
                ClientElement = (from p in Root.Elements()
                                 where Convert.ToInt32(p.Element("id").Value) == id
                                 select p).FirstOrDefault();
                ClientElement.Remove();
                ClientElement.Save(Path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateClient(Client client)
        {
            if (RemoveClient(client.ClientId))
                AddClient(client);
            else
                throw new NullReferenceException("Client not found!");
        }


    }
    internal class OrderToXmlClass
    {
        XElement Root;
        string Path = @"xml/Order.xml";


        public OrderToXmlClass()
        {


            if (!File.Exists(Path))
            {
                Root = new XElement("Order");
                Root.Save(Path);
            }
            else
                LoadData();
        }

        private void LoadData()
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

        public void AddOrder(Order ord)
        {
            XElement id = new XElement("id", ord.OrderId);
            XElement Time = new XElement("Time", ord.OrderTime);
            XElement ClientId = new XElement("Client", ord.ClientId);
            XElement BranchId = new XElement("Branch", ord.BranchId);
            XElement Hashgacha = new XElement("Hashgacha", (int)ord.HashgachaPlace);
            XElement Remarks = new XElement("Remarks", ord.Remark);
            XElement Price = new XElement("Price", ord.OrderPrice);
            XElement Client = new XElement("Client_Details", ClientId, BranchId, Hashgacha);

            Root.Add(new XElement("Orders", id, Time, Client, Price));
            Root.Save(Path);
        }

        public IEnumerable<Order> GetAllClients()
        {
            LoadData();

            try
            {
                return from p in Root.Elements()
                       select new Order(int.Parse(p.Element("id").Value),                                                     // int _OrderId;
                                            DateTime.Parse(p.Element("Time").Value),                                          // DateTime _OrderTime;
                                            int.Parse(p.Element("Client_Details").Element("Branch").Value),                   // int _BranchId;
                                            (Hashgacha)(int.Parse(p.Element("Client_Details").Element("Hashgacha").Value)),   // Hashgacha _HashgachaPlace;
                                            int.Parse(p.Element("Client_Details").Element("Client").Value),                   // int _ClientId;
                                            float.Parse(p.Element("Price").Value),                                            // float _OrderPrice;
                                             p.Element("Remarks").Value);                                                     //  String remark;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("XML Error: The database " + Path + " is empty or corrupted" + "\n" +
                                               "Error number" + ex.HResult);
            }


        }

        public Order GetOrder(int id)
        {
            LoadData();


            try
            {
                return (from p in Root.Elements()
                        where int.Parse(p.Element("id").Value) == id
                        select new Order(int.Parse(p.Element("id").Value),                                                     // int _OrderId;
                                             DateTime.Parse(p.Element("Time").Value),                                          // DateTime _OrderTime;
                                             int.Parse(p.Element("Client_Details").Element("Branch").Value),                   // int _BranchId;
                                             (Hashgacha)(int.Parse(p.Element("Client_Details").Element("Hashgacha").Value)),   // Hashgacha _HashgachaPlace;
                                             int.Parse(p.Element("Client_Details").Element("Client").Value),                   // int _ClientId;
                                             float.Parse(p.Element("Price").Value),                                            // float _OrderPrice;
                                              p.Element("Remarks").Value)).FirstOrDefault();                                   //  String remark;
            }
            catch (Exception ex)
            {

                throw new ArgumentNullException("XML Error: The database " + Path + " is empty or corrupted" + "\n" +
                                               "Error number" + ex.HResult);
            }
            

        }


        public bool RemoveClient(int id)
        {
            XElement ToRemove;
            try
            {
                ToRemove = (from p in Root.Elements()
                            where int.Parse(p.Element("id").Value) == id
                            select p).FirstOrDefault();
                ToRemove.Remove();
                ToRemove.Save(Path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateOrder(Order ord)
        {
            if (RemoveClient(ord.OrderId))
                AddOrder(ord);
            else
                throw new NullReferenceException("Order not found!");
        }
    }

}
