using System.Collections.Generic;
using DataAccess;
using Models;

namespace Services
{
    public interface IItemService
    {
        ICollection<ItemDTO> CreateItem(ItemDTO newItem);
        ItemDTO GetItemById(int id);
        ICollection<ItemDTO> GetAllItemByName(string name);
        ICollection<ItemDTO> GetAllItems();
        decimal? GetMaxCostForItemName(string itemName);
        List<ItemMaxCost> GetMaxCostForItems();
        bool UpdateItem(ItemDTO itemToUpdate);
        bool DeleteItem(int itemId);

    }
}