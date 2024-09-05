using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public record UpdateRecipeDTO([Required]String Date,[Required]String BatchNo, [Required]String BatchQty, [Required]String MCNo, [Required]String WorkOrderNo,[Required]String YarnLotNo, [Required]String FType, [Required]String DyeingProcess, [Required]String Remarks);
