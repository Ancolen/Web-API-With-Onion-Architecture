using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepo<Product>().GetAllAsync();

            List<GetAllProductsQueryResponse> responses = new();

            foreach (var product in products)
                responses.Add(new GetAllProductsQueryResponse()
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price - (product.Price * product.Discount / 100),
                    Discount = product.Discount,
                });

            return responses;
        }
    }
}
