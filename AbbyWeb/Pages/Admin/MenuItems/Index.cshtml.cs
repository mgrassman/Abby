
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AbbyWeb.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public IEnumerable<MenuItem> MenuItems { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll();
        }
    }
}
