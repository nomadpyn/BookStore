
using BookStore.InventoryManagement.Commands.Abstract;

namespace BookStore.InventoryManagement.CommandFactory.Abstract
{
    /// <summary>
    /// Интерфейс для фабрики команд (паттерн Фабрика)
    /// </summary>
    public interface IInventoryCommandFactory
    {
        /// <summary>
        /// Получение команды из строки ввода
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public InventoryCommand GetCommand(string input);
    }
}
