using System;
using System.Collections.Generic;
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



    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
        List<Recipe> allRecipes = _rs.GetAll();
        return allRecipes;
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetById(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Recipe singleRecipe = _rs.GetById(id, userInfo.Id);
        return Ok(singleRecipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> Edit(int id, [FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.id = id;
        recipeData.creatorId = userInfo.Id;
        Recipe update = _rs.Edit(recipeData);
        return update;
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> Delete(int id)
    {
      {
        try
        {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          Recipe deletedRecipe = _rs.Delete(id, userInfo.Id);
          return Ok(deletedRecipe);

        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
      }
    }

  }
}