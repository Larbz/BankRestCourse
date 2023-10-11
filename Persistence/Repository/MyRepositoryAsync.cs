using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository;

public class MyRepositoryAsync<T> : RepositoryBase<T>,IRepositoryAsync<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}