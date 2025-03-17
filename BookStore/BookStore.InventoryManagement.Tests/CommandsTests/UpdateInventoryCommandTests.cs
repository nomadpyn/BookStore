#region Usings
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Models;
using BookStore.InventoryManagement.Tests.Helpers;
#endregion

namespace BookStore.InventoryManagement.Tests.CommandsTests
{
    [TestClass]
    public class UpdateInventoryCommandTests
    {
        #region Public Test Methods

        [TestMethod]
        public void UpdateInventoryCommand_Successful()
        {
            const string expectedBookName = "UpdateInventoryUnitTest";

            var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>()
                {
                    new("Ввод name:", expectedBookName),
                    new("Ввод quantity:", "6")
                },
                new List<string>(),
                new List<string>());

            var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                {"Война и мир", new(){Id =1, Name = "Война и мир", Quantity = 3} },
                { expectedBookName, new(){Id = 2, Name = expectedBookName, Quantity = 4 } }
            });

            var command = new UpdateInventoryCommand(expectedInterface, context);

            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "Обновить книгу не терминальная команда");
            Assert.IsTrue(result.wasSuccess, "Обновить книгу не выполнена успешно");

            Assert.AreEqual(0, context.GetAddedBooks().Length, "Книг не должно быть добавлено");

            var updateBooks = context.GetUpdatedBooks();

            Assert.AreEqual(1, updateBooks.Length, "Должна быть обновлена одна книга");
            Assert.AreEqual(expectedBookName, updateBooks.First().Name, "Книга неправильно обновлена");
            Assert.AreEqual(10, updateBooks.First().Quantity, "Книга неправильно обновлена");

        }

        #endregion
    }
}
