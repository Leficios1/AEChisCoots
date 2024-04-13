using AutoMapper;
using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;

namespace SWP391_BL3W.Mapping
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<UserResponseDto, User>().ReverseMap();

            CreateMap<CreateProductDTO, Products>()
            .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details));
            CreateMap<ProductDetailDTO, ProductsDetails>();

            CreateMap<UpdateProductsDTO,Products>().ReverseMap();
        }
    }
}
