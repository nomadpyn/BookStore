#region Usings
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands
{
    internal class HelpCommand : NonTerminatingCommand
    {
        #region Constructors

        internal HelpCommand(IUserInterface userInterface) : base(userInterface) { }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Вывод сообщения с справкой
        /// </summary>
        /// <returns></returns>
        protected override bool InternalCommand()
        {
            string helpMessage = "'g' или 'getinventory' - чтобы получить список книг\n" +
                "'a' или 'addinventory' - чтобы добавить книгу\n" +
                "'u' или 'updateinventory' - чтобы добавить книгам количество\n" +
                "'q' или 'quit' - чтобы выйти из программы";

            UserInterface.WriteMessage(helpMessage);

            return true;
        }

        #endregion
    }
}
