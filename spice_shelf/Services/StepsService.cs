using System.Collections.Generic;
using spice_shelf.Models;
using spice_shelf.Repositories;

namespace spice_shelf.Services
{
    public class StepsService
    {
        StepsRepository _repo;
        RecipesService _rs;
        public StepsService(StepsRepository repo, RecipesService rs)
        {
            _repo = repo;
            _rs = rs;
        }
        internal Step Create(Step stepData, string userId, int recipeId)
        {
            _rs.GetForValidate(recipeId, userId);

            return _repo.Create(stepData);
        }

        internal List<Step> GetByRecipeId(int recipeId)
        {
            _rs.GetById(recipeId);
            List<Step> found = _repo.GetByRecipeId(recipeId);

            return found;
        }
    }
}