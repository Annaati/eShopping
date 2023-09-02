using AutoMapper;

namespace Discount.Application.Mappers
{
    public class DiscountMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                cfg.AddProfile<DiscountMappingProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}