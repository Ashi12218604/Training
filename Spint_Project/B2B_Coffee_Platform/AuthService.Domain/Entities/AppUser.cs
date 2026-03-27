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

        // Who created this user? (Superadmin creates Admins, Admins create Clients)
        public Guid? CreatedByUserId { get; private set; }

        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Required by EF Core – private so nothing can create an empty/invalid user
        private AppUser() { }

        public AppUser(string fullName, string email, string passwordHash,
                       UserRole role, Guid? createdByUserId)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email.ToLowerInvariant();
            PasswordHash = passwordHash;
            Role = role;
            CreatedByUserId = createdByUserId;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        // Behavior: Deactivate a user account
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
