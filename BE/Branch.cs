using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BE
{

    public class Branch
    {
        class BranchDish
        {

            int DishAmount;
            Dish dish;

            public BranchDish(int dishAmount, Dish dish)
            {
                DishAmount = dishAmount;
                this.dish = dish;
            }
        }
        //Set the header name for data grid
        #region NameOfObjects
        public static string[] NameOfObjects = new string[] {
            "BranchId", "Id",
            "BranchName","Name",
            "BranchAddres","Address",
            "BranchPhone","Phone",
            "BranchManager","Manager",
            "BranchWorkers","Workers",
            "NumOfDeliveryPerson","Delivery's persons",
            "BranchHashgacha","Hashgacha"

        };
        #endregion
        #region Constructor and copy function
        /// <summary>
        /// Branch constructor
        /// </summary>
        /// <param name="BranchId">Branch Id</param>
        /// <param name="BranchName">Branch Name</param>
        /// <param name="BranchAddres">Branch address</param>
        /// <param name="BranchPhone">Branch Phone</param>
        /// <param name="BranchManager">Branch manager name</param>
        /// <param name="BranchWorkers">Branch number of workers</param>
        /// <param name="NumOfDeliveryPerson">Branch number of delivery peoples </param>
        /// <param name="BranchHashgacha">Branch Hashgacha (using enum in BE.Hashagacha)</param>
        public Branch(int BranchId, string BranchName, string BranchAddres, int BranchPhone, string BranchManager, int BranchWorkers, int NumOfDeliveryPerson, Hashgacha BranchHashgacha)
        {
            this._BranchId = BranchId;
            this._BranchName = BranchName;
            this._BranchAddres = BranchAddres;
            this._BranchPhone = BranchPhone;
            this._BranchManager = BranchManager;
            this._BranchWorkers = BranchWorkers;
            this._NumOfDeliveryPerson = NumOfDeliveryPerson;
            this._BranchHashgacha = BranchHashgacha;
            List<BranchDish> BranchDishes = new List<BranchDish>();
        }
        /// <summary>
        /// Function to copy from an other Branch
        /// </summary>
        /// <param name="a">The other Branch object</param>
        public void copy(Branch a)
        {
            //this.BranchId = a.BranchId;
            this.BranchName = a.BranchName;
            this.BranchAddres = a.BranchAddres;
            this.BranchPhone = a.BranchPhone;
            this.BranchManager = a.BranchManager;
            this.BranchWorkers = a.BranchWorkers;
            this.NumOfDeliveryPerson = a.NumOfDeliveryPerson;
            this._BranchHashgacha = a._BranchHashgacha;

        }
        #endregion
        #region Objects
        int _BranchId;
        string _BranchName;
        string _BranchAddres;
        int _BranchPhone;
        string _BranchManager;
        int _BranchWorkers;
        int _NumOfDeliveryPerson;
        Hashgacha _BranchHashgacha;
        List<BranchDish> BranchDishes;


        #endregion
        #region Proprieties 
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

        public string BranchName
        {
            get
            {
                return _BranchName;
            }

            set
            {
                _BranchName = value;
            }
        }

        public string BranchAddres
        {
            get
            {
                return _BranchAddres;
            }

            set
            {
                _BranchAddres = value;
            }
        }

        public int BranchPhone
        {
            get
            {
                return _BranchPhone;
            }

            set
            {
                _BranchPhone = value;
            }
        }

        public string BranchManager
        {
            get
            {
                return _BranchManager;
            }

            set
            {
                _BranchManager = value;
            }
        }

        public int BranchWorkers
        {
            get
            {
                return _BranchWorkers;
            }

            set
            {
                _BranchWorkers = value;
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

        public Hashgacha BranchHashgacha
        {
            get
            {
                return _BranchHashgacha;
            }

            set
            {
                _BranchHashgacha = value;
            }

        }

        private List<BranchDish> BranchDishes1
        {
            get
            {
                return BranchDishes;
            }

            set
            {
                BranchDishes = value;
            }
        }
        #endregion
        public override string ToString()
        {

            return "Branch name: " + BranchName
                + "\nBranch addres: " + BranchAddres
                + "\nBranch phone: " + BranchPhone
                + "\nBranch manager: " + BranchManager
                + "\nBranch workers: " + BranchWorkers
                + "\nNumber of delivery persons: " + NumOfDeliveryPerson
                + "\nBranch hashgacha: " + BranchHashgacha;

        }
    }
}
