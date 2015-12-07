using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ordered_Dish
    {
        int _Ordered_DishId;
        int _OrderId;
        int _DishId;
        int _DishAmount;

        public Ordered_Dish(int _Ordered_DishId, int _OrderId, int _DishId, int _DishAmount)
        {
            this._Ordered_DishId = _Ordered_DishId;
            this._OrderId = _OrderId;
            this._DishId = _DishId;
            this._DishAmount = _DishAmount;
        }
        public void copy(Ordered_Dish a)
        {
            this._Ordered_DishId = a._Ordered_DishId;
            this._OrderId = a._OrderId;
            this._DishId = a._DishId;
            this._DishAmount = a._DishAmount;
        }

        public int Ordered_DishId
        {
            get
            {
                return _Ordered_DishId;
            }

            set
            {
                _Ordered_DishId = value;
            }
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

        public int DishAmount
        {
            get
            {
                return _DishAmount;
            }

            set
            {
                _DishAmount = value;
            }
        }

    }
}
