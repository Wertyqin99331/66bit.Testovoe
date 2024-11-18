using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Database;
using Backend.DTO.Footballer;
using Backend.Hubs;
using Core.Hub;
using Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class FootballerService(AppDbContext dbContext, IHubContext<FootballersHub> footballersHub)
{
    public async Task<List<Footballer>> GetFootballersAsync()
    {
        return await dbContext.Footballers.Include(f => f.Team)
            .ToListAsync();
    }

    public async Task<UnitResult<ApplicationError>> AddFootballerAsync(CreateFootballerRequest request)
    {
        var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == request.TeamId);
        if (team is null)
            return new ApplicationError("Bad request", "Team not found");

        var footballer = new Footballer(request.Name, request.Surname, request.Gender, request.BirthDate,
            request.Country, team);
        await dbContext.Footballers.AddAsync(footballer);
        await dbContext.SaveChangesAsync();

        await footballersHub.Clients.All.SendAsync(FootballersHubMethods.NewFootballerAdded.ToString(), footballer!);
        Console.WriteLine("Signal was sent");

        return UnitResult.Success<ApplicationError>();
    }
    
    public async Task<UnitResult<ApplicationError>> EditFootballerAsync(Guid footballerId, EditFootballerRequest request)
    {
        var footballer = await dbContext.Footballers.FirstOrDefaultAsync(f => f.Id == footballerId);
        if (footballer is null)
            return new ApplicationError("Bad request", "Футболист не найден");

        var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == request.TeamId);
        if (team is null)
            return new ApplicationError("Bad request", "Команда не найдена");
        
        footballer.Name = request.Name;
        footballer.Surname = request.Surname;
        footballer.Gender = request.Gender;
        footballer.BirthDate = request.BirthDate;
        footballer.Country = request.Country;
        footballer.Team = team;
        await dbContext.SaveChangesAsync();
        
        return UnitResult.Success<ApplicationError>();
    }
}