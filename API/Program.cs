using API.Data;
using API.DTOs;
using API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString=builder.Configuration.GetConnectionString("Recipe");
builder.Services.AddSqlite<RecipeContext>(connString);
builder.Services.AddCors(options=>{
  options.AddPolicy("AllowAngularOrigins",builder=>{
    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
  });
});

var app = builder.Build();
app.UseCors("AllowAngularOrigins");

app.RecipeEndPoints();

app.MigrateDB();

app.Run();
