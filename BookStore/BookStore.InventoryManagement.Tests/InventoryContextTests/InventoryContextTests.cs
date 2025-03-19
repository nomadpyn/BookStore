#region Usings
using BookStore.InventoryManagement.Context;
using BookStore.InventoryManagement.Context.Abstract;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace BookStore.InventoryManagement.Tests.InventoryContextTests
{
    [TestClass]
    public class InventoryContextTests
    {
        #region Private Properties

        private ServiceProvider? Services { get; set; }

        #endregion

        [TestInitialize]
        public void StartUp()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IInventoryContext, InventoryContext>();

            Services = services.BuildServiceProvider();
        }

        [TestMethod]
        public void MaintainBooks_Successful()
        {
            List<Task> tasks = new();

            foreach (var id in Enumerable.Range(1, 30))
            {
                tasks.Add(AddBook($"Book_{id}"));
            }

            Task.WaitAll(tasks.ToArray());

            tasks.Clear();

            foreach (var quantity in Enumerable.Range(1, 10))
            {
                foreach (var id in Enumerable.Range(1, 30))
                {
                    tasks.Add(UpdateQuantity($"Book_{id}", quantity));
                }
            }

            Task.WaitAll(tasks.ToArray());

            var context = Services?.GetService<IInventoryContext>();

            var Books = context?.GetBooks();

            Assert.IsTrue(Books?.Count == 30);

            foreach (var book in Books)
            {
                Assert.AreEqual(55, book.Quantity);
            }
        }


        /// <summary>
        /// Добавление книги из отдельного потока
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public Task AddBook(string bookName)
        {
            return Task.Run(() =>
            {
                var context = Services?.GetService<IInventoryContext>();

                Assert.IsTrue(context?.AddBook(bookName));
            });
        }

        /// <summary>
        /// Обновление количества книг из отдельного потока
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Task UpdateQuantity(string bookName, int quantity)
        {
            return Task.Run(() =>
            {
                var context = Services?.GetService<IInventoryContext>();

                Assert.IsTrue(context?.UpdateQuantity(bookName,quantity));
            });
        }
    }
}
