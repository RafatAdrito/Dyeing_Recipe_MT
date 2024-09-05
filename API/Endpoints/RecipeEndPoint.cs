using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints
{
    public static class RecipeEndPoint
    {
        const string GetRecipeEndPointName = "GetRecipe";
        public static RouteGroupBuilder RecipeEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("recipes").WithParameterValidation();
            group.MapGet("/", (RecipeContext dbcontext) =>
                dbcontext.Recipes.Select(recipe => recipe.ToDTO()).AsNoTracking()
            );

            group.MapGet("/{id}", (int id, RecipeContext dbcontext) =>
            {
                Recipe? recipe = dbcontext.Recipes.Find(id);
                return recipe is null ? Results.NotFound() : Results.Ok(recipe.ToDTO());
            }
            ).WithName(GetRecipeEndPointName);

            group.MapPost("/", (CreateRecipeDTO createRecipe, RecipeContext dbcontext) =>
            {
                Recipe recipe = createRecipe.ToEntity();
                dbcontext.Recipes.Add(recipe);
                dbcontext.SaveChanges();
                return Results.CreatedAtRoute(GetRecipeEndPointName, new { id = recipe.Id }, recipe.ToDTO());
            });

            group.MapPut("/{id}", (int id, UpdateRecipeDTO updateRecipe, RecipeContext dbcontext) =>
            {
                var existingRecipe = dbcontext.Recipes.Find(id);
                if (existingRecipe == null)
                {
                    return Results.NotFound();
                }
                dbcontext.Entry(existingRecipe).CurrentValues.SetValues(updateRecipe.ToEntity(id));
                dbcontext.SaveChanges();
                return Results.Ok();
            });


            group.MapDelete("/{id}", (int id, RecipeContext dbcontext) =>
            {
                dbcontext.Recipes.Where(recipe => recipe.Id == id).ExecuteDelete();
                return Results.NoContent();
            });

            return group;
        }
    }
}