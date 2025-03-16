#region Usings
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.Context.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands
{
    /// <summary>
    /// Команда добавления данных
    /// </summary>
    internal class AddInventoryCommand : NonTerminatingCommand, IParameteriesCommand
    {
        #region Public Properties

        public string? InventoryName { get; private set; }

        #endregion

        #region Private Properties

        private readonly IInventoryContext _context;

        #endregion

        #region Constructors

        internal AddInventoryCommand(IUserInterface userInterface, IInventoryContext context) : base(userInterface)
        {
            _context = context;
        }

        #endregion

        #region Internal Methods
        internal override bool InternalCommand()
        {
            return _context.AddBook(InventoryName);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Получение параметров
        /// </summary>
        /// <returns></returns>
        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InventoryName))
            {
                InventoryName = GetParameter("name");
            }

            return !string.IsNullOrWhiteSpace(InventoryName);
        }

        #endregion
    }
}
