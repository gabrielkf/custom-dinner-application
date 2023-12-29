using CustomDinner.Application.Common.Persistence;
using CustomDinner.Domain.MenuAggregate;

namespace CustomDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly CustomDinnerDbContext _dbContext;

    public MenuRepository(CustomDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}