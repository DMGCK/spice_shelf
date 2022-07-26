using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using spice_shelf.Models;

namespace spice_shelf.Repositories
{
    public class StepsRepository
    {
        private readonly IDbConnection _db;

        public StepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Step Create(Step stepData)
        {
            string sql = @"
            INSERT INTO steps
            (position, body, recipeId)
            VALUES
            (@position, @body, @recipeId);
            SELECT LAST_INSERT_ID();";

            int id = _db.ExecuteScalar<int>(sql, stepData);
            stepData.id = id;
            return stepData;
        }

        internal List<Step> GetByRecipeId(int recipeId)
        {
            string sql = @"
            SELECT * FROM steps WHERE recipeId = @recipeId";
            List<Step> steps = _db.Query<Step>(sql, new { recipeId }).ToList();
            return steps;
        }
    }
}