﻿using Application.IRepositories;
using Application.Specifications;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetSpecificationsTestQueryHandler : IRequestHandler<GetSpecificationsTestQueryRequest, PaginationForSpec<GetSpecificationsTestQueryResponse>>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IMapper _mapper;

     public GetSpecificationsTestQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
     {
          _productReadRepository = productReadRepository;
          _mapper = mapper;
     }

     public async Task<PaginationForSpec<GetSpecificationsTestQueryResponse>> Handle(GetSpecificationsTestQueryRequest request, CancellationToken cancellationToken)
     {
          // parametreleri pattern'a gönder
          var spec = new ProductsWithBrandsAndColorSpecification(request.Params);
          var countSpec = new ProductsWithFiltersForCountSpecification(request.Params);

          // ve PaginationForSpec property'leri üret
          int totalItems = await _productReadRepository.CountAsyncWithSpec(countSpec);
          IReadOnlyList<Product> products = await _productReadRepository.GetListAsyncWithSpec(spec);
          IReadOnlyList<GetSpecificationsTestQueryResponse> data = _mapper.Map<IReadOnlyList<GetSpecificationsTestQueryResponse>>(products);


          // sonucu eşleyerek gönder
          return new PaginationForSpec<GetSpecificationsTestQueryResponse>(
               request.Params.PageIndex, request.Params.PageSize, totalItems, data);
     }
}
