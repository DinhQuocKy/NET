using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodOrderApp.Models;

namespace FoodOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly FoodOrderContext _context;

        public FoodsController(FoodOrderContext context)
        {
            _context = context;
        }

        // GET: api/Foods
        [HttpGet]
        public  ActionResult<IEnumerable<Foods>> GetFoods()
        {
            return  _context.Foods.ToList();
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Foods>> GetFoods(int id)
        {
            var foods = await _context.Foods.FindAsync(id);

            if (foods == null)
            {
                return NotFound();
            }

            return foods;
        }

        // PUT: api/Foods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoods(int id, Foods foods)
        {
            if (id != foods.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(foods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Foods
        [HttpPost]
        public async Task<ActionResult<Foods>> PostFoods(Foods foods)
        {
            _context.Foods.Add(foods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoods", new { id = foods.FoodId }, foods);
        }

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Foods>> DeleteFoods(int id)
        {
            var foods = await _context.Foods.FindAsync(id);
            if (foods == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(foods);
            await _context.SaveChangesAsync();

            return foods;
        }

        private bool FoodsExists(int id)
        {
            return _context.Foods.Any(e => e.FoodId == id);
        }
    }
}
