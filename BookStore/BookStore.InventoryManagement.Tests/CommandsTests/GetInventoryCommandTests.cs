#region Usings
using BookStore.InventoryManagement.Commands;
using BookStore.InventoryManagement.Models;
using BookStore.InventoryManagement.Tests.Helpers;
#endregion

namespace BookStore.InventoryManagement.Tests.CommandsTests
{
    [TestClass]
    public class GetInventoryCommandTests
    {
        #region Public Test Methods

        [TestMethod]
        public void GetInventoryCommand_Successful()
        {
            var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>
                {
                    "Война и мир \tКоличество:10",
                    "Любовь живет три года \tКоличество:2"
                },
                new List<string>());

            var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                {"Война и мир", new() {Id = 1, Name = "Война и мир", Quantity = 10} },
                {"юбовь живет три года", new() {Id = 2, Name = "Любовь живет три года", Quantity = 2} }
            });

            var command = new GetInventoryCommand(expectedInterface, context);

            var result = command.RunCommand();

            Assert.IsFalse(result.shouldQuit, "Вывод книг не завершающая команда");
            Assert.IsTrue(result.wasSuccess, "Вывод книг не показан успешно");

            Assert.AreEqual(0, context.GetAddedBooks().Length, "Книг не должно быть добавлено");
            Assert.AreEqual(0, context.GetUpdatedBooks().Length, "Книг не должно быть обновлено");
        }

        #endregion
    }
}
