#region Usings
using BookStore.InventoryManagement.Models;
#endregion

namespace BookStore.InventoryManagement.Context.Abstract
{
    /// <summary>
    /// Интерфейс для записи в контекст
    /// </summary>
    public interface IInventoryReadContext
    {
        /// <summary>
        /// Получение списка всех книг
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks();
    }
}
