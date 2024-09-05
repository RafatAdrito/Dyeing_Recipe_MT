using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public record CreateRecipeDTO([Required]String Date,[Required]String BatchNo, [Required]String BatchQty, [Required]String MCNo, [Required]String WorkOrderNo,[Required]String YarnLotNo, [Required]String FType, [Required]String DyeingProcess, [Required]String Remarks);
}