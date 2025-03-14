
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
        public bool RunCommand(out bool shouldQuit)
        {
            shouldQuit = _isTerminatedCommand;

            return InternalCommand();
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
