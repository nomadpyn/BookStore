using BooksStore.Web.Models;
using BooksStore.Web.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IInventoryRepository _repository;

        public CategoryController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetCategories());
        }

        public IActionResult Details(Guid Id)
        {
            return View(_repository.GetCategory(Id));
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Category category)
        {

            try
            {
                _repository.AddCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(Guid Id) => View(_repository.GetCategory(Id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid Id, [FromBody] Category category)
        {

            try
            {
                _repository.UpdateCategory(Id, category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(Guid Id) => View(_repository.GetCategory(Id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid Id, [FromBody] Category category)
        {

            try
            {
                _repository.DeleteCategory(Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
