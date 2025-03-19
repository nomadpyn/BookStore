#region Usings
using BookStore.InventoryManagement.Models;
#endregion

namespace BookStore.InventoryManagement.Context.Abstract
{
    /// <summary>
    /// Интерфейс для контекста данных
    /// </summary>
    public interface IInventoryContext
    {
        /// <summary>
        /// Получение списка всех книг
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks();

        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddBook(string name);

        /// <summary>
        /// Обновление количества книг
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool UpdateQuantity(string name, int quantity);
    }
}
