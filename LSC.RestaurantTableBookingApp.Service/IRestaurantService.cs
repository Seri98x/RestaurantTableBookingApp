namespace LSC.RestaurantTableBookingApp.Service
{
    public interface IRestaurantService
    {
        Task<List<Models>> GetAllRestaurantsAsync();

    }
}
