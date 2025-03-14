
namespace BookStore.InventoryManagement.UserInterface.Abstract
{
    /// <summary>
    /// Интерфейс для чтения данных
    /// </summary>
    public interface IReadUserInterface
    {
        /// <summary>
        /// Метод считывания значения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string ReadValue(string message);
    }
}
