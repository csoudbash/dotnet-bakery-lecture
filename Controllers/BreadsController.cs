using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        // /api/bread
        public IEnumerable<Bread> GetAll()
        {
            return _context.Breads
                .Include(Baker => Baker.bakedBy);
        }

        [HttpPost]
        public IActionResult Create(Bread bread)
        {
            // bread.type = BreadType.Brioche;
            _context.Add(bread);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Create), new { id = bread.id }, bread);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Bread bread = _context.Breads.SingleOrDefault( b => b.id == id );

            if (bread is null) {
                return NotFound();
            }

            _context.Breads.Remove(bread);
            _context.SaveChanges();


            // 204
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Bread bread) {
            Console.WriteLine("in PUT");
            if (id != bread.id) {
                return BadRequest();
            }
              _context.Update(bread);
             _context.SaveChanges();

            return NoContent();
        }

    }

}
