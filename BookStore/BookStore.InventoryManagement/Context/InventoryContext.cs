#region Usings
using BookStore.InventoryManagement.Context.Abstract;
using BookStore.InventoryManagement.Models;
using System.Collections.Concurrent;
#endregion

namespace BookStore.InventoryManagement.Context
{
    /// <summary>
    /// Контекст для данных (временно в памяти приложения)
    /// </summary>
    public class InventoryContext : IInventoryContext
    {
        #region Private Properties

        /// <summary>
        /// Словарь для хранения книг
        /// </summary>
        private readonly ConcurrentDictionary<string, Book> _books;

        /// <summary>
        /// Объект для синхронизации потоков
        /// </summary>
        private static readonly object _lock = new();

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
            return _books.TryAdd(name, new Book(name));
        }

        /// <summary>
        /// Обновление количества книг
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool UpdateQuantity(string name, int quantity)
        {
            if (!_books.TryGetValue(name, out Book? value))

                return false;

            lock (_lock)
            {
                value.Quantity += quantity;
            }

            return true;
        }

        #endregion

    }
}
