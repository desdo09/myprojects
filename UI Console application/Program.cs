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
            BlObject.addBranch(new Branch(1, "a", "a", 33, "a", 4, 5, BE.Hashgacha.Kosher));
            BlObject.addBranch(new Branch(2, "b", "a", 33, "a", 4, 5, BE.Hashgacha.Kosher));
            Console.WriteLine("1: \n"+BlObject.SearchBranchById(1));
            Console.WriteLine("2:\n"+BlObject.SearchBranchById(2));
            Console.ReadKey();
            Console.WriteLine("--------------- After changes ----------------");
            BlObject.update(new Branch(1, "b", "a", 33, "b", 4, 5, BE.Hashgacha.Kosher));
            Console.WriteLine("1: \n" + BlObject.SearchBranchById(1));
            Console.WriteLine("2:\n" + BlObject.SearchBranchById(2));
            Console.WriteLine("--------------- After delete ----------------");
            BlObject.delete(1);
            Console.WriteLine("1: \n" + BlObject.SearchBranchById(1));
            Console.WriteLine("2:\n" + BlObject.SearchBranchById(2));
        }
    }
}
