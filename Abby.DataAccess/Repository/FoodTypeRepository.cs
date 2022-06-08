using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(FoodType foodType)
        {
            //Use if only certain fields need to updated
            var objFromDb = _db.FoodType.FirstOrDefault(f => f.Id == foodType.Id);
            objFromDb.Name = foodType.Name;
            

        }
    }
}
