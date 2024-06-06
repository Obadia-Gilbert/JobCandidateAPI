using System;
using JobCandidateHubAPI.Model;

namespace JobCandidateHubAPI.Repositories
{
	public interface ICanditateRepository
	{
        
            Task<Candidate> GetByEmailAsync(string email);

            Task AddAsync(Candidate candidate);

            Task UpdateAsync(Candidate candidate);

            Task SaveChangesAsync();
        
    }
}

