using AutoMapper;

namespace PointOfSale.Application.AutoMapper
{
    public class AutoMapperConfig //: Profile
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<CategoryProfile>();
                config.AddProfile<PaymentMethodProfile>();
                config.AddProfile<OrderProfile>();
                config.AddProfile<OrderProductProfile>();
                config.AddProfile<ProductProfile>();
            });
        }
    }
}
