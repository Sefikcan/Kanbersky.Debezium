using AutoMapper;
using Payment.Application.DTO.Request;
using Payment.Application.DTO.Response;

namespace Payment.Application.Mappings.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Infrastructure.Entities.Payment, CreatePaymentRequestModel>().ReverseMap();
            CreateMap<Infrastructure.Entities.Payment, PaymentResponseModel>().ReverseMap();
        }
    }
}
