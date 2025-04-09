using Microsoft.EntityFrameworkCore;
using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;
using SmartEvent.Data.Db;

namespace SmartEvent.Data.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _context;

        public ParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Participant> CreateParticipantAsync(Participant newParticipant)
        {
            newParticipant.Id = new Guid();
            await _context.Participants.AddAsync(newParticipant);
            await _context.SaveChangesAsync();
            return newParticipant;
        }

        public async Task<bool> DeleteParticipant(Guid id)
        {
            var ParticipantToDelete = await GetParticipantByIdAsync(id);
            if (ParticipantToDelete == null) return false;
            _context.Participants.Remove(ParticipantToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Participant>> GetAllParticipantAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<List<Participant>> GetAllParticipantByEventIdAsync(Guid EventId)
        {
            return await _context.Participants.Where(e => e.EventId == EventId).ToListAsync();
        }

        public async Task<List<Participant>> GetAllParticipantByUserIdAsync(Guid UserId)
        {
            return await _context.Participants.Where(e => e.UserId == UserId).ToListAsync();
        }

        public async Task<Participant?> GetParticipantByIdAsync(Guid id)
        {
            return await _context.Participants.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Participant?> UpdateParticipantAsync(Guid id, Participant updatedParticipant)
        {
            var existingParticipant = await GetParticipantByIdAsync(id);
            if (existingParticipant == null) return null;

            existingParticipant.UserId = updatedParticipant.UserId;
            existingParticipant.EventId = updatedParticipant.EventId;

            await _context.SaveChangesAsync();

            return existingParticipant;
        }
    }
}