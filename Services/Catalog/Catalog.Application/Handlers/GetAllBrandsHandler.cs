using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetAllBrandsHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }



        public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandsList = await _brandRepository.GetAllBrands();
            var brandsResponseList = _mapper.Map<IList<BrandResponse>>(brandsList);

            return brandsResponseList;
        }





    }
}
