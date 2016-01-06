using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace UI_Console_application
{
    class Program
    {
        static bool ValidateCard(string card)
        {
            if (card.Length < 15)
                return false;

            try
            {
                int sum = 0;
                for (int i = 0; i < 15; i += 2)
                {
                    sum = int.Parse(card[i].ToString());
                    if (sum > 10)
                        sum -= 9;
                    card = sum.ToString() + card.Substring(1);
                }
                sum = 0;
                for (int i = 0; i < 16; i++)
                    sum += int.Parse(card[i].ToString());
                return (sum % 10 == 0) ? true : false;
            }
            catch (FormatException)
            {
                throw new FormatException("BL error: Card number is missing!");
            }
        }





        static void Main(string[] args)
        {
            IBL BlObject = FactoryBL.GetBL();
           
            Console.WriteLine("--------------- After delete ----------------");
           
        }
    }
}
