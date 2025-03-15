#region Usings
using BookStore.InventoryManagement.Context.Abstract;
using BookStore.InventoryManagement.Models;
#endregion

namespace BookStore.InventoryManagement.Context
{
    /// <summary>
    /// Контекст для данных (временно в памяти приложения)
    /// </summary>
    internal class InventoryContext : IInventoryContext
    {
        #region Private Properties

        private readonly Dictionary<string, Book> _books;

        #endregion

        #region Constructors

        public InventoryContext() 
        {
            _books = new();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Получение списка всех книг
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks()
        {
            return [.. _books.Values];
        }

        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddBook(string name)
        {
            _books.Add(name, new Book(name));

            return true;
        }        

        /// <summary>
        /// Обновление количества книг
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool UpdateQuantity(string name, int quantity)
        {
            _books[name].Quantity += quantity;

            return true;
        }

        #endregion

    }
}
