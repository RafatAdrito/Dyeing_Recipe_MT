using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class DataExtensions
{
  public static void MigrateDB(this WebApplication app){
    using var scope=app.Services.CreateScope();
    var dbContext=scope.ServiceProvider.GetRequiredService<RecipeContext>();
    dbContext.Database.Migrate();
  }
}
