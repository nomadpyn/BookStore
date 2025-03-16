
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

        #region Constructors

        public Book() { }

        public Book(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Вывод в строковом представлении
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name,-30}\tКоличество:{Quantity}";
        }

        #endregion
    }
}
