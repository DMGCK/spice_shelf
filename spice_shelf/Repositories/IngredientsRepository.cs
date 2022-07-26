using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using spice_shelf.Interfaces;
using spice_shelf.Models;

namespace spice_shelf.Repositories
{
  public class IngredientsRepository : IREPO<Ingredient>
  {
    public Ingredient Create(Ingredient tData)
    {
      throw new NotImplementedException();
    }

    public void Delete(int Id)
    {
      throw new NotImplementedException();
    }

    public void Edit(Ingredient data)
    {
      throw new NotImplementedException();
    }

    public List<Ingredient> GetAll()
    {
      throw new NotImplementedException();
    }

    public Ingredient GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}