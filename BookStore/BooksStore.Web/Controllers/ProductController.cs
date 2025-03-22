#region Usings
using BooksStore.Web.Extensions;
using BooksStore.Web.Models;
using BooksStore.Web.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace BooksStore.Web.Controllers
{
    /// <summary>
    /// Котроллер продуктов
    /// </summary>
    public class ProductController : Controller
    {
        #region Private Properties

        private readonly IInventoryRepository _repository;

        #endregion

        #region Constructors

        public ProductController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Получение страницы со всеми продуктами
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var products = _repository.GetProducts().ToProductVM();
            return View(products);
        }

        /// <summary>
        /// Получение страницы с одним продуктом
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Details(Guid Id)
        {
            var product = _repository.GetProduct(Id).ToProductVM();
            return View();
        }

        /// <summary>
        /// Получение View добавления нового продукта
        /// </summary>
        /// <returns></returns>
        public IActionResult Create() => View();

        /// <summary>
        /// Добавление нового продукта
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение View изменения продукта
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Edit(Guid Id) => View(_repository.GetProduct(Id));

        /// <summary>
        /// Изменения продукта
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение View удаления продукта
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Delete(Guid Id) => View(_repository.GetProduct(Id));

        /// <summary>
        /// Удаление продукта
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
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

        #endregion
    }
}
