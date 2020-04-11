namespace YouStation.Platform.Domain.Entities
{
    using System;

    public interface IVideo
    {
        Guid Id { get; }
        IFile Media { get; }
        Resolution Resolution { get; }
    }
}
