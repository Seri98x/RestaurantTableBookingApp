using LSC.RestaurantTableBookingApp.Data;

namespace LSC.RestaurantTableBookingApp.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
        }
        public Task<List<Models>> GetAllRestaurantsAsync()
        {
            return _restaurantRepository.GetAllRestaurantsAsync();
        }
    }
}
