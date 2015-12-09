﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public enum Hashgacha { NotKosher, Kosher, Mehadrin, Badatz };
    public class Order
    {

        int _OrderId;
        DateTime _OrderTime;
        int _BranchId;
        Hashgacha _HashgachaPlace;

        int _ClientId;

        public Order(int _OrderId, DateTime _OrderTime, int _BranchId, Hashgacha _HashgachaPlace, int _ClientId)
        {
            this._OrderId = _OrderId;
            this._OrderTime = _OrderTime;
            this._BranchId = _BranchId;
            this._HashgachaPlace = _HashgachaPlace;
            this._ClientId = _ClientId;
        }
        public void Copy(Order a)
        {
            this._OrderId = a._OrderId;
            this._OrderTime = a._OrderTime;
            this._BranchId = a._BranchId;
            this._HashgachaPlace = a._HashgachaPlace;
            this._ClientId = a._ClientId;
        }

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

        public Hashgacha HashgachaPlace
        {
            get
            {
                return _HashgachaPlace;
            }
            private set
            {
                _HashgachaPlace = value;
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
