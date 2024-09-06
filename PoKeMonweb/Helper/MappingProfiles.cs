using AutoMapper;
using PoKeMonweb.DTO;
using PoKeMonweb.Models;

namespace PoKeMonweb.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PoKemonDTO>();
            CreateMap<Category, CategoryDTO>();
            
        }

    }
}
