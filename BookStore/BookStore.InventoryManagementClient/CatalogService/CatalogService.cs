#region Usings
using BookStore.InventoryManagement.CommandFactory.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
using BookStore.InventoryManagementClient.CatalogService.Abstract;
#endregion

namespace BookStore.InventoryManagementClient.CatalogService
{
    /// <summary>
    /// Консольный сервис каталог
    /// </summary>
    internal class CatalogService : ICatalogService
    {
        #region Private Properties

        /// <summary>
        /// Пользовательский (консольный) интерфейс
        /// </summary>
        private readonly IUserInterface _userInterface;

        /// <summary>
        /// Фабрика для создания команд
        /// </summary>
        private readonly IInventoryCommandFactory _commandFactory;

        #endregion

        #region Constuctors

        internal CatalogService(IUserInterface userInterface, IInventoryCommandFactory factory)
        {
            _userInterface = userInterface;
            _commandFactory = factory;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Запуск сервиса
        /// </summary>
        public void Run()
        {           

            var response = _commandFactory.GetCommand("?").RunCommand();

            while (!response.shouldQuit)
            {
                var input = _userInterface.ReadValue("> ").ToLower();

                var command = _commandFactory.GetCommand(input);

                response = command.RunCommand();

                if (!response.wasSuccess)
                {
                    _userInterface.WriteMessage("Enter ? to view options.");
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Приветствие пользователя
        /// </summary>
        public void Greeting()
        {
            Console.WriteLine("Добро пожаловать в BookStore!");
        }

        #endregion
    }
}
