using System;
using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Entities
{
    public class NotificationLog
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Message { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime SentAt { get; private set; }

        private NotificationLog() { } // EF Core requirement

        public NotificationLog(Guid userId, string message, NotificationType type)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Message = message;
            Type = type;
            SentAt = DateTime.UtcNow;
        }
    }
}