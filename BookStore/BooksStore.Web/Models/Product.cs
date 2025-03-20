namespace BooksStore.Web.Models
{
    /// <summary>
    /// Модель продукта
    /// </summary>
    public class Product
    {
        #region Public Properties

        /// <summary>
        /// Id продукта
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование продукта 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание продукта
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Изображение продукта
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Цена продукта
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Id категории продукта
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Представление категории продукта
        /// </summary>
        public virtual Category? Category { get; set; }

        #endregion
    }
}
