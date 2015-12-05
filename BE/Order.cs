using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    enum Hashgacha { NotKosher, Kosher, Mehadrin, Badatz };
    public class Order
    {

        int _OrderId;
        DateTime _OrderTime;
        int _BranchId;
        Hashgacha _HashgachaPlace;
        int _NumOfDeliveryPerson;
        int _ClientId;


        public int OrderId
        {
            get
            {
                return _OrderId;
            }

            set
            {
                _OrderId = value;
            }
        }

        public DateTime OrderTime
        {
            get
            {
                return _OrderTime;
            }

            private set
            {
                _OrderTime = value;
            }
        }

        public int BranchId
        {
            get
            {
                return _BranchId;
            }

            set
            {
                _BranchId = value;
            }
        }

        public String HashgachaPlace
        {
            get
            {
                return _HashgachaPlace.ToString();
            }
            private set
            {
                switch (value)
                {
                    case "Not Kosher":
                        _HashgachaPlace = Hashgacha.NotKosher;
                        break;
                    case "NotKosher":
                        _HashgachaPlace = Hashgacha.NotKosher;
                        break;
                    case "Kosher":
                        _HashgachaPlace = Hashgacha.Kosher;
                        break;
                    case "Mehadrin":
                        _HashgachaPlace = Hashgacha.Mehadrin;
                        break;
                    case "Badatz":
                        _HashgachaPlace = Hashgacha.Badatz;
                        break;
                    default:
                        break;
                }
            }
        }

        public int NumOfDeliveryPerson
        {
            get
            {
                return _NumOfDeliveryPerson;
            }

            set
            {
                _NumOfDeliveryPerson = value;
            }
        }

        public int ClientId1
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

    }
}
