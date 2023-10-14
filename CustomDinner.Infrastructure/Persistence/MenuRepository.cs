using CustomDinner.Application.Common.Persistence;
using CustomDinner.Domain.MenuAggregate;

namespace CustomDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private readonly List<Menu> _menus = new();
    
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}