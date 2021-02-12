using System.Linq;
using Application.Commands;
using Application.Entities;
using Application.ViewModels;
using AutoMapper;

namespace Application.MappingProfiles
{
    public class ImportationMappingProfile : Profile
    {
        public ImportationMappingProfile()
        {
            CreateMap<Importation, CreateImportationCommand>();
            //CreateMap<Importation, ImportationViewModel>();

            CreateMap<Importation, ImportationViewModel>()
                .ForMember(vm => vm.TotalItems, opt =>
                    opt.MapFrom(src => src.Products.Count))
                .ForMember(vm => vm.TotalValue, opt =>
                    opt.MapFrom(src => src.Products.Sum(pr => pr.Quantity) * src.Products.Sum(pr => pr.Value)));
                

            CreateMap<CreateImportationCommand, Importation>();
        }
    }
}