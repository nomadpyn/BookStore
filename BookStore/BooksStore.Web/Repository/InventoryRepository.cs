#region Usings
using BooksStore.Web.Models;
using BooksStore.Web.Repository.Abstract;
#endregion

namespace BooksStore.Web.Repository
{
    /// <summary>
    /// Репозиторий по работе с инвентарем
    /// </summary>
    public class InventoryRepository : IInventoryRepository
    {
        void IInventoryRepository.AddCategory(Category product)
        {
            throw new NotImplementedException();
        }

        void IInventoryRepository.AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        void IInventoryRepository.DeleteCategory(Guid Id)
        {
            throw new NotImplementedException();
        }

        void IInventoryRepository.DeleteProduct(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Category> IInventoryRepository.GetCategories()
        {
            throw new NotImplementedException();
        }

        Category IInventoryRepository.GetCategory(Guid Id)
        {
            throw new NotImplementedException();
        }

        Product IInventoryRepository.GetProduct(Guid Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IInventoryRepository.GetProducts()
        {
            throw new NotImplementedException();
        }

        void IInventoryRepository.UpdateCategory(Guid Id, Category product)
        {
            throw new NotImplementedException();
        }

        void IInventoryRepository.UpdateProduct(Guid Id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
