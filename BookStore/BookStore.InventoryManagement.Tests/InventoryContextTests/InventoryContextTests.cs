#region Usings
using BookStore.InventoryManagement.Context;
#endregion

namespace BookStore.InventoryManagement.Tests.InventoryContextTests
{
    [TestClass]
    public class InventoryContextTests
    {
        [TestMethod]
        public void MaintainBooks_Successful()
        {
            var context = new InventoryContext();

            foreach (var id in Enumerable.Range(1, 30))
            {
                context.AddBook($"Book_{id}");
            }

            foreach (var quantity in Enumerable.Range(1, 10))
            {
                foreach (var id in Enumerable.Range(1, 30))
                {
                    context.UpdateQuantity($"Book_{id}", quantity);
                }
            }

            var Books = context.GetBooks();
            Assert.IsTrue(Books.Count == 30);

            foreach(var book in Books)
            {
                Assert.AreEqual(55, book.Quantity);
            }
        }
    }
}
