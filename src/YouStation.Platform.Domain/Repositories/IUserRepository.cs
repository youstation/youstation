namespace YouStation.Platform.Domain.Repositories
{
    using System.Threading.Tasks;
    using Entities;

    public interface IUserRepository
    {
        Task Add(IUser user);
    }
}
