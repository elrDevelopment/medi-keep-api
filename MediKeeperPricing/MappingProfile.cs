using AutoMapper;
using DataAccess;
using Models;

namespace MediKeeperPricing
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();
        }
    }
}