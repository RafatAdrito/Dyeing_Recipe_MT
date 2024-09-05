using System;
using API.DTOs;
using API.Entities;

namespace API.Mapping;

public static class Mapper
{
  public static Recipe ToEntity(this CreateRecipeDTO createRecipe)
  {
    return new Recipe()
    {
      Date = createRecipe.Date,
      BatchNo = createRecipe.BatchNo,
      BatchQty = createRecipe.BatchQty,
      MCNo = createRecipe.MCNo,
      WorkOrderNo = createRecipe.WorkOrderNo,
      YarnLotNo = createRecipe.YarnLotNo,
      FType = createRecipe.FType,
      DyeingProcess = createRecipe.DyeingProcess,
      Remarks = createRecipe.Remarks
    };
  }

  public static Recipe ToEntity(this UpdateRecipeDTO updateRecipe,int id)
  {
    return new Recipe()
    {
      Id=id,
      Date = updateRecipe.Date,
      BatchNo = updateRecipe.BatchNo,
      BatchQty = updateRecipe.BatchQty,
      MCNo = updateRecipe.MCNo,
      WorkOrderNo = updateRecipe.WorkOrderNo,
      YarnLotNo = updateRecipe.YarnLotNo,
      FType = updateRecipe.FType,
      DyeingProcess = updateRecipe.DyeingProcess,
      Remarks = updateRecipe.Remarks
    };
  }

  public static RecipeDTO ToDTO(this Recipe recipe)
  {
    return new(
      recipe.Id,
      recipe.Date,
      recipe.BatchNo,
      recipe.BatchQty,
      recipe.MCNo,
      recipe.WorkOrderNo,
      recipe.YarnLotNo,
      recipe.FType,
      recipe.DyeingProcess,
      recipe.Remarks
    );
  }
}
