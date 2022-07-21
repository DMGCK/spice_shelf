using System.Data;
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
  }
}