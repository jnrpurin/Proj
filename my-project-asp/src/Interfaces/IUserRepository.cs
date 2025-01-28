using my_dotnet_core_project.Models;

namespace my_dotnet_core_project.Interfaces
{                
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
    }
}