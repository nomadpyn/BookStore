#region Usings
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Tests.Helpers;
#endregion

namespace BookStore.InventoryManagement.Tests.CommandsTests
{
    [TestClass]
    public class UnknownCommandTests
    {
        #region Public Test Methods

        [TestMethod]
        public void UnknownCommand_Successful()
        {
            var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>(),
                new List<string>
                {
                    "Команда не распознана"
                });

            var command = new UnknownCommand(expectedInterface);

            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "Неизвестно не завершающая команда");
            Assert.IsFalse(result.wasSuccess, "Неизвестная команда не успешна");
        }

        #endregion
    }
}
