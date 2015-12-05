using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //test 5
    enum Hashgacha { Kosher, Mehadrin, Badatz, notKosher };
    public class Order
    {

        int _OrderId;
        DateTime _OrderTime;
        int _BranchId;
        Hashgacha _HashgachaPlace;
        int _NumOfDeliveryPerson;
        int _ClientId7;

        //saa

        //test

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

            set
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
            }
        }

        public int NumOfDeliveryPerson1
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
