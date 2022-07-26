using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using spice_shelf.Models;

namespace spice_shelf.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe Create(Recipe recipeData)
        {
            string sql = @"
      INSERT INTO recipes
      (title, category, subtitle, picture, creatorId)
      VALUES
      (@title, @Category, @subtitle, @picture, @creatorId);
      SELECT LAST_INSERT_ID();";

            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.id = id;
            return recipeData;
        }

        internal Recipe GetById(int recId)
        {
            string sql = @"
            SELECT * FROM recipes WHERE id = @recId";
            return _db.QueryFirstOrDefault<Recipe>(sql, new { recId });
        }

        internal List<Recipe> GetAll()
        {
            string sql = @"SELECT
            recipe.*,
            acc.*
            FROM recipes recipe
            JOIN accounts acc ON recipe.creatorId = acc.id";
            //   List<Recipe> allRecipes = 
            return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
      {
          recipe.Creator = profile;
          return recipe;
      }).ToList();
            //   return allRecipes;
        }

        internal Recipe Edit(Recipe update)
        {
            string sql = @"
            UPDATE recipes
            SET
              picture = @picture,
              title = @title,
              subtitle = @subtitle,
              category = @category
            WHERE id = @id";
            _db.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM recipes WHERE id  = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}