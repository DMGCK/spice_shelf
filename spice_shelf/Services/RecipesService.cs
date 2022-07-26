using System;
using System.Collections.Generic;
using spice_shelf.Models;
using spice_shelf.Repositories;

namespace spice_shelf.Services
{
    public class RecipesService
    {
        RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe Create(Recipe recipeData, string userId)
        {
            recipeData.creatorId = userId;
            return _repo.Create(recipeData);
        }

        internal List<Recipe> GetAll()
        {
            return _repo.GetAll();
        }

        internal Recipe GetById(int recId)
        {
            Recipe found = _repo.GetById(recId);
            if (found == null)
            {
                throw new Exception("Invalid ID");
            }

            return found;
        }

        internal Recipe GetForValidate(int recId, string userId)
        {
            Recipe found = _repo.GetById(recId);
            if (found == null)
            {
                throw new Exception("Invalid ID");
            }

            if (found.creatorId != userId)
            {
                throw new Exception("Forbidden");
            }
            return found;
        }

        internal Recipe Edit(Recipe recipeData)
        {
            Recipe original = GetForValidate(recipeData.id, recipeData.creatorId);

            original.picture = recipeData.picture ?? original.picture;
            original.title = recipeData.title ?? original.title;
            original.subtitle = recipeData.subtitle ?? original.subtitle;
            original.category = recipeData.category ?? original.category;

            _repo.Edit(original);

            return original;
        }

        internal Recipe Delete(int id, string creatorId)
        {
            Recipe original = GetForValidate(id, creatorId);
            _repo.Delete(id);
            return original;

        }
    }
}