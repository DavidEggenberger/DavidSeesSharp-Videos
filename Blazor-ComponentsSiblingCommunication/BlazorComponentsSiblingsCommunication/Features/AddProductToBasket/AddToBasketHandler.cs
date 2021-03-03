using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BlazorComponentsSiblingsCommunication.Features.AddProductToBasket
{
    public class AddToBasketHandler : IRequestHandler<AddToBasketRequest, AddToBasketResponse>
    {
        public static List<AddToBasketRequest> addToBasketRequests = new List<AddToBasketRequest>();
        public static Action Update;
        public async Task<AddToBasketResponse> Handle(AddToBasketRequest request, CancellationToken cancellationToken)
        {
            if(addToBasketRequests.Sum(s => s.ProductPrice) + request.ProductPrice < 150)
            {
                addToBasketRequests.Add(request);
                Update();
                return new AddToBasketResponse
                {
                    Success = true
                };
            }
            Update();
            return new AddToBasketResponse
            {
                Success = false, 
                Message = "Budget was exeeded"
            };
        }
    }
    public class AddToBasketRequest : IRequest<AddToBasketResponse>
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
    public class AddToBasketResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
