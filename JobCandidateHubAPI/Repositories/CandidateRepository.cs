using JobCandidateHubAPI.Data;
using JobCandidateHubAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace JobCandidateHubAPI.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobCandidateDbContext context;

        public CandidateRepository(JobCandidateDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Candidate candidate)
        {
            await context.AddAsync(candidate);
        }

        public async Task<Candidate> GetByEmailAsync(string email)
        {
            return await context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            context.Candidates.Update(candidate);
            await context.SaveChangesAsync();
        }

        /*public async Task<ICollection<Candidate>> GetCandidatesAsync()
        {
            return await context.Candidates.ToListAsync();
        }*/
    }
}

