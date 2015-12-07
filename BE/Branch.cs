using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BE
{
    //im gay
    public class Branch
    {
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
        public Branch()
        {

        }

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
        }

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



        int _BranchId;
        string _BranchName;
        string _BranchAddres;
        int _BranchPhone;
        string _BranchManager;
        int _BranchWorkers;
        int _NumOfDeliveryPerson;
        Hashgacha _BranchHashgacha;


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
