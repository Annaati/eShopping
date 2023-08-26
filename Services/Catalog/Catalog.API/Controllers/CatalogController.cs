using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }



        #region Products Section

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
        {
            var query = new GetAllProductsquery();
            var products = await _mediator.Send(query);

            return Ok(products);
        }


        [HttpGet]
        [Route("[action]/{productName}", Name = "GetProductsByName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductsByName(string productName)
        {
            var query = new GetProductByNameQuery(productName);
            var products = await _mediator.Send(query);

            return Ok(products);
        }


        [HttpGet]
        [Route("[action]/{typeName}", Name = "GetProductsByType")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductsByType(string typeName)
        {
            var query = new GetProductByTypeQuery(typeName);
            var products = await _mediator.Send(query);

            return Ok(products);
        }


        [HttpGet]
        [Route("[action]/{brandName}", Name = "GetProductsByBrand")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductsByBrand(string brandName)
        {
            var query = new GetProductByBrandQuery(brandName);
            var products = await _mediator.Send(query);

            return Ok(products);
        }


        [HttpGet]
        [Route("[action]/{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);

            return Ok(product);
        }


        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand productCommand )
        {
            var result = await _mediator.Send(productCommand);

            return Ok(result);
        }


        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand productCommand)
        {
            var result = await _mediator.Send(productCommand);

            return Ok(result);
        }


        [HttpDelete]
        [Route("DeleteProduct/{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var query = new DeleteProductByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        #endregion




        #region Type Section

        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypeResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<TypeResponse>>> GetAllTypes()
        {
            var query = new GetAllTypesQuery();
            var types = await _mediator.Send(query);

            return Ok(types);
        }


        #endregion

        #region Brand Section

        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
        {
            var query = new GetAllBrandsQuery();
            var brands = await _mediator.Send(query);

            return Ok(brands);
        }


        #endregion


    }
}
