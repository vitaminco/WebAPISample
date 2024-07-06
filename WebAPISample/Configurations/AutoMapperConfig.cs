using AutoMapper;
using WebAPISample.DTOs.Sample;
using WebAPISample.DTOs.Example;
using WebAPISample.Entities;

namespace WebAPISample.Configurations
{
    
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig() {
            /*Sample*/
            CreateMap<CreateSampleRequest, AppSample>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<UpdateSampleRequest, AppSample>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateSampleRequest, AppSample>());
            //Example
            CreateMap<CreateExampleRequest, AppExample>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<UpdateExampleRequest, AppExample>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateExampleRequest, AppExample>());
        }
    }
}
