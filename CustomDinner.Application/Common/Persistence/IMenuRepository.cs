using CustomDinner.Domain.MenuAggregate;

namespace CustomDinner.Application.Common.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}