using System.Collections.Generic;
using cats.Models;
using Microsoft.AspNetCore.Mvc;
using cats.DB;
using System;

namespace ApiCats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogsController : ControllerBase
  {
    public List<Dog> Dogs { get; set; } = FakeDB.Dogs;
    [HttpGet]
    public ActionResult<Dog> Get()
    {
      try
      {
        return Ok(Dogs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}