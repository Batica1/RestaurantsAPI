using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Presistance;
using Restaurants.API.Controllers;


namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantsDbContext _dbContext;

        public RestaurantsController(RestaurantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/restaurants
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            var restaurants = _dbContext.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            return Ok(restaurants);
        }

        // GET: api/restaurants/{id}
        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id)
        {
            var restaurant = _dbContext.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // POST: api/restaurants
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] Restaurant restaurant)
        {
            if (restaurant == null)
            {
                return BadRequest();
            }

            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

        // PUT: api/restaurants/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] Restaurant restaurant)
        {
            if (restaurant == null || restaurant.Id != id)
            {
                return BadRequest();
            }

            var existingRestaurant = await _dbContext.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (existingRestaurant == null)
            {
                return NotFound();
            }

            // Update the restaurant properties (e.g., Address, Dishes, etc.)
            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Description = restaurant.Description;
            existingRestaurant.Address = restaurant.Address;
            existingRestaurant.Dishes = restaurant.Dishes;

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/restaurants/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _dbContext.Restaurants
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            // Remove the restaurant from the database
            _dbContext.Restaurants.Remove(restaurant);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
