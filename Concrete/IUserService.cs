using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface IUserService
{
    Task<UserEntity> GetUserByIdAsync(int id);
    Task<IEnumerable<UserEntity>> GetUsersAsync();
    public Task<bool> ValidateUserAsync(string email, string password);
    public Task<IServiceResult> ValidateUserRoleAsync(UserEntity user);
    Task<IServiceResult> CreateUserAsync(RegisterDto user);
    Task<IServiceResult> DeleteUserAsync(int id);
    Task<IServiceResult> UpdateUserAsync(UserDTO user, int id);  
    Task<UserEntity> GetUserByEmailAsync(string email);  

}
