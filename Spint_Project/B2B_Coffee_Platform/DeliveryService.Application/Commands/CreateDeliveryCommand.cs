using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Interfaces;

namespace DeliveryService.Application.Commands
{
    public record CreateDeliveryCommand(Guid OrderId) : IRequest<string>;

    public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, string>
    {
        private readonly IDeliveryRepository _repository;

        public CreateDeliveryCommandHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            // Check if delivery already exists for this order
            var existingDelivery = await _repository.GetByOrderIdAsync(request.OrderId, cancellationToken);
            if (existingDelivery != null)
                throw new Exception("Delivery already scheduled for this order.");

            var delivery = new Delivery(request.OrderId);
            await _repository.AddAsync(delivery, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return delivery.TrackingNumber;
        }
    }
}