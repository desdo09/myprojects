using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Client
    {
        int _ClientId;
        string _ClientName;
        string _ClientAddress;
        double _ClientCard;

        public Client(int _ClientId, string _ClientName, string _ClientAddress, double _ClientCard)
        {
            this._ClientId = _ClientId;
            this._ClientName = _ClientName;
            this._ClientAddress = _ClientAddress;
            this._ClientCard = _ClientCard;
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

        public double ClientCard
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
    }
}
