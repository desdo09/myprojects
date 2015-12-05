using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    enum Hashgacha { Kosher, Mehadrin, Badatz };
   public class Order
    {
       
        int OrderId;
        DateTime OrderTime;
        int branchId;
        Hashgacha HashgachaPlace;
        int NumOfDeliveryPerson;
        int ClientId;

    }
}
