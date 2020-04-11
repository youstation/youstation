namespace YouStation.Platform.Domain.Services.User
{
    using System.Threading.Tasks;
    using Cryptography;
    using Entities;
    using Repositories;

    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoProvider _cryptoProvider;

        public UserService(IUserRepository userRepository, ICryptoProvider cryptoProvider)
        {
            _userRepository = userRepository;
            _cryptoProvider = cryptoProvider;
        }

        public Task<IUser> Create(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CheckUsernameAvailability(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
