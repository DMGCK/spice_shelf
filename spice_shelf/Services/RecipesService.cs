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
  }
}