using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Dish
    {
        public static string[] NameOfObjects = new string[] {
            "DishId", "Id",
            "DishName","Name",
            "DishSize","Size",
            "DishPrice","Price",
            "HashgachaDish","Hashgacha"


        };




        int _DishId;
        string _DishName;
        float _DishSize;
        float _DishPrice;
        Hashgacha _HashgachaDish;

        public Dish(int _DishId, string _DishName, float _DishSize, float _DishPrice, Hashgacha _HashgachaDish)
        {
            this._DishId = _DishId;
            this._DishName = _DishName;
            this._DishSize = _DishSize;
            this._DishPrice = _DishPrice;
            this._HashgachaDish = _HashgachaDish;
        }

        public void Copy(Dish a)
        {
            this._DishId = a._DishId;
            this._DishName = a._DishName;
            this._DishSize = a._DishSize;
            this._DishPrice = a._DishPrice;
            this._HashgachaDish = a._HashgachaDish;
        }

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
        public Hashgacha HashgachaDish
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
