using Application.Commands;
using Application.Entities;
using Application.ViewModels;
using AutoMapper;

namespace Application.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, CreateProductCommand>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<CreateProductCommand, Product>();
        }
    }
}