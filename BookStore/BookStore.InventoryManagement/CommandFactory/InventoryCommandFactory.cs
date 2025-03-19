#region Usings
using BookStore.InventoryManagement.CommandFactory.Abstract;
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Commands.Abstract;
using BookStore.InventoryManagement.Context;
using BookStore.InventoryManagement.Context.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.CommandFactory
{
    /// <summary>
    /// Класс фабрика для получения команд
    /// </summary>
    public class InventoryCommandFactory : IInventoryCommandFactory
    {
        #region Private Properties

        /// <summary>
        /// Интерфейс пользователя
        /// </summary>
        private readonly IUserInterface _userInterface;

        /// <summary>
        /// Контекст данных
        /// </summary>
        private readonly IInventoryContext _context;

        #endregion

        #region Constructors

        public InventoryCommandFactory(IUserInterface userInterface, IInventoryContext context)
        {
            _userInterface = userInterface;

            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Выполняет команду в соответствии со строкой ввода
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public InventoryCommand GetCommand(string input)
        {
            return input.ToLower() switch
            {
                "q" or "quit" => new QuitCommand(_userInterface),
                "a" or "addinventory" => new AddInventoryCommand(_userInterface, _context),
                "g" or "getinventory" => new GetInventoryCommand(_userInterface, _context),
                "u" or "updateinventory" => new UpdateInventoryCommand(_userInterface, _context),
                "?" or "help" => new HelpCommand(_userInterface),
                _ => new UnknownCommand(_userInterface)
            };
        }

        #endregion
    }
}
