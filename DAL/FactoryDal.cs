using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        public static IDAL getDal()
        {
            
            // Singleton Pattern - use Instance
            return DAL_List.Instance;
        }
    }
}
