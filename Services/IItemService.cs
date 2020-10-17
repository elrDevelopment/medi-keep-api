using System.Collections.Generic;
using DataAccess;
using Models;

namespace Services
{
    public interface IItemService
    {
        ICollection<ItemDTO> CreateItem(ItemDTO newItem);
        ItemDTO GetItemById(int id);
        ItemDTO GetItemByName(string name);
        ICollection<ItemDTO> GetAllItems();
        ICollection<ItemDTO> GetAllItemsOfName(string name);
    }
}