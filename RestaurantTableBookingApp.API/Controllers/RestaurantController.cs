using LSC.RestaurantTableBookingApp.Core.ViewModels;
using LSC.RestaurantTableBookingApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace LSC.RestaurantTableBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }

        [HttpGet("restaurants")]
        [ProducesResponseType(200, Type = typeof(List<RestaurantModel>))]

        public async Task<ActionResult> GetAllRestaurantsAsync()
        {

            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
    }
}
