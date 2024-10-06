using EventManagementDB.DOMAIN.Core.Entities;
using EventManagementDB.DOMAIN.Core.Interfaces;
using EventManagementDB.DOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementDB.DOMAIN.Infraestructure.Repositories
{
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public AttendeesRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Attendees>> GetAttendees()
        {
            var attendees = await _dbContext.Attendees.ToListAsync();
            return attendees;
        }

        public async Task<Attendees> GetAttendeessbyid(int id)
        {
            var attendees = await _dbContext
                .Attendees
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return attendees;
        }

        public async Task<int> Insert(Attendees attendees)
        {
            attendees.IsActive = true;
            await _dbContext.Attendees.AddAsync(attendees);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? attendees.Id : -1;
        }

        public async Task<bool> Update(Attendees attendees)
        {
            _dbContext.Attendees.Update(attendees);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var attendees = await GetAttendeessbyid(id);
            if (attendees == null) return false;
            attendees.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
