using System.Net;
using System.Threading.Tasks;
using RestSharp;
using Xunit;
using TechTalk.SpecFlow;
using Planner.Tests.Hooks;
using Planner.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Planner.Tests.Steps;

[Binding]
public sealed class AttractieStepDefinitions
{
    private readonly RestClient _client;
    private readonly DatabaseData _databaseData;
    private RestResponse? response;

    public AttractieStepDefinitions(DatabaseData databaseData)
    {
        _databaseData = databaseData;
        _client = new RestClient("http://localhost:5001/");

        // Het HTTPS certificaat hoeft niet gevalideerd te worden, dus return true
        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
    }

    [Given("attractie (.*) bestaat")]
    public async Task AttractieBestaat(string naam)
    {
        await _databaseData.Context.Attractie.AddAsync(new Attractie { Naam = naam });
        await _databaseData.Context.SaveChangesAsync();
    }

    [Given("attractie (.*) bestaat niet")]
    public async Task AttractieBestaatniet(string naam)
    {
        await _databaseData.Context.Attractie.AddAsync(new Attractie { Naam = naam});
        await _databaseData.Context.SaveChangesAsync();
        var attracties = await _databaseData.Context.Attractie.ToListAsync();
        var attractie = attracties.Find(at => at.Naam == naam);

        _databaseData.Context.Attractie.Remove(attractie);
        await _databaseData.Context.SaveChangesAsync();
    }

    [When("attractie (.*) wordt opgevraagd")]
    public async Task AttractieOpvragen(string naam)
    {
        var request = new RestRequest("api/Attracties/1");
        response = await _client.ExecuteGetAsync(request);
    }

    [When("attractie (.*) wordt toegevoegd")]
    public async Task AttractieToevoegen(string naam)
    {
        var request = new RestRequest("api/Attracties").AddJsonBody(new { Naam = naam, Reserveringen = new List<string>() });
        response = await _client.ExecutePostAsync(request);
    }

    [When("attractie (.*) wordt verwijderd")]
    public async Task AttractieVerwijderen(string naam)
    {
        var request = new RestRequest("api/Attracties/1");
        response = await _client.DeleteAsync(request);
    }

    [Then("moet er een error (.*) komen")]
    public void Error(int httpCode)
    {
        Assert.Equal(httpCode, (int)response!.StatusCode);
    }
}

class AttractieToegevoegd
{
    public int Id { get; set; }
}