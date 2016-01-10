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
        XElement ClientRoot;
        string ClientPath = @"xml/client.xml" ;


        public  ClientToXmlClass()
        {


            if (!File.Exists(ClientPath))
            {
                ClientRoot = new XElement("Client");
                ClientRoot.Save(ClientPath);
            }
            else
                LoadData();
        }

        private void LoadData()
        {
            try
            {
                ClientRoot = XElement.Load(ClientPath);
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
            XElement Client = new XElement("Client_Details", Name, Age, Address, Phone);

            ClientRoot.Add(new XElement("Clients", id, Client, Card));
            ClientRoot.Save(ClientPath);
        }

        public void SaveStudentList(List<BE.Client> ClientList)
        {

            foreach (BE.Client item in ClientList)
            {

                AddClient(item);

            }

        }


        public IEnumerable<Client> GetAllClients()
        {
            LoadData();
            IEnumerable<Client> Clients;
            try
            {
                Clients = (from p in ClientRoot.Elements()
                           select new Client(int.Parse(p.Element("id").Value),
                                            p.Element("Client_Details").Element("Name").Value,
                                            p.Element("Client_Details").Element("Address").Value,
                                            p.Element("Card").Value,
                                            int.Parse(p.Element("Client_Details").Element("Phone").Value),
                                             int.Parse(p.Element("Client_Details").Element("Age").Value)));
    
            }
            catch(Exception)
            {
                Clients = null;
            }

            return Clients;
        }

        public Client GetClient(int id)
        {
            LoadData();
            Client student;
            try
            {
                student = (from p in ClientRoot.Elements()
                           where Convert.ToInt32(p.Element("id").Value) == id
                           select new Client(int.Parse(p.Element("id").Value),
                                             p.Element("Client_Details").Element("Name").Value,
                                             p.Element("Client_Details").Element("Address").Value,
                                             p.Element("Card").Value,
                                             int.Parse(p.Element("Client_Details").Element("Phone").Value),
                                             int.Parse(p.Element("Client_Details").Element("Age").Value))).FirstOrDefault();
            }
            catch
            {
                student = null;
            }
            return student;
        }


        public bool RemoveClient(int id)
        {
            XElement ClientElement;
            try
            {
                ClientElement = (from p in ClientRoot.Elements()
                                  where Convert.ToInt32(p.Element("id").Value) == id
                                  select p).FirstOrDefault();
                ClientElement.Remove();
                ClientElement.Save(ClientPath);
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
}
