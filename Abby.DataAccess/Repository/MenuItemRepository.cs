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
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(MenuItem menuItem)
        {
            //Use if only certain fields need to updated
            var objFromDb = _db.MenuItem.FirstOrDefault(f => f.Id == menuItem.Id);
            objFromDb.Name = menuItem.Name;
            objFromDb.Description = menuItem.Description;
            objFromDb.Price = menuItem.Price;
            objFromDb.CategoryId = menuItem.CategoryId;
            objFromDb.FoodTypeId = menuItem.FoodTypeId;
            if(objFromDb.Image != null)
            {
                objFromDb.Image = menuItem.Image;
            }

            
        }
    }
}
