using Moq;
using JobCandidateHubAPI.Repositories;
using JobCandidateHubAPI.Services;
using JobCandidateHubAPI.Model;
using Xunit;
using System.Threading.Tasks;


public class CandidateServiceTests
{
    private readonly Mock<ICandidateRepository> _mockRepo;
    private readonly CandidateService _candidateService;

    public CandidateServiceTests()
    {
        _mockRepo = new Mock<ICandidateRepository>();
        _candidateService = new CandidateService(_mockRepo.Object);
    }

    [Fact]
    public async Task AddOrUpdateCandidateAsync_ShouldAddNewCandidate_WhenCandidateDoesNotExist()
    {
        // Arrange
        var candidate = new Candidate { Email = "test@example.com" };
        _mockRepo.Setup(repo => repo.GetByEmailAsync(candidate.Email))
                 .ReturnsAsync((Candidate)null);

        // Act
        await _candidateService.AddOrUpdateCandidateAsync(candidate);

        // Assert
        _mockRepo.Verify(repo => repo.AddAsync(candidate), Times.Once);
        _mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Candidate>()), Times.Never);
    }

    [Fact]
    public async Task AddOrUpdateCandidateAsync_ShouldUpdateExistingCandidate_WhenCandidateExists()
    {
        // Arrange
        var candidate = new Candidate { Email = "test@example.com" };
        var existingCandidate = new Candidate { Email = "test@example.com" };
        _mockRepo.Setup(repo => repo.GetByEmailAsync(candidate.Email))
                 .ReturnsAsync(existingCandidate);

        // Act
        await _candidateService.AddOrUpdateCandidateAsync(candidate);

        // Assert
        _mockRepo.Verify(repo => repo.UpdateAsync(existingCandidate), Times.Once);
        _mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Candidate>()), Times.Never);
    }
}


