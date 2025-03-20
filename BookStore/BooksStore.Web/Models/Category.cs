namespace BooksStore.Web.Models
{
    /// <summary>
    /// Модель категории продукта
    /// </summary>
    public class Category
    {
        #region Public Properties

        /// <summary>
        /// Id категории
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование категории
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание категории
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Список продуктов в категории
        /// </summary>
        public virtual IEnumerable<Product>? Products { get; set; }

        #endregion

        #region Constructors

        public Category()
        {
            Products = [];
        }

        #endregion
    }
}
