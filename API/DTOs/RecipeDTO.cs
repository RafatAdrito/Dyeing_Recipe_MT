using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public record RecipeDTO(int Id,String Date, String BatchNo, String BatchQty, String MCNo, String WorkOrderNo,String YarnLotNo, String FType, String DyeingProcess, String Remarks);
}