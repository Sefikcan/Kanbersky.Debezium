using AutoMapper;
using MediatR;
using Payment.Application.DTO.Request;
using Payment.Application.DTO.Response;
using Payment.Infrastructure.DataContext;

namespace Payment.Application.Commands
{
    public class CreatePaymentCommand : IRequest<PaymentResponseModel>
    {
        public CreatePaymentRequestModel CreatePaymentRequest { get; set; }

        public CreatePaymentCommand(CreatePaymentRequestModel createPaymentRequest)
        {
            CreatePaymentRequest = createPaymentRequest;
        }
    }

    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, PaymentResponseModel>
    {
        private readonly PaymentDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(PaymentDbContext dbContext ,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PaymentResponseModel> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<Infrastructure.Entities.Payment>(request.CreatePaymentRequest);
            var response = await _dbContext.AddAsync(payment, cancellationToken);
            if (await _dbContext.SaveChangesAsync(cancellationToken) <= 0)
            {
                throw new Exception("Create Payment Failed!");
            }

            return _mapper.Map<PaymentResponseModel>(response.Entity);
        }
    }
}
