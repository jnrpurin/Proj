using my_dotnet_core_project.Interfaces;
using my_dotnet_core_project.Models;

namespace my_dotnet_core_project.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }
    }
}