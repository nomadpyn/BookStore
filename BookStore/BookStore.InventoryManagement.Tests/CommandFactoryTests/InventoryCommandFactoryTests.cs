#region Usings
using BookStore.InventoryManagement.CommandFactory;
using BookStore.InventoryManagement.CommandFactory.Abstract;
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Tests.Helpers;
#endregion

namespace BookStore.InventoryManagement.Tests.CommandFactoryTests
{
    [TestClass]
    public class InventoryCommandFactoryTests
    {
        #region Private Properties

        private IInventoryCommandFactory? Factory;

        #endregion

        #region Public Initialize Methods

        [TestInitialize]
        public void Initialize()
        {
            var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>(),
                new List<string>());

            Factory = new InventoryCommandFactory(expectedInterface);
        }

        #endregion

        #region Public Test Methods

        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory?.GetCommand("a"), typeof(AddInventoryCommand),
                "a должна быть команда на добавление");
            Assert.IsInstanceOfType(Factory?.GetCommand("addinventory"), typeof(AddInventoryCommand),
                "addinventory должна быть команда на добавление");
        }

        [TestMethod]
        public void UpdateInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory?.GetCommand("u"), typeof(UpdateInventoryCommand),
                "u должна быть команда на обновление");
            Assert.IsInstanceOfType(Factory?.GetCommand("updateinventory"), typeof(UpdateInventoryCommand),
                "updateinventory должна быть команда на обновление");
        }

        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory?.GetCommand("g"), typeof(GetInventoryCommand),
                "g должна быть команда на вывод");
            Assert.IsInstanceOfType(Factory?.GetCommand("getinventory"), typeof(GetInventoryCommand),
                "getinventory должна быть команда на вывод");
        }

        [TestMethod]
        public void HelpInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory?.GetCommand("?"), typeof(HelpCommand),
                "? должна быть команда на справку");
            Assert.IsInstanceOfType(Factory?.GetCommand("help"), typeof(HelpCommand),
                "help должна быть команда на справку");
        }

        [TestMethod]
        public void QuitInventoryCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory?.GetCommand("q"), typeof(QuitCommand),
                "q должна быть команда на выход");
            Assert.IsInstanceOfType(Factory?.GetCommand("quit"), typeof(QuitCommand),
                "quit должна быть команда на выход");
        }

        [TestMethod]
        public void UnknownCommand_Successful()
        {
            Assert.IsInstanceOfType(Factory?.GetCommand("h"), typeof(UnknownCommand),
                "должна быть не распознанная команда");
            Assert.IsInstanceOfType(Factory?.GetCommand("add"), typeof(UnknownCommand),
                "должна быть не распознанная команда");
            Assert.IsInstanceOfType(Factory?.GetCommand("update"), typeof(UnknownCommand),
                "должна быть не распознанная команда");
            Assert.IsInstanceOfType(Factory?.GetCommand("qit"), typeof(UnknownCommand),
                "должна быть не распознанная команда");
        }

        #endregion
    }
}
