using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL
{
    public interface IBL
    {
        void addBranch(Branch a);
        void update(Branch a);
        Branch SearchBranchById(int id);
        void delete(int id);
        List<Branch> GetAllBranch();
        List<Client> GetAllClients();
    }
}
