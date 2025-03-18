#region Usings
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands
{
    /// <summary>
    /// Неизвестная команда
    /// </summary>
    internal class UnknownCommand : NonTerminatingCommand
    {
        #region Constructors

        internal UnknownCommand(IUserInterface userInterface) : base(userInterface) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Вывод предупреждения
        /// </summary>
        /// <returns></returns>
        protected override bool InternalCommand()
        {
            UserInterface.WriteWarning("Команда не распознана");

            return false; ;
        }

        #endregion
    }
}
