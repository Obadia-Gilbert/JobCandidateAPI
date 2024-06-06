using System;
using JobCandidateHubAPI.Model;

namespace JobCandidateHubAPI.Repositories
{
	public interface ICanditateRepositories
	{
        
            Task<Candidate> GetByEmailAsync(string email);
            Task AddAsync(Candidate candidate);
            Task UpdateAsync(Candidate candidate);
            Task SaveChangesAsync();
        
    }
}

