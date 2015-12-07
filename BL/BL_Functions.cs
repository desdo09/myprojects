using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BL_Functions : IBL
    {
        IDAL DalObject = FactoryDal.getDal();
        public void addBranch(Branch a)
        {
            DalObject.AddBranch(a);
        }

        public void update(Branch a)
        {
            DalObject.UpdateBranch(a);
        }

        public Branch SearchBranchById(int id)
        {
            return DalObject.SearchBranchById(id);

        }

        public void delete(int id)
        {
            DalObject.DeleteBranch(SearchBranchById(id));
        }

        public List<Branch> GetAllBranch()
        {
            return DalObject.GetAllBranch();
        }

        public List<Client> GetAllClients()
        {
            return DalObject.GetAllClients();
        }
    }
}
