﻿using System;
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
        public Branch(int BranchId, string BranchName, string BranchAddres, string BranchPhone, string BranchManager, int BranchWorkers, int NumOfDeliveryPerson, Hashgacha BranchHashgacha)
        {
            this.BranchId = BranchId;
            this.BranchName = BranchName;
            this.BranchAddres = BranchAddres;
            this.BranchPhone = BranchPhone;
            this.BranchManager = BranchManager;
            this.BranchWorkers = BranchWorkers;
            this.NumOfDeliveryPerson = NumOfDeliveryPerson;
            this.BranchHashgacha = BranchHashgacha;
            List<int> BranchDishes = new List<int>();
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
        string _BranchPhone;
        string _BranchManager;
        int _BranchWorkers;
        int _NumOfDeliveryPerson;
        Hashgacha _BranchHashgacha;
        public List<int> BranchDishes;

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
                if (value < 0)
                    value -= -1;
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

        public string BranchPhone
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
                if (value < 0)
                    value *= -1;
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
                if (value < 0)
                    value *= -1;
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
