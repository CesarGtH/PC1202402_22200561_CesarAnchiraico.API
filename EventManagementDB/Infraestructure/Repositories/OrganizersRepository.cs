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
    public class OrganizersRepository : IOrganizersRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public OrganizersRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Organizers>> GetOrganizers()
        {
            var organizers = await _dbContext.Organizers.ToListAsync();
            return organizers;
        }

        public async Task<Organizers> GetOrganizersbyid(int id)
        {
            var organizers = await _dbContext
                .Organizers
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return organizers;
        }

        public async Task<int> Insert(Organizers organizers)
        {
            organizers.IsActive = true;
            await _dbContext.Organizers.AddAsync(organizers);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? organizers.Id : -1;
        }

        public async Task<bool> Update(Organizers organizers)
        {
            _dbContext.Organizers.Update(organizers);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var organizers = await GetOrganizersbyid(id);
            if (organizers == null) return false;
            organizers.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }


    }
}
