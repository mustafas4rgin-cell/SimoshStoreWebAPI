using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface IRoleService
{
    Task<IEnumerable<RoleEntity>> GetRolesAsync();
    Task<IServiceResult> CreateRoleAsync(RoleDTO role);
    Task<IServiceResult> DeleteRoleAsync(int id);
    Task<IServiceResult> UpdateRoleAsync(RoleDTO role, int id);
    public Task<RoleEntity> GetRoleByIdAsync(int id);
}
