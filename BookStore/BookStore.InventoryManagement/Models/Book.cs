
namespace BookStore.InventoryManagement.Models
{
    /// <summary>
    /// Модель представления книги
    /// </summary>
    public class Book
    {
        #region Public Methods

        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование книги
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Количество книг
        /// </summary>
        public int Quantity { get; set; }

        #endregion
    }
}
