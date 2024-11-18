using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Models;

public class Team
{
    protected Team()
    {
    }

    public Team(string name)
    {
        this.Name = name;
    }


    [JsonConstructor]
    public Team(Guid id, string name) : this(name)
    {
        this.Id = id;
    }

    public Guid Id { get; private set; }

    public string Name { get; set; } = null!;

    public List<Footballer> Footballers { get; private set; } = [];
}