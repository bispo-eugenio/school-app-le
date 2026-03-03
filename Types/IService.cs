using schoolApp.Types.Enums;
namespace schoolApp.Types;

public interface IService
{
    bool Update(int id, EntityProprieties property, string? data = null);
    bool Remove(int id);
}
