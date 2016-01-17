using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    
    public class Client
    {
        public static string[] NameOfObjects = new string[] {
            "ClientId", "Id",
            "ClientName","Name",
            "ClientAddress","Address",
            "ClientPhone","Phone",
            "ClientCard","Card",


        };

        int _ClientId;
        string _ClientName;
        string _ClientAddress;
        string _ClientCard;
        string _ClientPhone;
        int _ClientAge;

        /// <summary>
        /// Client constructor
        /// </summary>
        /// <param name="_ClientId">Client id</param>
        /// <param name="_ClientName">Client name</param>
        /// <param name="_ClientAddress">Client Address</param>
        /// <param name="_ClientCard">Client credit card</param>
        /// <param name="Phone">Client phone</param>
        /// <param name="_ClientAge">Client age</param>
        public Client(int _ClientId, string _ClientName, string _ClientAddress, string _ClientCard, string Phone, int _ClientAge)
        {
            this.ClientId = _ClientId;
            this.ClientName = _ClientName;
            this.ClientAddress = _ClientAddress;
            this.ClientCard = _ClientCard;
            this.ClientPhone = Phone;
            this.ClientAge = _ClientAge;
        }
        public void copy(Client a)
        {
            this._ClientId = a.ClientId;
            this._ClientName = a.ClientName;
            this._ClientAddress = a.ClientAddress;
            this._ClientCard = a.ClientCard;
        }
        public int ClientId
        {
            get
            {
                return _ClientId;
            }

            set
            {
                if (value < 0) value *= -1;
                _ClientId = value;
            }
        }

        public string ClientName
        {
            get
            {
                return _ClientName;
            }

            set
            {
                _ClientName = value;
            }
        }

        public string ClientAddress
        {
            get
            {
                return _ClientAddress;
            }

            set
            {
                _ClientAddress = value;
            }
        }
        public string ClientPhone
        {
            get
            {
                return _ClientPhone;
            }

            set
            {
               

                _ClientPhone = value;
            }
        }
        public string ClientCard
        {
            get
            {
                return _ClientCard;
            }

            set
            {
                _ClientCard = value;
            }
        }

        public int ClientAge
        {
            get
            {
                return _ClientAge;
            }

            set
            {
                _ClientAge = value;
            }
        }

        public override string ToString()
        {
            string str = "Program name   						               			     			BSH\n\n\n";
            str += "Client Details:\n";
            str += "=========================================================================================================\n";
            str += " Client id:   " + ClientId + "             Client Name:" + ClientName + "\n\n";
           // str += "Client Address:   "+	ClientAddress +  "                             Last 4 card number: " + ClientCard.Split('=')[0].Substring(12);
                                    




            return str;
        }
    }
}
