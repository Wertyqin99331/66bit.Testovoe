using Backend.Database;
using Backend.DTO.Team;
using Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class TeamService(AppDbContext dbContext)
{
    public async Task<List<Team>> GetTeamsAsync()
    {
        var teams = await dbContext.Teams.ToListAsync();
        return teams;
    }

    public async Task<UnitResult<ApplicationError>> CreateTeamAsync(CreateTeamRequest request)
    {
        var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == request.Name);
        if (team is not null)
            return UnitResult.Failure(new ApplicationError("Bad request", "Команда с таким именем уже существует"));

        var newTeam = new Team(request.Name);
        await dbContext.Teams.AddAsync(newTeam);
        await dbContext.SaveChangesAsync();

        return UnitResult.Success<ApplicationError>();
    }
}