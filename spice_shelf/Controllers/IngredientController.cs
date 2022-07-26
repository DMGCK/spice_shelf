using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spice_shelf.Models;
using spice_shelf.Services;
using CodeWorks.Auth0Provider;

namespace spice_shelf.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientController : ControllerBase
  {
    private readonly IngredientsService _is;

    public IngredientController(IngredientsService iss)
    {
      _is = iss;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Ingredient newR = _is.Create(ingredientData, userInfo.Id);
        return Ok(newR);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Edit(int id, [FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        ingredientData.id = id;
        ingredientData.creatorId = userInfo.Id;
        Ingredient update = _is.Edit(ingredientData);
        return update;
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Delete(int id)
    {
      {
        try
        {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          Ingredient deletedIngredient = _is.Delete(id, userInfo.Id);
          return Ok(deletedIngredient);

        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
      }
    }
  }
}