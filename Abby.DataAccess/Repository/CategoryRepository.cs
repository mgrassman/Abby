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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Category category)
        {
            //Use if only certain fields need to updated
            var objFromDb = _db.Category.FirstOrDefault(f => f.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;

        }
    }
}
