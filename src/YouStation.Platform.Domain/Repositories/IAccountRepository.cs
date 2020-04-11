namespace YouStation.Platform.Domain.Repositories
{
    using System.Threading.Tasks;
    using Entities;

    public interface IAccountRepository
    {
        Task Add(IAccount account);
    }
}
