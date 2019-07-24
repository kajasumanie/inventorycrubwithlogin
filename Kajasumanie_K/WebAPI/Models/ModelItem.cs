using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ModelItem
    {
        public long Id { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public long UnitPrice { get; set; }
        public long UnitAvailable { get; set; }
        public string Date { get; set; }
    }
}
