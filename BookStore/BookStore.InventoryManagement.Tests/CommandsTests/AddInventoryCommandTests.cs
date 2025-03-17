#region Usings
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Models;
using BookStore.InventoryManagement.Tests.Helpers;
#endregion

namespace BookStore.InventoryManagement.Tests.CommandsTests
{
    [TestClass]
    public class AddInventoryCommandTests
    {
        #region Public Test Methods

        [TestMethod]
        public void AddInventoryCommand_Successful()
        {
            const string expectedBookName = "AddInventoryUnitTest";

            var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>()
                {
                    new("Ввод name:", expectedBookName)
                },
                new List<string>(),
                new List<string>());

            var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                {"Война и мир", new(){Id =1, Name = "Война и мир", Quantity = 3} }
            });

            var command = new AddInventoryCommand(expectedInterface, context);

            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "Добавит книгу не терминальная команда");
            Assert.IsTrue(result.wasSuccess, "Добавить книгу не выполнена успешно");

            Assert.AreEqual(1, context.GetAddedBooks().Length, "Должна быть добавлена одна книга");

            var newBook = context.GetAddedBooks().First();

            Assert.AreEqual(expectedBookName, newBook.Name, "Книга не была успешно добавлена");
        }

        #endregion
    }
}
