namespace YouStation.Platform.Domain.Entities
{
    using System;

    public interface IUser
    {
        Guid Id { get; }
        string Name { get; }
        string Email { get; }
        string Password { get; }
        string Salt { get; }
        IAccount Account { get; }
    }
}