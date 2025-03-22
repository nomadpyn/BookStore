#region Usings
using BooksStore.Web.Models;
using BooksStore.Web.ViewModels;
#endregion

namespace BooksStore.Web.Extensions
{
    /// <summary>
    /// Расширения для ProductViewModel
    /// </summary>
    public static class ProductViewModelExtension
    {

        #region Public Methods

        /// <summary>
        /// Возвращает новый экземпляр Product
        /// </summary>
        /// <param name="productvm"></param>
        /// <returns></returns>
        public static Product ToProductModel(this ProductViewModel productvm)
        {
            return new Product
            {
                CategoryId = productvm.CategoryId,
                Description = productvm.ProductDescription,
                Id = productvm.ProductId,
                Name = productvm.ProductName,
                Price = productvm.ProductPrice
            };
        }

        /// <summary>
        /// Возвращает список Product
        /// </summary>
        /// <param name="productvm"></param>
        /// <returns></returns>
        public static IEnumerable<Product> ToProductModel(this IEnumerable<ProductViewModel> productvm)
        {
            return productvm.Select(ToProductModel).ToList();
        }

#endregion
    }
}
