using AutoMapper;
using Discount.Application.Commands;
using Discount.Application.Mappers;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers
{
    public class UpdateDiscountHandler : IRequestHandler<UpdateDiscountCommand, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository;

        public UpdateDiscountHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = _discountRepository.UpdateDiscount(new Coupon
            {
                Id = request.Id,
                ProductName = request.ProductName,
                Description = request.Description,
                Amount = request.Amount
            });

            var couponModel = DiscountMapper.Mapper.Map<CouponModel>(coupon);

            return couponModel;
        }
    }
}
