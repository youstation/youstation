namespace YouStation.Platform.Domain.Services
{
    using System.Threading.Tasks;
    using Entities;

    public interface IUserService
    {
        Task<IUser> Create(IUser user);
        Task<bool> CheckUsernameAvailability(string username);
    }
}
