namespace YouStation.Platform.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public interface IPost
    {
        Guid Id { get; }
        string Title { get; }
        string Description { get; }
        IEnumerable<IVideo> Library { get; }
        IEnumerable<IComment> Comments { get; }
    }
}
