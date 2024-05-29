using api.DTOModels;
using api.Entities;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserDTOByIdAsync(int id);
        Task<UserDTO> GetUserDTOByNameAsync(string name);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string username);
        Task<bool> SaveAllAsync();

    }
}
