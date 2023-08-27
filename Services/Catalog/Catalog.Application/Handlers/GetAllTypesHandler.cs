using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponse>>
    {
        private readonly ITypeRepository typeRepository;

        public GetAllTypesHandler(ITypeRepository typeRepository)
        {
            this.typeRepository = typeRepository;
        }



        public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await typeRepository.GetAllTypes();
            var typesResponseList = ProductMapper.Mapper.Map<IList<TypeResponse>>(typesList);

            return typesResponseList;
        }





    }
}