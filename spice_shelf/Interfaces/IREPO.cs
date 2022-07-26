using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace spice_shelf.Interfaces
{
  public interface IREPO<T>
  {
    public T Create(T tData);
    public List<T> GetAll();
    public T GetById(int id);
    public void Edit(T data);
    public void Delete(int Id);
  }
}