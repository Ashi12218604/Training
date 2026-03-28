using System;
using AuthService.Domain.Enums;

namespace AuthService.Domain.Entities
{
    public class AppUser
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }

        // Who created this user? (Superadmin creates Admins. If Client self-registers, this is null)
        public Guid? CreatedByUserId { get; private set; }

        public bool IsActive { get; private set; }

        // --- NEW PROPERTY FOR REGISTRATION FLOW ---
        public bool IsApproved { get; private set; }

        public DateTime CreatedAt { get; private set; }

        // Required by EF Core
        private AppUser() { }

        public AppUser(string fullName, string email, string passwordHash,
                       UserRole role, Guid? createdByUserId, bool isApproved = false) // <-- Added isApproved default
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email.ToLowerInvariant();
            PasswordHash = passwordHash;
            Role = role;
            CreatedByUserId = createdByUserId;
            IsActive = true;
            IsApproved = isApproved; // <-- Set the flag
            CreatedAt = DateTime.UtcNow;
        }

        // Behavior: Deactivate a user account
        public void Deactivate()
        {
            IsActive = false;
        }

        // --- NEW BEHAVIOR: Approve a pending client ---
        public void Approve()
        {
            IsApproved = true;
        }
    }
}