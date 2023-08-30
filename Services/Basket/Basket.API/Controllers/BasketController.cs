using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    public class BasketController : ApiController
    {
        #region DI Section
        private readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        [ProducesResponseType(typeof(ShoppingBasketItemResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingBasketResponse>> GetBasketByUserName(string userName)
        {
            var query = new GetBasketByUserNameQuery(userName);

            var basket = await _mediator.Send(query);
            return Ok(basket);
        }



        [HttpPost("UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingBasketItemResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingBasketResponse>> UpdateBasket([FromBody] UpdatehoppingBasketCommand command)
        {
            var basket = await _mediator.Send(command);

            return Ok(basket);
        }


        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingBasketResponse>> DeleteBasketByUserName(string userName)
        {
            var query = new DeleteBasketByUserNameQuery(userName);

            await _mediator.Send(query);

            return Ok();
        }



    }
}
