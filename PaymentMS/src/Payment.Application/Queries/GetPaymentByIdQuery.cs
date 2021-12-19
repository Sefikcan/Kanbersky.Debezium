using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Application.DTO.Response;
using Payment.Infrastructure.DataContext;

namespace Payment.Application.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentResponseModel>
    {
        public int Id { get; set; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentResponseModel>
    {
        private readonly PaymentDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPaymentByIdQueryHandler(PaymentDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PaymentResponseModel> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _dbContext.Payments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            if (payment == null)
            {
                throw new Exception("Payment not found!");
            }

            return _mapper.Map<Infrastructure.Entities.Payment, PaymentResponseModel>(payment);
        }
    }
}
