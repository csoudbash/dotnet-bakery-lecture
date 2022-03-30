using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BakersController(ApplicationContext context) {
            _context = context;
        }


// OUR API
        // GET ALL BAKERS
        [HttpGet]
        public IEnumerable<Baker> GetAll()
        {
            Console.WriteLine("get all bakers");
            // no sql
            return _context.Bakers; // return the entire baker table
        }
        // GET 1 BAKER BY ID
        // GET /api/bakers/id
        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id)
        {
            Baker baker = _context.Bakers.SingleOrDefault(baker => baker.id == id);// returning the id of the item that is matching

            if(baker is null) {
                return NotFound(); // res.send status 404
            }
            return baker;
        }
        // POST - ADD A NEW BAKER
        [HttpPost]
        public IActionResult Post(Baker baker)
        {
            //uses a transactions
            _context.Add(baker);
            _context.SaveChanges();// committing the changes to the DB

            // return baker; //would be missing id

            // returns the url to /api/Bakers?id=<new-id-number>
            return CreatedAtAction(nameof(Post), new {id = baker.id }, baker);
        }
        // DELETE A BAKER BY ID
        // PUT - CHANGE A BAKERS NAME BY ID







    }
}
