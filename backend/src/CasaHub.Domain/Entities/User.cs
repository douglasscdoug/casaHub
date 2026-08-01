using CasaHub.Domain.Common;

namespace CasaHub.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }
        private User()
        {
        }

        public User(string name, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}