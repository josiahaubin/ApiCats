using System;
using System.Collections.Generic;
using cats.DB;
using cats.Models;
using Microsoft.AspNetCore.Mvc;


namespace cats.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatsController : ControllerBase
    {
        //NOTE THIS IS NOT HOW TO REALLY DO IT!!!!
        public List<Cat> Cats { get; set; } = FakeDB.Cats;


        [HttpGet]
        public ActionResult<IEnumerable<Cat>> Get()
        {
            return Ok(Cats);
        }

        [HttpGet("{id}")]
        public ActionResult<Cat> Get(string id)
        {
            try
            {
                Cat c = Cats.Find(cat => cat.Id == id);
                if (c == null) { throw new Exception("Invalid Id"); }
                return Ok(c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{index}/index")] // '/:index/index'
        public ActionResult<Cat> Get(int index)
        {
            try
            {
                Cat c = Cats[index];
                return Ok(c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<Cat> Post([FromBody] Cat cat)//req.body
        {
            try
            {
                Cats.Add(cat);
                return Ok(cat);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult<Cat> Edit(string id, [FromBody] Cat newCat)
        {
            try
            {

                Cat catToEdit = Cats.Find(cat => cat.Id == id);
                if (catToEdit == null)
                {
                    throw new ThisIsDog("Woof");
                }
                newCat.Id = catToEdit.Id;
                Cats[Cats.IndexOf(catToEdit)] = newCat;
                return Ok(newCat);
            }
            catch (ThisIsDog ae)
            {
                return Unauthorized(ae.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            try
            {
                int removed = Cats.RemoveAll(cat => cat.Id == id);
                if (removed == 0)
                {
                    throw new Exception("Invalid Id");
                }
                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
