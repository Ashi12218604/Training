using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DeliveryService.Domain.Interfaces;

namespace DeliveryService.Application.Queries
{
    public record DeliveryResponseDto(Guid OrderId, string TrackingNumber, string Status, DateTime? EstimatedDeliveryDate);

    public record GetDeliveryStatusQuery(string TrackingNumber) : IRequest<DeliveryResponseDto>;

    public class GetDeliveryStatusQueryHandler : IRequestHandler<GetDeliveryStatusQuery, DeliveryResponseDto>
    {
        private readonly IDeliveryRepository _repository;

        public GetDeliveryStatusQueryHandler(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeliveryResponseDto> Handle(GetDeliveryStatusQuery request, CancellationToken cancellationToken)
        {
            var delivery = await _repository.GetByTrackingNumberAsync(request.TrackingNumber, cancellationToken);

            if (delivery == null)
                throw new Exception("Tracking number not found.");

            return new DeliveryResponseDto(delivery.OrderId, delivery.TrackingNumber, delivery.Status.ToString(), delivery.EstimatedDeliveryDate);
        }
    }
}