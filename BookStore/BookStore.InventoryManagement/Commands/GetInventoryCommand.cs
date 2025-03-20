#region Usings
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.Context.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands
{
    /// <summary>
    /// Команда вывода списка книг
    /// </summary>
    internal class GetInventoryCommand : NonTerminatingCommand
    {
        #region Private Properties

        /// <summary>
        /// Контекст данных
        /// </summary>
        private readonly IInventoryWriteContext _context;

        #endregion

        #region Constructors

        internal GetInventoryCommand(IUserInterface userInterface, IInventoryContext context) : base(userInterface)
        {
            _context = context;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <returns></returns>
        protected override bool InternalCommand()
        {
            var books = _context.GetBooks();

            foreach(var book in books)
            {
                UserInterface.WriteMessage(book.ToString());
            }

            return true;
        }

        #endregion

    }
}
