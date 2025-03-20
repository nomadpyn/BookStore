
namespace BookStore.InventoryManagement.Context.Abstract
{
    /// <summary>
    /// Интерфейс для чтения из контекста
    /// </summary>
    public interface IInventoryWriteContext
    {
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
