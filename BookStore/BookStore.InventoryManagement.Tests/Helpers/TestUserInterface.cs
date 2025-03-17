
using BookStore.InventoryManagement.UserInterface.Abstract;

namespace BookStore.InventoryManagement.Tests.Helpers
{
    /// <summary>
    /// Класс помошник для тестирование интерфейса пользователя
    /// </summary>
    class TestUserInterface : IUserInterface
    {
        private readonly List<Tuple<string, string>> _expectedReadRequests;
        private readonly List<string> _expectedWriteMessageRequests;
        private readonly List<string> _expectedWriteWarningRequests;

        private int _expectedReadRequestsIndex;
        private int _expectedWriteMessageRequestsIndex;
        private int _expectedWriteWarningRequestsIndex;

        public TestUserInterface(List<Tuple<string, string>> expectedReadRequests, List<string> expectedWriteRequests, List<string> expectedWarningRequests)
        {
            _expectedReadRequests = expectedReadRequests;
            _expectedWriteMessageRequests = expectedWriteRequests;
            _expectedWriteWarningRequests = expectedWarningRequests;
        }

        public string ReadValue(string message)
        {
            Assert.IsTrue(_expectedReadRequestsIndex < _expectedReadRequests.Count,
                "Получено слишком много команд на чтение.");

            Assert.AreEqual(_expectedReadRequests[_expectedReadRequestsIndex].Item1, message, "Получена неожиданная команда на чтение");

            return _expectedReadRequests[_expectedReadRequestsIndex++].Item2;
        }

        public void WriteMessage(string message)
        {
            Assert.IsTrue(_expectedWriteMessageRequestsIndex < _expectedWriteMessageRequests.Count,
                "Получено слишком много команд на вывод.");

            Assert.AreEqual(_expectedWriteMessageRequests[_expectedWriteMessageRequestsIndex++], message, "Получена неожиданная команда на вывод");
        }

        public void WriteWarning(string message)
        {
            Assert.IsTrue(_expectedWriteWarningRequestsIndex < _expectedWriteWarningRequests.Count,
                "Получено слишком много команд на вывод предупреждения.");

            Assert.AreEqual(_expectedWriteWarningRequests[_expectedWriteWarningRequestsIndex++], message, "Получена неожиданная команда на вывод предупреждения");
        }

        public void Validate()
        {
            Assert.IsTrue(_expectedReadRequestsIndex == _expectedReadRequests.Count, "Не все запросы на ввод выполнены.");
            Assert.IsTrue(_expectedWriteMessageRequestsIndex == _expectedWriteMessageRequests.Count, "Не все запросы на вывод выполнены.");
            Assert.IsTrue(_expectedWriteWarningRequestsIndex == _expectedWriteWarningRequests.Count, "Не все запросы на вывод предупреждения выполнены.");
        }
    }
}
