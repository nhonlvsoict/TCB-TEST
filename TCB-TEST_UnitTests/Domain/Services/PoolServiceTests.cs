using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCB_TEST.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;
using Moq;
using TCB_TEST.Domain.Models;
using System.Threading.Tasks;
using TCB_TEST.Domain.Repositories;

namespace TCB_TEST.Domain.Services.Tests
{
   


    [TestClass()]
    public class PoolServiceTests
    {
        /*private IPoolRepository _poolRespository = new PoolRepository();*/

        Mock<IPoolRepository> _poolRespository = new Mock<IPoolRepository>();

        /*public PoolServiceTests(IPoolService poolService)
        {
            _poolService = poolService;
        }*/

        /*[TestMethod()]
        public async Task GetPoolTest()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public async Task AppendOrInsertTest()
        {
            IPoolService _poolService = new PoolService(_poolRespository.Object);
            double[] vlLst = { 2, 3, 4 };
            Pool pool = new Pool(123, new List<double>(vlLst));

            _poolRespository.Setup(p => p.SavePoolList(It.IsAny<List<Pool>>())).ReturnsAsync(true);
            _poolRespository.Setup(p => p.GetPool(It.IsAny<int>())).ReturnsAsync((Pool) null);
            _poolRespository.Setup((p) =>  p.GetPoolList()).ReturnsAsync(new List<Pool>());
            
            
            Assert.IsFalse(await _poolService.AppendOrInsert(pool));
            /*Assert.Fail();*/
        }
    }
}