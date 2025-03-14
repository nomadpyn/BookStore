
namespace BookStore.InventoryManagement.Commands.Abstract
{
    /// <summary>
    /// Интерфейс для параметизированных комманд, которые принимают какие то значения
    /// </summary>
    public interface IParameteriesCommand
    {
        /// <summary>
        /// Получение параметров для команды
        /// </summary>
        /// <returns></returns>
        public bool GetParameters();
    }
}
