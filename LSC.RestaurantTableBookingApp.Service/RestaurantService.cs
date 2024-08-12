using LSC.RestaurantTableBookingApp.Core.ViewModels;
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

        public Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchesByRestaurantIdAsync(int restaurantId)
        {
            return _restaurantRepository.GetRestaurantBranchesByRestaurantIdAsync(restaurantId);
        }

        public Task<List<RestaurantModel>> GetAllRestaurantsAsync()
        {
            return _restaurantRepository.GetAllRestaurantsAsync();
        }

        public Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date)
        {
            return _restaurantRepository.GetDiningTablesByBranchAsync(branchId, date);
        }

        public Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId)
        {
            return _restaurantRepository.GetDiningTablesByBranchAsync(branchId);
        }
    }
}
