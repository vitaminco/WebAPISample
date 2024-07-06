using AutoMapper;

namespace WebAPISample.Configurations
{
    public class NullValueIgnoringConverter<TSource, TDestination> : ITypeConverter<TSource, TDestination>
    {
        public TDestination Convert(TSource source, TDestination destination, ResolutionContext context)
        {
            if (source == null)
            {
                return destination;
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>()
                   .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            });

            var mapper = config.CreateMapper();
            return mapper.Map(source, destination);
        }
    }
}
