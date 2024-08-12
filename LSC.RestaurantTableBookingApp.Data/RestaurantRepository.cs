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

        public async Task<IEnumerable<RestaurantBranchModel>> GerRestaurantBranchesByRestaurantIdAsync(int restaurantId)
        {
            var branches = await _dbContext.RestaurantBranches
                .Where(rb => rb.RestaurantId == restaurantId)
                .Select(rb => new RestaurantBranchModel
                {
                    Id = rb.Id,
                    RestaurantId = rb.RestaurantId,
                    Name = rb.Name,
                    Address = rb.Address,
                    Phone = rb.Phone,
                    Email = rb.Email,
                    ImageUrl = rb.ImageUrl,
                })
                .ToListAsync();

            return branches;
        }

        public Task<List<RestaurantModel>> GetAllRestaurantsAsync()
        {
            var restaurants = _dbContext.Restaurants
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

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date)
        {
            var diningTables = await _dbContext.DiningTables
                .Where(dt => dt.RestaurantBranchId == branchId)
                .SelectMany(dt => dt.TimeSlots, (dt, ts) => new
                {
                    dt.RestaurantBranchId,
                    dt.TableName,
                    dt.Capacity,
                    ts.ReservationDay,
                    ts.MealType,
                    ts.TableStatus,
                    ts.Id

                })
                .Where(ts => ts.ReservationDay.Date == date)
                .OrderBy(ts => ts.Id)
                .ThenBy(ts => ts.MealType)
                .ToListAsync();

            return diningTables.Select(dt => new DiningTableWithTimeSlotsModel
            {
                BranchId = dt.RestaurantBranchId,
                ReservationDay = dt.ReservationDay.Date,
                TableName = dt.TableName,
                Capacity = dt.Capacity,
                Mealtype = dt.MealType,
                TableStatus = dt.TableStatus,
                TimeSlotId = dt.Id
            });
        }

        public Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId)
        {
            throw new NotImplementedException();
        }

        Task<List<RestaurantModel>> IRestaurantRepository.GetAllRestaurantsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
