using Backend.DTO.Footballer;
using Backend.Hubs;
using Backend.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FootballersController(FootballerService footballerService, ILogger<FootballersController> logger)
    : Controller
{
    [HttpGet]
    [ProducesResponseType<List<Footballer>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFootballers()
    {
        return Ok(await footballerService.GetFootballersAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateFootballer([FromBody] CreateFootballerRequest request)
    {
        var result = await footballerService.AddFootballerAsync(request);

        if (result.IsFailure)
            return BadRequest(result.Error.ToProblemDetails(404));

        return NoContent();
    }

    [HttpPut("{footballerId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditFootballer(Guid footballerId, [FromBody] EditFootballerRequest request)
    {
        logger.LogWarning(request.TeamId.ToString());
        var result = await footballerService.EditFootballerAsync(footballerId, request);

        if (result.IsFailure)
            return BadRequest(result.Error.ToProblemDetails(404));

        return NoContent();
    }
}