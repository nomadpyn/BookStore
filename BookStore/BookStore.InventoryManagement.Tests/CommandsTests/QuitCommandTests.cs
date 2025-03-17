#region Usings
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Tests.Helpers;
#endregion

namespace BookStore.InventoryManagement.Tests.CommandsTests
{
    [TestClass]
    public class QuitCommandTests
    {
        #region Public Test Methods

        [TestMethod]
        public void QuitCommand_Successful()
        {
            var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>
                {
                    "Спасибо что пользовались системой управления BookStore!"
                },
                new List<string>());

            var command = new QuitCommand(expectedInterface);

            var result = command.RunCommand();

            Assert.IsTrue(result.shouldQuit, "Выход завершающая команда");
            Assert.IsTrue(result.wasSuccess, "Выход не выполнен успешно");
        }

        #endregion
    }
}
