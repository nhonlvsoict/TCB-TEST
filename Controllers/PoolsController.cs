using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TCB_TEST.Domain.Models;
using TCB_TEST.Domain.Services;
using TCB_TEST.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCB_TEST.Controllers
{
    [Route("api")]
    [ApiController]
    public class PoolsController : ControllerBase
    {
        private readonly IPoolService _poolService;
        public PoolsController(IPoolService poolService) => _poolService = poolService;
        
        /// <summary>
        /// Append value or insert new pool to DB
        /// </summary>
        /// <param name="pool"></param>
        /// <returns>Stautus appended or inserted</returns>
        [HttpPost("appendorinsert")]
        public async Task<IActionResult> AppendOrInsert(Pool pool)
        {
            /*var poolLst=  await _poolService.GetPoolList();*/
            /*)*/
            try
            {
                if (await _poolService.AppendOrInsert(pool)) {
                    return Ok(new { status = Constants.POOL_APPENDED });
                } else return Ok(new { status = Constants.POOL_INSERTED }); 
               
            } catch(Exception e)
            {
                /*Response.StatusCode = (int)HttpStatusCode.InternalServerError;*/
                return StatusCode(500, e.Message);
            }
            
            
        }
        /// <summary>
        /// Query quantile value and the numbel of element in a pool
        /// </summary>
        /// <param name="poolQuantile"></param>
        /// <returns></returns>
        [HttpPost("querypercentile")]
        public async Task<IActionResult> QueryPercentile(PoolQuantile poolQuantile)
        {
           
            try
            {
                Pool pool = await _poolService.GetPool(poolQuantile.Id);
                if (pool != null)
                {
                    double cal_per = _poolService.Percentile(pool.Values, poolQuantile.Percentile);
                    return Ok(new { calculated_quantile  = cal_per, elements_count = pool.Values.ToArray().Length });
                   
                }
                else
                {
                    return StatusCode(400, "Pool Id does not exist");
                }

            }
            catch (Exception e)
            {
                
                return StatusCode(500, e.Message);
            }


        }

    }
}
