using JobCandidateHubAPI.Model;
using JobCandidateHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHubAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly CandidateService candidateService;
   

    public CandidatesController(CandidateService candidateService)
    {
             this.candidateService = candidateService;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdateCandidate([FromBody] Candidate candidate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await candidateService.AddOrUpdateCandidateAsync(candidate);
        return Ok();
    }

    /*[HttpGet("GetAllCandidates")]

    public async Task<ActionResult<ICollection<Candidate>>> GetAllCandidates()
    {
        var candidates = await candidateService.GetCandidatesAsync();
        return Ok(candidates);
    }*/
}

