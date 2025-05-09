using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data.Context;

namespace SchoolManagement.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly SchoolContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(SchoolContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    //public async Task<(IEnumerable<T> Data, int TotalCount)> GetPagedAsync(PagedQuery query)
    //{
    //    var totalCount = await _dbSet.CountAsync();
    //    var data = await _dbSet
    //        .Skip((query.Page - 1) * query.PageSize)
    //        .Take(query.PageSize)
    //        .ToListAsync();

    //    return (data, totalCount);
    //}
    public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _dbSet
            .Where(e => ids.Contains(EF.Property<Guid>(e, "Id")))
            .ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}