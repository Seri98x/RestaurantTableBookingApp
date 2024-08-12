using LSC.RestaurantTableBookingApp.Core.ViewModels;

namespace LSC.RestaurantTableBookingApp.Data
{
    public interface IRestaurantRepository
    {
        Task<List<RestaurantModel>> GetAllRestaurantsAsync();
        Task<IEnumerable<RestaurantBranchModel>> GerRestaurantBranchesByRestaurantIdAsync(int restaurantId);
        Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date);
        Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId);
    }
}
