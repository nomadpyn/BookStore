
using System.Runtime.CompilerServices;

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

        #region Constructors

        internal InventoryCommand(bool commandIsTerminating)
        {
            _isTerminatedCommand = commandIsTerminating;
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

        #region Internal Abstract Methods

        /// <summary>
        /// Абстрактный метод для реализации в наследниках
        /// </summary>
        /// <returns></returns>
        internal abstract bool InternalCommand();

        #endregion
    }
}
