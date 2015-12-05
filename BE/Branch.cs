using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Branch
    {
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

        internal Hashgacha BranchHashgacha
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
    }
}
