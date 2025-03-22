#region Usings
using BooksStore.Web.Context;
using BooksStore.Web.Models;
using BooksStore.Web.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
#endregion

namespace BooksStore.Web.Repository
{
    /// <summary>
    /// Репозиторий по работе с инвентарем
    /// </summary>
    public class InventoryRepository : IInventoryRepository
    {
        #region Private Properties

        private readonly InventoryContext _inventoryContext;

        #endregion

        #region Constuctors

        public InventoryRepository(InventoryContext inventoryContext) 
        { 
            _inventoryContext = inventoryContext; 
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Добавление новой категории
        /// </summary>
        /// <param name="category"></param>
        public void AddCategory(Category category)
        {
            _inventoryContext.Categories.Add(category);
            _inventoryContext.SaveChanges();
        }

        /// <summary>
        /// Добавление нового продукта
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            _inventoryContext.Products.Add(product);
            _inventoryContext.SaveChanges();
        }

        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteCategory(Guid Id)
        {
            var category = _inventoryContext.Categories.FirstOrDefault(x => x.Id == Id);
            if (category is not null)
            {
                _inventoryContext.Remove(category);
                _inventoryContext.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление продукта
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteProduct(Guid Id)
        {
            var product = _inventoryContext.Products.FirstOrDefault(x => x.Id == Id);
            if (product is not null)
            {
                _inventoryContext.Remove(product);
                _inventoryContext.SaveChanges();
            }
        }

        /// <summary>
        /// Получение всех категории
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetCategories()
        {
            return _inventoryContext.Categories.ToList();
        }

        /// <summary>
        /// Получение одной категории
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Category GetCategory(Guid Id)
        {
            return _inventoryContext.Categories.FirstOrDefault(x => x.Id == Id);
        }

        /// <summary>
        /// Получение одного продукта
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Product GetProduct(Guid Id)
        {
            return _inventoryContext.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == Id);
        }

        /// <summary>
        /// Получение всех продуктов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return _inventoryContext.Products.Include(c => c.Category).ToList();
        }

        /// <summary>
        /// Обновление категории
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        public void UpdateCategory(Guid Id, Category category)
        {
            _inventoryContext.Update(category);
            _inventoryContext.SaveChanges();
        }

        /// <summary>
        /// Обновление продукта
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="product"></param>
        public void UpdateProduct(Guid Id, Product product)
        {
            _inventoryContext.Update(product);
            _inventoryContext.SaveChanges();

        }

        #endregion
    }
}
