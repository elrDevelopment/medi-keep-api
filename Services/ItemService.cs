using System;
using System.Collections.Generic;
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

        public ItemDTO GetItemById(int id)
        {
            var item = _context.Item.FirstOrDefault(w => w.Id == id);
            return _mapper.Map<ItemDTO>(item);
        }

        public ItemDTO GetItemByName(string name)
        {
            var item = _context.Item.FirstOrDefault(w => w.ItemName == name);
            return _mapper.Map<ItemDTO>(item); 
        }
        
        public ICollection<ItemDTO> GetAllItems()
        {
            var itemList = _context.Item.ToList();
            return _mapper.Map<IList<ItemDTO>>(itemList);
        }
        public ICollection<ItemDTO> GetAllItemsOfName(string name)
        {
            var itemList = _context.Item
                .Where(w=>w.ItemName == name).ToList();
            return _mapper.Map<IList<ItemDTO>>(itemList);
        }
    }
}