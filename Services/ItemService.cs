using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class ItemService : IItemService
    {
        private medikeepContext _context;
        private ItemValidator _validator;
        private IMapper _mapper;

        public ItemService(medikeepContext context,
            ItemValidator val, IMapper mapper)
        {
            _context = context;
            _validator = val;
            _mapper = mapper;
        }


        public ICollection<ItemDTO> CreateItem(ItemDTO newItem)
        {
            _validator.ValidateAndThrow(newItem);

            var mappedItem = _mapper.Map<Item>(newItem);
            if (mappedItem != null)
            {
                _context.Item.Add(mappedItem);
                _context.SaveChanges();
                return GetAllItems();
            }

            throw new NullReferenceException();
        }

        public bool UpdateItem(ItemDTO itemToUpdate)
        {
            _validator.ValidateAndThrow(itemToUpdate);
            var item = _context.Item.FirstOrDefault(f => f.Id == itemToUpdate.Id);
            if (item != null)
            {

                var update = _mapper.Map(itemToUpdate, item);
                _context.Update(item);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public ItemDTO GetItemById(int id)
        {
            var item = _context.Item.FirstOrDefault(w => w.Id == id);
            return _mapper.Map<ItemDTO>(item);
        }

        public ICollection<ItemDTO> GetAllItemByName(string name)
        {
            var itemList = _context.Item.Where(w => w.ItemName == name).ToList();
            return _mapper.Map<ICollection<ItemDTO>>(itemList); 
        }
        
        public ICollection<ItemDTO> GetAllItems()
        {
            var itemList = _context.Item.ToList();
            return _mapper.Map<ICollection<ItemDTO>>(itemList);
        }

        public decimal? GetMaxCostForItemName(string itemName)
        {

            var allCostForItem = _context.Item
                .Where(w => w.ItemName == itemName).Select(s => s.Cost).ToList();
            return allCostForItem.Max();
        }
        public List<ItemMaxCost> GetMaxCostForItems()
        {

            var maxCostForItem = _context.Item.ToList().GroupBy(g => g.ItemName)
                .Select(s => new ItemMaxCost()
                {
                    ItemName = s.Key,
                    MaxCost = s.Max(x=>x.Cost)
            
                }).ToList();

            return maxCostForItem;
        }

        public bool DeleteItem(int itemId)
        {
            var item = _context.Item.Find(itemId);
            if (item != null)
            {
                _context.Item.Remove(item);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        //TODO DELETE and Test
    }
}