namespace YouStation.Platform.Domain.Entities
{
    using System;

    public interface IComment
    {
        Guid Id { get; }
        IAccount Author { get; }
        string Text { get; }
    }
}
