using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ordered_Dish
    {
        int _OrderId;
        int _DishId;
        int _DishAmount;

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
