using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Application.Commands
{
    public record SendNotificationCommand(Guid UserId, string Message, NotificationType Type) : IRequest<bool>;

    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand, bool>
    {
        private readonly INotificationRepository _repository;

        public SendNotificationCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            // In a real-world app, you would integrate SendGrid (for emails) or Twilio (for SMS) right here!
            // For now, we simulate a successful send by logging it to our database.

            var log = new NotificationLog(request.UserId, request.Message, request.Type);

            await _repository.AddAsync(log, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}