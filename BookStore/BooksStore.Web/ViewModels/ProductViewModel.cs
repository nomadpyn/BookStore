namespace BooksStore.Web.ViewModels
{
    /// <summary>
    /// ViewModel продукта
    /// </summary>
    public class ProductViewModel
    {
        #region Public Properties

        /// <summary>
        /// Id продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Описание продукта
        /// </summary>
        public string? ProductDescription { get; set; }

        /// <summary>
        /// Изображение продукта
        /// </summary>
        public string? ProductImage { get; set; }

        /// <summary>
        /// Цена продукта
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Id категории продукта
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Наименование категории продукта
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Описание категории продукта
        /// </summary>
        public string? CategoryDescription { get; set; }

        #endregion
    }
}
