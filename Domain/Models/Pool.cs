using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCB_TEST.Domain.Models
{
    public class Pool
    {
        public Pool() { }
        public Pool(int id, List<double> values)
        {
            Id = id;
            Values = values;
        }
        [JsonPropertyName("poolId")] 
        public int Id { get; set; }
        [JsonPropertyName("poolValues")] 
        public List<double> Values { get; set; }
    }
}
