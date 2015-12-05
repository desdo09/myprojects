using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Dish
    {
        int _DishId;
        string _DishName;
        float _DishSize;
        float _DishPrice;
        Hashgacha _HashgachaDish;

        public int DishId
        {
            get
            {
                return _DishId;
            }

            set
            {
                _DishId = value;
            }
        }

        public string DishName
        {
            get
            {
                return _DishName;
            }

            set
            {
                _DishName = value;
            }
        }

        public float DishSize
        {
            get
            {
                return _DishSize;
            }

            set
            {
                _DishSize = value;
            }
        }

        public float DishPrice
        {
            get
            {
                return _DishPrice;
            }

            set
            {
                _DishPrice = value;
            }
        }

        internal Hashgacha HashgachaDish
        {
            get
            {
                return _HashgachaDish;
            }

            set
            {
                _HashgachaDish = value;
            }
        }
    }
}
