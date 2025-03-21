using BooksStore.Web.Models;
using BooksStore.Web.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IInventoryRepository _repository;

        public ProductController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetProducts());
        }

        public IActionResult Details(Guid Id)
        {
            return View(_repository.GetProduct(Id));
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Product product)
        {

            try
            {
                _repository.AddProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(Guid Id) => View(_repository.GetProduct(Id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid Id, [FromBody] Product product)
        {

            try
            {
                _repository.UpdateProduct(Id, product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(Guid Id) => View(_repository.GetProduct(Id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid Id, [FromBody] Product product)
        {

            try
            {
                _repository.DeleteProduct(Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
