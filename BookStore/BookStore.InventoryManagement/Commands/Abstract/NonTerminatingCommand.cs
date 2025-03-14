
using BookStore.InventoryManagement.UserInterface.Abstract;

namespace BookStore.InventoryManagement.Commands.Abstract
{
    /// <summary>
    /// Абстрактный класс для комманд, не завершающих выполнения приложения
    /// </summary>
    internal abstract class NonTerminatingCommand : InventoryCommand
    {
        /// <summary>
        /// В конструкторе сразу передаем параметр, что комманда не терминальная
        /// </summary>
        protected NonTerminatingCommand(IUserInterface userInterface) : base(false, userInterface) { }
    }
}
