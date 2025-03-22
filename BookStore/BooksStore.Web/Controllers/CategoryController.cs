#region Usings
using BooksStore.Web.Models;
using BooksStore.Web.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace BooksStore.Web.Controllers
{
    /// <summary>
    /// Контроллер категории
    /// </summary>
    public class CategoryController : Controller
    {
        #region Private Properties

        private readonly IInventoryRepository _repository;

        #endregion

        #region Constructors

        public CategoryController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Получение страницы со всеми категориями
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_repository.GetCategories());
        }

        /// <summary>
        /// Получение страницы с одной категорией
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Details(Guid Id)
        {
            return View(_repository.GetCategory(Id));
        }

        /// <summary>
        /// Получение View добавления категории
        /// </summary>
        /// <returns></returns>
        public IActionResult Create() => View();

        /// <summary>
        /// Добавление новой категории
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение View изменения категории
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Edit(Guid Id) => View(_repository.GetCategory(Id));

        /// <summary>
        /// Изменение категории
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение View удаления категории
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Delete(Guid Id) => View(_repository.GetCategory(Id));

        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
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

        #endregion
    }
}
