#region Usings
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.Context.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands
{
    /// <summary>
    /// Команда обновления данных
    /// </summary>
    internal class UpdateInventoryCommand : NonTerminatingCommand, IParameteriesCommand
    {
        #region Private Properties

        /// <summary>
        /// Контекст данных
        /// </summary>
        private readonly IInventoryWriteContext _context;

        #endregion

        #region Internal Properties

        /// <summary>
        /// Имя книги
        /// </summary>
        internal string InventoryName { get; private set; } = String.Empty;

        /// <summary>
        /// Количество книг
        /// </summary>
        internal int Quantity { get; private set; }

        #endregion

        #region Constuctors

        internal UpdateInventoryCommand(IUserInterface userInterface, IInventoryContext context) : base(userInterface)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Получение параметров для комманды
        /// </summary>
        /// <returns></returns>
        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(InventoryName))
            {
                InventoryName = GetParameter("name");
            }

            if(Quantity == 0)
            {
                int.TryParse(GetParameter("quantity"), out int _quantity);

                Quantity = _quantity;
            }

            return !string.IsNullOrWhiteSpace(InventoryName) && Quantity != 0;
        }

        #endregion

        #region protected Methods

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <returns></returns>
        protected override bool InternalCommand()
        {
            return _context.UpdateQuantity(InventoryName, Quantity);
        }

        #endregion
    }
}
