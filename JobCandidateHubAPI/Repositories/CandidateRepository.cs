using System;
using JobCandidateHubAPI.Data;
using JobCandidateHubAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Repositories
{
    public class CandidateRepository : ICanditateRepository
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
        }
    }
}

