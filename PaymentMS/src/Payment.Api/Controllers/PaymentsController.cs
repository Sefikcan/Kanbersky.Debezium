using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Commands;
using Payment.Application.DTO.Request;
using Payment.Application.DTO.Response;
using Payment.Application.Queries;
using System.Net;

namespace Payment.Api.Controllers
{
    [Route("api/v1/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///  Get Payment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PaymentResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PaymentResponseModel>> GetPaymentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetPaymentByIdQuery(id));
            return Ok(response);
        }

        /// <summary>
        /// Performs the payment process.
        /// </summary>
        /// <param name="createPaymentRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(PaymentResponseModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PaymentResponseModel>> AddPayment([FromBody] CreatePaymentRequestModel createPaymentRequest)
        {
            // Payment transactions take place with any payment integrator.

            var response = await _mediator.Send(new CreatePaymentCommand(createPaymentRequest));
            return CreatedAtAction(nameof(GetPaymentById), new { id = response.Id }, response);
        }
    }
}
