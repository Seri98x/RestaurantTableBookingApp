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

        [HttpGet("branches/{restaurantId}")]
        [ProducesResponseType(200, Type = typeof(List<RestaurantBranchModel>))]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<RestaurantBranchModel>>> GetRestaurantBranchesByRestaurantIdAsync(int restaurantId)
        {

            var branches = await _restaurantService.GetRestaurantBranchesByRestaurantIdAsync(restaurantId);
            if (branches == null)
            {
                return NotFound();
            }

            return Ok(branches);
        }

        [HttpGet("diningtables/{branchId}")]
        [ProducesResponseType(200, Type = typeof(List<DiningTableWithTimeSlotsModel>))]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<DiningTableWithTimeSlotsModel>>> GetDiningTablesByBranchAsync(int branchId)
        {

            var diningTables = await _restaurantService.GetDiningTablesByBranchAsync(branchId);
            if (diningTables == null)
            {
                return NotFound();
            }

            return Ok(diningTables);
        }

        [HttpGet("diningtables/{branchId}/date")]
        [ProducesResponseType(200, Type = typeof(List<DiningTableWithTimeSlotsModel>))]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<DiningTableWithTimeSlotsModel>>> GetDiningTablesByBranchAndDateAsync(int branchId, DateTime date)
        {

            var diningTables = await _restaurantService.GetDiningTablesByBranchAsync(branchId);
            if (diningTables == null)
            {
                return NotFound();
            }

            return Ok(diningTables);
        }
    }
}
