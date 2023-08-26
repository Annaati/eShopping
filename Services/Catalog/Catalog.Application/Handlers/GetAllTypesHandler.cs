using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
        private readonly ITypeRepository typeRepository;

        public GetAllTypesHandler(ITypeRepository typeRepository)
        {
            this.typeRepository = typeRepository;
        }



        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await typeRepository.GetAllTypes();
            var typesResponseList = ProductMapper.mapper.Map<IList<TypesResponse>>(typesList);

            return typesResponseList;
        }





    }
}