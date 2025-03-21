using BooksStore.Web.Models;

namespace BooksStore.Web.Repository.Abstract
{
    /// <summary>
    /// Интерфейс для работы с репозиторием
    /// </summary>
    public interface IInventoryRepository
    {
        public Product GetProduct(Guid Id);

        public IEnumerable<Product> GetProducts();

        public void AddProduct(Product product);

        public void UpdateProduct(Guid Id, Product product);

        public void DeleteProduct(Guid Id);

        public Category GetCategory(Guid Id);

        public IEnumerable<Category> GetCategories();

        public void AddCategory(Category product);

        public void UpdateCategory(Guid Id, Category product);

        public void DeleteCategory(Guid Id);

    }
}
