using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public required String Date { get; set; }
        public required String BatchNo { get; set; }
        public required String BatchQty { get; set; }
        public required String MCNo { get; set; }
        public required String WorkOrderNo { get; set; }
        public required String YarnLotNo { get; set; }
        public required String FType { get; set; }
        public required String DyeingProcess { get; set; }
        public required String Remarks { get; set; }
    }
}