namespace YouStation.Platform.Domain.Entities
{
    using System;

    public interface IFile
    {
        Guid Id { get; }
        string MimeType { get; }
        byte[] Content { get; }
    }
}
