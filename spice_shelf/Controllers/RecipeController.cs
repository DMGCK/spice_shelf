using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spice_shelf.Models;
using spice_shelf.Services;

namespace spice_shelf.Controllers
{
  [ApiController]
  [Route(("api/[controller]"))]
  [Authorize]
  public class RecipeController : ControllerBase
  {
    private readonly RecipesService _rs;
    public RecipeController(RecipesService rs)
    {
      _rs = rs;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Recipe newR = _rs.Create(recipeData, userInfo.Id);
        return Ok(newR);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    // [HttpGet]
    // public ActionResult<List<Recipe>> GetAll()
    // {
    //   try
    //   {

    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

  }
}