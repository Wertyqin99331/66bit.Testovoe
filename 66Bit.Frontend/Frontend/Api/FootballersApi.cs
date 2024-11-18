using Core.Models;
using CSharpFunctionalExtensions;
using Frontend.Helpers;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using HttpClient = Frontend.Core.HttpClient;

namespace Frontend.Api;

public class FootballersApi(IHttpClientFactory httpClientFactory)
{
    public async Task<Result<List<Footballer>, ProblemDetails>> GetFootballersAsync()
    {
        var httpClient = httpClientFactory.CreateClient(HttpClient.Api.ToString());
        var response = await httpClient.GetAsync("/api/footballers");
        if (response.IsSuccessStatusCode)
        {
            var footballers = await response.Content.ReadFromJsonAsync<List<Footballer>>();
            return footballers!;
        }
        else
        {
            try
            {
                var apiError = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return apiError ?? ProblemDetailsHelper.GetDefaultProblemDetails();
            }
            catch
            {
                return ProblemDetailsHelper.GetDefaultProblemDetails();
            }
        }
    }
    
    public async Task<UnitResult<ProblemDetails>> AddFootballerAsync(AddFootballerModel model)
    {
        var httpClient = httpClientFactory.CreateClient(HttpClient.Api.ToString());
        var response = await httpClient.PostAsJsonAsync("/api/footballers", model);
        if (response.IsSuccessStatusCode)
        {
            return UnitResult.Success<ProblemDetails>();
        }

        try
        {
            var apiError = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            return apiError ?? ProblemDetailsHelper.GetDefaultProblemDetails();
        }
        catch
        {
            return ProblemDetailsHelper.GetDefaultProblemDetails();
        }
    }

    public async Task<UnitResult<ProblemDetails>> EditFootballerAsync(Guid footballerId, EditFootballerModel model)
    {
        var httpClient = httpClientFactory.CreateClient(HttpClient.Api.ToString());
        var response = await httpClient.PutAsJsonAsync($"/api/footballers/{footballerId}", model);

        if (response.IsSuccessStatusCode)
        {
            return UnitResult.Success<ProblemDetails>();
        }

        try
        {
            var apiError = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            return apiError ?? ProblemDetailsHelper.GetDefaultProblemDetails();
        }
        catch
        {
            return ProblemDetailsHelper.GetDefaultProblemDetails();
        }
    }
}