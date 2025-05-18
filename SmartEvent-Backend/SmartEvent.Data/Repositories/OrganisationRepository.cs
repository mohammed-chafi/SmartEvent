using Microsoft.EntityFrameworkCore;
using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;
using SmartEvent.Data.Db;

namespace SmartEvent.Data.Repositories
{
    public class OrganisationRepository : IOrganisationRepository
    {

        private readonly ApplicationDbContext _context;

        public OrganisationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Organisation> CreateOrganisationAsync(Organisation newOrganisation)
        {
            newOrganisation.Id = Guid.NewGuid();
            await _context.Organisations.AddAsync(newOrganisation);
            await _context.SaveChangesAsync();
            return newOrganisation;
        }

        public async Task<bool> DeleteOrganisation(Guid id)
        {
            var organisationToDelete = await GetOrganisationByIdAsync(id);
            if (organisationToDelete == null) return false;
            _context.Organisations.Remove(organisationToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Organisation>> GetAllOrganisationAsync()
        {
            return await _context.Organisations.ToListAsync();
        }

        public async Task<Organisation?> GetOrganisationByAuthIdAsync(Guid id)
        {
            return await _context.Organisations.FirstOrDefaultAsync(o => o.AuthId == id);
        }

        public async Task<Organisation?> GetOrganisationByIdAsync(Guid id)
        {
            return await _context.Organisations.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Organisation?> UpdateOrganisationAsync(Guid id, Organisation updatedOrganisation)
        {
            var existingOrganisation = await GetOrganisationByIdAsync(id);
            if (existingOrganisation == null) return null;

            existingOrganisation.Nom = updatedOrganisation.Nom;


            await _context.SaveChangesAsync();

            return existingOrganisation;
        }
    }
}