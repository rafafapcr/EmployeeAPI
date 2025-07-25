﻿using Worker.Domain.Abstractions;

namespace Worker.Domain.Entities
{
    public class Employee : Entity<Guid>
    {
        public string Name { get; private set; } = string.Empty;
        public int Registration { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public int PositionId { get; private set; }
        public bool Active { get; private set; }

        // EF Core parameterless constructor
        private Employee() { }

        private Employee(
            string name,
            int registration,
            string email,
            string password,
            int positionId,
            bool active)

        {
            Id = Guid.NewGuid();
            Name = name;
            Registration = registration;
            Email = email;
            Password = password;
            PositionId = positionId;
            Active = active;
        }

        public static Employee Create(
            string name,
            int registration,
            string email,
            string password,
            int positionId,
            bool active = true)
        {
            return new Employee(name, registration, email, password, positionId, active);
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void ChangePosition(int newPosition)
        {
            PositionId = newPosition;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void UpdateInfo(string name, int registration, string email, bool active)
        {
            Name = name;
            Registration = registration;
            Email = email;
            Active = active;
        }
    }
}
