using LSC.RestaurantTableBookingApp.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LSC.RestaurantTableBookingApp.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantTableBookingDbContext _dbContext;
        public RestaurantRepository(RestaurantTableBookingDbContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public async Task<List<RestaurantModel>> GetAllRestaurantsAsync()
        {
            var restaurants = await _dbContext.Restaurants
                .OrderBy(x => x.Name)
                .Select(r => new RestaurantModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Address = r.Address,
                    Phone = r.Phone,
                    Email = r.Email,
                    ImageUrl = r.ImageUrl
                }).ToListAsync();


            return restaurants;
        }
    }
}
