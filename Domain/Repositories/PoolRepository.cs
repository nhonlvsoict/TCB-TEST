using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TCB_TEST.Domain.Models;

namespace TCB_TEST.Domain.Repositories
{
    public class PoolRepository : IPoolRepository
    {
        readonly string dataPath = @"data.json";
        public async Task<Pool> GetPool(int id)
        {
            List<Pool> poolLst = await GetPoolList();
            Pool ext = poolLst.Find(a => a.Id == id);
            return ext;
        }

        public async Task<List<Pool>> GetPoolList()
        {
            try
            {
                //todo lam cache o day

                if (File.Exists(dataPath))
                {
                    // read JSON directly from a file
                    using StreamReader file = File.OpenText(dataPath);
                    using JsonTextReader reader = new JsonTextReader(file);

                    var o2 = JToken.ReadFrom(reader).ToObject<List<Pool>>();
                    return o2;
                }
                return new List<Pool>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> SavePoolList(IEnumerable<Pool> pLst)
        {
            try
            {
                /*var data = JArray.FromObject(pLst.Select(a => new Pool { Id = a.Id, Values = a.Values }));*/
                JArray data = JArray.FromObject(pLst);
                // write JSON directly to a file
                using (StreamWriter file = File.CreateText(dataPath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    data.WriteTo(writer);
                }
                return true;
            } catch(Exception e)
            {
                throw e;
            }
        }

    
    }
}
