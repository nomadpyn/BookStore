
namespace BookStore.InventoryManagement.UserInterface.Abstract
{
    /// <summary>
    /// Интерфейс для работы с пользователем
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Метод считывания значения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string ReadValue(string message);

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
