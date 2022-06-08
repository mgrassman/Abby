using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public FoodType FoodType { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(f => f.Id == id);
            //Category = _db.Category.FirstOrDefault(f => f.Id == id);
            //Category = _db.Category.SingleOrDefault(f => f.Id == id);
            //Category = _db.Category.Where(f => f.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            var foodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(f => f.Id == FoodType.Id);
            if (foodTypeFromDb != null)
            {
                _unitOfWork.FoodType.Remove(foodTypeFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Food type deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
