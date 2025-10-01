using AutoMapper;
using AutoMapper.Features;
using System.Runtime;
using Ymmy.WebApi.Dtos.FeatureDtos;
using Ymmy.WebApi.Dtos.MessageDtos;
using Ymmy.WebApi.Dtos.ProductDtos;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.Mapping
{
    public class GeneralMapping :Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature,ResultFeatureDtos>().ReverseMap();
            CreateMap<Feature,CreateFeatureDtos>().ReverseMap();
            CreateMap<Feature,GetByIdFeatureDtos>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDtos>().ReverseMap();
            
            
            
            CreateMap<Message,UpdateMessageDtos>().ReverseMap();
            CreateMap<Message,CreateMessageDtos>().ReverseMap();
            CreateMap<Message,GetByIdMessageDtos>().ReverseMap();
            CreateMap<Message,ResultMessageDtos>().ReverseMap();

            
            CreateMap<Product,CreateProductDto>().ReverseMap();
        }
    }
}
