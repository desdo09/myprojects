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
        static void Main(string[] args)
        {
            IBL BlObject = FactoryBL.GetBL();
            BlObject.AddBranch(new Branch(1, "a", "a", 33, "a", 4, 5, BE.Hashgacha.Kosher));
            BlObject.AddBranch(new Branch(2, "b", "a", 1, "a", 4, 1, BE.Hashgacha.Kosher));

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
