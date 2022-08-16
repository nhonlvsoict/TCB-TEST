using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCB_TEST.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TCB_TEST.Domain.Models;
using System.Threading.Tasks;

namespace TCB_TEST.Domain.Repositories.Tests
{
    [TestClass()]
    public class PoolRepositoryTests
    {
        [TestMethod()]
        public async Task SavePoolListTest()
        {
            IPoolRepository poolRe = new PoolRepository();
            double[] vlLst = { 2, 3, 4 };
            Pool pool = new Pool(123, new List<double>(vlLst));
            List<Pool> pooLst = new List<Pool>();
            pooLst.Add(pool);
            var r = await poolRe.SavePoolList(pooLst);
            Assert.IsNotNull(r);
        }
    }
}