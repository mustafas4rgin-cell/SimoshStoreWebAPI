namespace SimoshStore;

public interface IDataRepository
{
    Task<T?> GetByIdAsync<T>(int id) where T : EntityBase;
    IQueryable<T> GetAll<T>() where T : EntityBase;
    Task<T> AddAsync<T>(T entity) where T : EntityBase;
    Task<T?> UpdateAsync<T>(T entity) where T : EntityBase;
    Task DeleteAsync<T>(int id) where T : EntityBase;
}
