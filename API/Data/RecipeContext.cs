using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class RecipeContext(DbContextOptions<RecipeContext> options):DbContext(options)
{
    public DbSet<Recipe> Recipes => Set<Recipe>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().HasData(
          new{Id=1,Date="Rafat",BatchNo="Rafat",BatchQty="Rafat",MCNo="Rafat",WorkOrderNo="Rafat",YarnLotNo="Rafat",FType="Rafat",DyeingProcess="Rafat",Remarks="Rafat"},
          new{Id=2,Date="Rafat",BatchNo="Rafat",BatchQty="Rafat",MCNo="Rafat",WorkOrderNo="Rafat",YarnLotNo="Rafat",FType="Rafat",DyeingProcess="Rafat",Remarks="Rafat"}
        );
    }
}
