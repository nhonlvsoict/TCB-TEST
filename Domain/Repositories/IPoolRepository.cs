using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCB_TEST.Domain.Models;

namespace TCB_TEST.Domain.Repositories
{
    public interface IPoolRepository
    {
        Task<List<Pool>> GetPoolList();
        Task<bool> SavePoolList(IEnumerable<Pool> pLst);
        Task<Pool> GetPool(int id);
        /*Task<bool> PoolExist(int id);*/
    }
}
