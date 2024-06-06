using System;
using JobCandidateHubAPI.Model;
using JobCandidateHubAPI.Repositories;

namespace JobCandidateHubAPI.Services
{
    public class CandidateService
    {
        private readonly CandidateRepository _candidateRepository;

        public CandidateService(CandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task AddOrUpdateCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await _candidateRepository.GetByEmailAsync(candidate.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.CallTimeInterval = candidate.CallTimeInterval;
                existingCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
                existingCandidate.Comments = candidate.Comments;

                await _candidateRepository.UpdateAsync(existingCandidate);
            }
            else
            {
                await _candidateRepository.AddAsync(candidate);
            }

            await _candidateRepository.SaveChangesAsync();
        }

        public async Task<ICollection<Candidate>> GetCandidatesAsync()
        {
            return await _candidateRepository.GetCandidatesAsync();
        }
    }
}

