#region Usings
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Tests.Helpers;
#endregion

namespace BookStore.InventoryManagement.Tests.CommandsTests
{
    [TestClass]
    public class HelpCommandTests
    {
        #region Public Test Methods

        [TestMethod]
        public void HelpCommand_Successful()
        {
            string helpMessage = "'g' или 'getinventory' - чтобы получить список книг\n" +
                "'a' или 'addinventory' - чтобы добавить книгу\n" +
                "'u' или 'updateinventory' - чтобы добавить книгам количество\n" +
                "'q' или 'quit' - чтобы выйти из программы";

            var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>
                {
                    helpMessage
                },
                new List<string>());

            var command = new HelpCommand(expectedInterface);

            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "Справка не завершающая команда");
            Assert.IsTrue(result.wasSuccess, "Справка не показана успешно");
        }

        #endregion
    }
}
