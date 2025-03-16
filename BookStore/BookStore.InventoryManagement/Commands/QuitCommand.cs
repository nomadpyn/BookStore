#region Usings
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands
{
    /// <summary>
    /// Команда выхода из приложения
    /// </summary>
    internal class QuitCommand : InventoryCommand
    {
        #region Constructors

        internal QuitCommand(IUserInterface userInterface) : base(true, userInterface) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Переопределение тела команды
        /// </summary>
        /// <returns></returns>
        protected override bool InternalCommand()
        {
            UserInterface.WriteMessage("Спасибо что пользовались системой управления BookStore!");

            return true;
        }

        #endregion
    }
}
