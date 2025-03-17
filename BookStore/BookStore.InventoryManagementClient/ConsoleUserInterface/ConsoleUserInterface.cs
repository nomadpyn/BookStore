#region Usings
using BookStore.InventoryManagement.UserInterface.Abstract;
#endregion

namespace BookStore.InventoryManagementClient.ConsoleUserInterface
{
    /// <summary>
    /// Класс для работы с пользователем через консоль
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        #region Public Methods

        /// <summary>
        /// Считывание значения с консоли
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string ReadValue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(message);

            return Console.ReadLine() ?? String.Empty;
        }

        /// <summary>
        /// Вывод сообщения пользователю в консоль
        /// </summary>
        /// <param name="message"></param>
        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);
        }

        /// <summary>
        /// Вывод предупреждения пользователю в консоль
        /// </summary>
        /// <param name="message"></param>
        public void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(message);
        }

        #endregion
    }
}
