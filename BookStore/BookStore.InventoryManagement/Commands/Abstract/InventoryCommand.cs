#region Usings
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagement.Commands.Abstract
{
    /// <summary>
    /// Абстрактный класс для выполнения команд
    /// </summary>
    public abstract class InventoryCommand
    {
        #region Private Properties

        /// <summary>
        /// Переменная, показывает являются ли команда завершающей для работы приложения
        /// </summary>
        private readonly bool _isTerminatedCommand;

        #endregion

        #region Protected Properties

        /// <summary>
        /// Пользовательский интерфейс для команды
        /// </summary>
        protected IUserInterface UserInterface { get; }

        #endregion

        #region Constructors

        internal InventoryCommand(bool commandIsTerminating, IUserInterface userInterface)
        {
            _isTerminatedCommand = commandIsTerminating;

            UserInterface = userInterface;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Запуск команды
        /// </summary>
        /// <param name="shouldQuit"></param>
        /// <returns></returns>
        public (bool wasSuccess, bool shouldQuit) RunCommand()
        {
            // если команда с параметрами то необходимо получить параметры
            if (this is IParameteriesCommand parameteriesCommand)
            {
                var allParameters = false;

                while (allParameters == false)
                {
                    // получение параметров
                    allParameters = parameteriesCommand.GetParameters();
                }
            }

            return (InternalCommand(), _isTerminatedCommand);
        }

        #endregion

        #region Protected Abstract Methods

        /// <summary>
        /// Абстрактный метод для реализации в наследниках
        /// </summary>
        /// <returns></returns>
        protected abstract bool InternalCommand();

        #endregion

        #region Internal Methods

        /// <summary>
        /// Получение значения параметра от пользовательского интерфейса
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        internal string GetParameter(string paramName)
        {
            return UserInterface.ReadValue($"Ввод {paramName}:");
        }

        #endregion
    }
}
