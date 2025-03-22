#region Usings
using BooksStore.Web.Models;
using BooksStore.Web.ViewModels;
#endregion

namespace BooksStore.Web.Extensions
{
    /// <summary>
    /// Расширения для Product
    /// </summary>
    public static class ProductExtension
    {
        #region Public Methods

        /// <summary>
        /// Возвращает новый экземпляр ProductViewModel
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public static ProductViewModel ToProductVM(this Product productModel)
        {
            return new ProductViewModel
            {
                CategoryId = productModel.CategoryId,
                CategoryDescription = productModel.Category?.Description,
                CategoryName = productModel.Category?.Name,
                ProductDescription = productModel.Description,
                ProductId = productModel.Id,
                ProductImage = productModel.Image,
                ProductName = productModel.Name,
                ProductPrice = productModel.Price
            };
        }

        /// <summary>
        /// Возвращает список ProductViewModel
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public static IEnumerable<ProductViewModel> ToProductVM(this IEnumerable<Product> productModel)
        {
            return productModel.Select(ToProductVM).ToList();
        }

        #endregion
    }
}
