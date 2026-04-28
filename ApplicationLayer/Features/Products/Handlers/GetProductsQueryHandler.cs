using ApplicationLayer.Features.Products.Dtos;
using ApplicationLayer.Features.Products.Queries;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {/** **/
        private readonly IProductReadRepository _repository;

        public GetProductsQueryHandler(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);

        }

    }
}
