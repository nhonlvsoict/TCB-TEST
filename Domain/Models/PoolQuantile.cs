using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCB_TEST.Domain.Models
{
    public class PoolQuantile
    {
        [JsonPropertyName("poolId")]
        public int Id { get; set; }
        [JsonPropertyName("percentile")]
        public double Percentile { get; set; }
    }
}
