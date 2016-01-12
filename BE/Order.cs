using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BE
{

    public enum Hashgacha { NotKosher, Kosher, Mehadrin, Badatz };
    [AttributeUsage(AttributeTargets.Property)]
    public class Order: Attribute
    {
        #region Objects
      
        int _OrderId;
        DateTime _OrderTime;
        int _BranchId;
        Hashgacha _HashgachaPlace;
        int _ClientId;
        float _OrderPrice;
        String remark;
        #endregion
        #region Constructor and copy Function
        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="_OrderId">Order Id</param>
        /// <param name="_OrderTime">Order Time: time made the order.\nUsing DateTime</param>
        /// <param name="_BranchId"></param>
        /// <param name="_HashgachaPlace">Branch hashgacha (Be.Hashgacha)</param>
        /// <param name="_ClientId">Id client that made the delivery</param>
        /// <param name="_OrderPrice"> Order total price</param>
        public Order(int _OrderId, DateTime _OrderTime, int _BranchId, Hashgacha _HashgachaPlace, int _ClientId, float _OrderPrice, String remark)
        {

            this.OrderId = _OrderId;
            this.OrderTime = _OrderTime;
            this.BranchId = _BranchId;
            this.HashgachaPlace = _HashgachaPlace;
            this.ClientId = _ClientId;
            this.OrderPrice = _OrderPrice;
            this.Remark =  remark;

        }
        //public override static  void operator[](int a){
        //}

        public void Copy(Order a)
        {
            this._OrderId = a._OrderId;
            this._OrderTime = a._OrderTime;
            this._BranchId = a._BranchId;
            this._HashgachaPlace = a._HashgachaPlace;
            this._ClientId = a._ClientId;
            this._OrderPrice = a._OrderPrice;
            this.Remark = a.Remark;
        }
        #endregion
        #region Proprieties
        
        public int OrderId
        {
            get
            {
                return _OrderId;
            }

            set
            {
                if (value < 0) value *= -1;

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
                if (value < 0) value *= -1;

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

        public float OrderPrice
        {
            get
            {
                return _OrderPrice;
            }

            set
            {
                if (value < 0) value *= -1;

                _OrderPrice = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }
        #endregion
    }
}
