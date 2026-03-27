using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces; 
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Commands
{
    public record CreateCoffeeCommand(
        string Sku,
        string Name,
        string Description,
        string RoastLevel,
        string Origin,
        int BagWeightGrams,
        int BagsPerCarton,
        decimal CartonPrice,
        int MinimumOrderQuantity
    ) : IRequest<Guid>;

    public class CreateCoffeeCommandHandler : IRequestHandler<CreateCoffeeCommand, Guid>
    {
        private readonly IProductRepository _repository;
        public CreateCoffeeCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCoffeeCommand request, CancellationToken cancellationToken)
        {
            var newCoffee = new CoffeeProduct(
                request.Sku,
                request.Name,
                request.Description,
                request.RoastLevel,
                request.Origin,
                request.BagWeightGrams,
                request.BagsPerCarton,
                request.CartonPrice,
                request.MinimumOrderQuantity
            );

            // Use the repository to save it
            await _repository.AddAsync(newCoffee, cancellationToken);

            return newCoffee.Id;
        }
    }
}