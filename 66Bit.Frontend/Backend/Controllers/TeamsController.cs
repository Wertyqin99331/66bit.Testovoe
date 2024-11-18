using Backend.DTO.Team;
using Backend.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController(TeamService teamService) : Controller
{
    [HttpGet]
    [ProducesResponseType<List<Team>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeams()
    {
        var teams = await teamService.GetTeamsAsync();
        return Ok(teams);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequest request)
    {
        var result = await teamService.CreateTeamAsync(request);
        
        if (result.IsFailure)
            return BadRequest(result.Error.ToProblemDetails(404));

        return NoContent();
    }
}