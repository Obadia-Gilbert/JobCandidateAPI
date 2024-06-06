using System;
using JobCandidateHubAPI.Data;
using JobCandidateHubAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Repositories
{
    public class CandidateRepositories : ICanditateRepositories
    {
        private readonly JobCandidateDbContext context;

        public CandidateRepositories(JobCandidateDbContext context)
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

