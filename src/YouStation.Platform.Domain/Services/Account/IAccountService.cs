namespace YouStation.Platform.Domain.Services.Account
{
    using System.Threading.Tasks;
    using Entities;

    public interface IAccountService
    {
        Task Create(IUser user);
    }
}
