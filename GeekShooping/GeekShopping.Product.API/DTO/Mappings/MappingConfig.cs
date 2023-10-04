using AutoMapper;

namespace GeekShopping.Product.API.DTO.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Model.Product>().ReverseMap();
            });

            return mapConfig;
        }
    }
}
