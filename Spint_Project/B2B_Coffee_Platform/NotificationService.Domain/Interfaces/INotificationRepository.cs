using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NotificationService.Domain.Entities;

namespace NotificationService.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task AddAsync(NotificationLog log, CancellationToken cancellationToken);
        Task<IEnumerable<NotificationLog>> GetLogsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}