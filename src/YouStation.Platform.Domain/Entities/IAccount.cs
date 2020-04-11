namespace YouStation.Platform.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public interface IAccount
    {
        Guid Id { get; }
        string Nickname { get; }
        IEnumerable<IPost> Posts { get; }
    }
}
