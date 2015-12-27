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
            BlObject.AddBranch(new Branch(1, "a", "a", 33, "a", 4, 5, BE.Hashgacha.Kosher));
            BlObject.AddBranch(new Branch(2, "b", "a", 1, "a", 4, 1, BE.Hashgacha.Kosher));
            Console.WriteLine("---------------Card Verification ----------------");
            try {
                if (ValidateCard("4998774833/37162"))
                    Console.WriteLine("true");
                else
                    Console.WriteLine("False");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType() + ": " +ex.Message);
            }

            Console.WriteLine("--------------- Var Test ----------------");
            Func<Branch, bool> predicate = ((x => x.BranchId < x.BranchPhone));
            var list = from item in BlObject.GetAllBranch()
                       where predicate(item)
                       select item;
            foreach (Branch b in list)
            {
                Console.Write(b.BranchId + "     ");
            }
            Console.WriteLine();
            Console.WriteLine("--------------- After Var Test ----------------");
            Console.WriteLine("1: \n" + BlObject.SearchBranchById(1));
            Console.WriteLine("2:\n" + BlObject.SearchBranchById(2));
            Console.ReadKey();
            Console.WriteLine("--------------- After changes ----------------");
            BlObject.UpdateBranch(new Branch(1, "b", "a", 33, "b", 4, 5, BE.Hashgacha.Kosher));
            Console.WriteLine("1: \n" + BlObject.SearchBranchById(1));
            Console.WriteLine("2:\n" + BlObject.SearchBranchById(2));
            Console.WriteLine("--------------- After delete ----------------");
            BlObject.DeleteBranch(1);
            Console.WriteLine("1: \n" + BlObject.SearchBranchById(1));
            Console.WriteLine("2:\n" + BlObject.SearchBranchById(2));
        }
    }
}
