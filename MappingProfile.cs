using AutoMapper;
using Biblioteca_API.DTOs;
using Biblioteca_API.DTOs.CreateUpdateObjects;

namespace Biblioteca_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookLoan, CreateUpdateBookLoans>().ReverseMap();
        }
    }
}
