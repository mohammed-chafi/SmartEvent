using SmartEvent.Core.Models;

namespace SmartEvent.Core.Interfaces
{
    public interface IOrganisationRepository
    {
        public Task<Organisation> CreateOrganisationAsync(Organisation newOrganisation);
        public Task<Organisation?> GetOrganisationByIdAsync(Guid id);
        public Task<Organisation?> GetOrganisationByAuthIdAsync(Guid id);
        public Task<Organisation?> UpdateOrganisationAsync(Guid id, Organisation updatedOrganisation);
        public Task<List<Organisation>> GetAllOrganisationAsync();
        public Task<bool> DeleteOrganisation(Guid id);
    }
}