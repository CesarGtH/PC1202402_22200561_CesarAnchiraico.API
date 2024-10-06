using EventManagementDB.DOMAIN.Core.Entities;

namespace EventManagementDB.DOMAIN.Core.Interfaces
{
    public interface IOrganizersRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Organizers>> GetOrganizers();
        Task<Organizers> GetOrganizersbyid(int id);
        Task<int> Insert(Organizers organizers);
        Task<bool> Update(Organizers organizers);
    }
}