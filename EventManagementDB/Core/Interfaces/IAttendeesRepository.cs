using EventManagementDB.DOMAIN.Core.Entities;

namespace EventManagementDB.DOMAIN.Core.Interfaces
{
    public interface IAttendeesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetAttendees();
        Task<Attendees> GetAttendeessbyid(int id);
        Task<int> Insert(Attendees attendees);
        Task<bool> Update(Attendees attendees);
    }
}