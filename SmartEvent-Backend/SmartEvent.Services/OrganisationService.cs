using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;

namespace SmartEvent.Services
{
    public class OrganisationService
    {
        private readonly IOrganisationRepository _organisationReposiroty;

        public OrganisationService(IOrganisationRepository organisationRepository)
        {
            _organisationReposiroty = organisationRepository;
        }

        public async Task<Organisation> CreateOrganisationAsync(Organisation newOrganisation)
        {
            return await _organisationReposiroty.CreateOrganisationAsync(newOrganisation);
        }

        public async Task<bool> DeleteOrganisation(Guid id)
        {
            return await _organisationReposiroty.DeleteOrganisation(id);
        }

        public async Task<List<Organisation>> GetAllOrganisationAsync()
        {
            return await _organisationReposiroty.GetAllOrganisationAsync();
        }

        public async Task<Organisation?> GetOrganisationByIdAsync(Guid id)
        {
            return await _organisationReposiroty.GetOrganisationByIdAsync(id);
        }

        public async Task<Organisation?> GetOrganisationByAuthIdAsync(Guid id)
        {
            return await _organisationReposiroty.GetOrganisationByAuthIdAsync(id);
        }

        public async Task<Organisation?> UpdateOrganisationAsync(Guid id, Organisation updatedOrganisation)
        {
            return await _organisationReposiroty.UpdateOrganisationAsync(id, updatedOrganisation);
        }

    }
}