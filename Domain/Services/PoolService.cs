using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCB_TEST.Domain.Models;
using TCB_TEST.Domain.Repositories;
using TCB_TEST.Helpers;

namespace TCB_TEST.Domain.Services
{
    public class PoolService : IPoolService
    {
        private readonly IPoolRepository _poolRespository;
        
        public PoolService(IPoolRepository poolRepository)
        {
            _poolRespository = poolRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pool"></param>
        /// <returns type="bool"> true if appened, false if Inserted </returns>
        public async Task<bool> AppendOrInsert(Pool pool)
        {
            try
            {


                var extPool = await _poolRespository.GetPool(pool.Id);
                List<Pool> poolLst = await GetPoolList();
                if (extPool != null)
                {
                    // append thoi
                    poolLst = poolLst.FindAll(e => e.Id != extPool.Id);
                    extPool.Values.AddRange(pool.Values);
                    poolLst.Add(extPool);

                    _poolRespository.SavePoolList(poolLst);

                    return true;


                }
                else
                {
                    //them moi pool
                    poolLst.Add(pool);
                    await _poolRespository.SavePoolList(poolLst);
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Pool> GetPool(int id)
        {
            return  await _poolRespository.GetPool(id);
        }

        public async Task<List<Pool>> GetPoolList()
        {
            
            return await _poolRespository.GetPoolList();
        }

        public double Percentile(List<double> list, double p)
        {
            list.Sort();
            return  Helpers.Helpers.Percentile(list.ToArray(), p);
        }
    }
}
