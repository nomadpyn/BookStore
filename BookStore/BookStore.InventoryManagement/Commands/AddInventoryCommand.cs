#region Usings
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands
{
    /// <summary>
    /// Команда добавления данных
    /// </summary>
    internal class AddInventoryCommand : NonTerminatingCommand, IParameteriesCommand
    {
        #region Internal Properties

        internal string? InventoryName { get; private set; }

        #endregion

        #region Constructors

        internal AddInventoryCommand(IUserInterface userInterface) : base(userInterface) { }

        #endregion

        #region Internal Methods
        internal override bool InternalCommand()
        {
            throw new NotImplementedException();
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
