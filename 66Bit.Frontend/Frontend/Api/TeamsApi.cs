using Core.Models;
using CSharpFunctionalExtensions;
using Frontend.Helpers;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using HttpClient = Frontend.Core.HttpClient;

namespace Frontend.Api;

public class TeamsApi(IHttpClientFactory httpClientFactory)
{
    public async Task<Result<List<Team>, ProblemDetails>> FetchTeamsAsync()
    {
        var httpClient = httpClientFactory.CreateClient(HttpClient.Api.ToString());
        var response = await httpClient.GetAsync("/api/teams");
        if (response.IsSuccessStatusCode)
        {
            var teams = await response.Content.ReadFromJsonAsync<List<Team>>();
            return teams!;
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

    public async Task<UnitResult<ProblemDetails>> AddTeamAsync(AddTeamModel model)
    {
        var httpClient = httpClientFactory.CreateClient(HttpClient.Api.ToString());
        var response = await httpClient.PostAsJsonAsync("/api/teams", model);
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