
namespace BookStore.InventoryManagement.Context.Abstract
{
    /// <summary>
    /// Интерфейс для контекста данных
    /// </summary>
    public interface IInventoryContext : IInventoryWriteContext, IInventoryReadContext { }
}
