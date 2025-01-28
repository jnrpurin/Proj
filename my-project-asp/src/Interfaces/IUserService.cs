using my_dotnet_core_project.Models;

namespace my_dotnet_core_project.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByUsername(string username);
    }
}