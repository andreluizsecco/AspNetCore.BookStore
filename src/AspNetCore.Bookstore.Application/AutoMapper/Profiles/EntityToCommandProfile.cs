using AutoMapper;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Commands;

namespace AspNetCore.Bookstore.Application.AutoMapper.Profiles
{
    public class EntityToCommandProfile : Profile
    {
        public EntityToCommandProfile()
        {
            CreateMap<Book, CreateBookCommand>()
                .ReverseMap();

            CreateMap<Book, UpdateBookCommand>()
                .ReverseMap();
        }
    }
}