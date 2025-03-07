using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SimoshStore;

namespace SimoshStoreAPI;

public class RoleService : IRoleService
{
    private readonly IDataRepository _Repository;
    public RoleService(IDataRepository repository)
    {
        _Repository = repository;
    }
    public async Task<IServiceResult> UpdateRoleAsync(RoleDTO dto, int id)
    {
        var role = await _Repository.GetByIdAsync<RoleEntity>(id);
        if (role is null)
        {
            return new ServiceResult(false, "Role not found");
        }
        role.Name = dto.Name;
        await _Repository.UpdateAsync(role);
        return new ServiceResult(true, "Role updated successfully");
    }
    public async Task<RoleEntity> GetRoleByIdAsync(int id)
    {
        var role = await _Repository.GetByIdAsync<RoleEntity>(id);
        if (role is null)
        {
            throw new Exception("Role not found");
        }
        return role;
    }
    public async Task<IEnumerable<RoleEntity>> GetRolesAsync()
    {
        var roles = await _Repository.GetAll<RoleEntity>().ToListAsync();
        if (roles == null)
        {
            throw new Exception("No roles found");
        }
        return roles;
    }
    public async Task<IServiceResult> DeleteRoleAsync(int id)
    {
        var role = await _Repository.GetByIdAsync<RoleEntity>(id);
        if (role is null)
        {
            return new ServiceResult(false, "Role not found");
        }
        await _Repository.DeleteAsync<RoleEntity>(id);
        return new ServiceResult(true, "Role deleted successfully");
    }
    public async Task<IServiceResult> CreateRoleAsync(RoleDTO dto)
    {
        var role = new RoleEntity
        {
            Name = dto.Name
        };
        await _Repository.AddAsync(role);
        return new ServiceResult(true, "Role created successfully");
    }
}
