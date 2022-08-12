using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCB_TEST.Domain.Models;

namespace TCB_TEST.Domain.Services
{
    public interface IPoolService
    {
        Task<List<Pool>> GetPoolList();
        Task<Pool> GetPool(int id);
        Task<bool> AppendOrInsert(Pool pool);
        double Percentile(List<double> list, double p);
    }
}
