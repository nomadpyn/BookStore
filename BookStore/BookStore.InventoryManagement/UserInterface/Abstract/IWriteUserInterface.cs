
namespace BookStore.InventoryManagement.UserInterface.Abstract
{
    /// <summary>
    /// Интерфейс для записи данных
    /// </summary>
    public interface IWriteUserInterface
    {
        /// <summary>
        /// Вывод сообщения пользователю
        /// </summary>
        /// <param name="message"></param>
        public void WriteMessage(string message);

        /// <summary>
        /// Вывод предупреждения пользователю
        /// </summary>
        /// <param name="message"></param>
        public void WriteWarning(string message);
    }
}
