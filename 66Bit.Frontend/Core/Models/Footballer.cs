using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Models;

public class Footballer
{
    public static readonly string[] Countries = ["США", "Италия", "Россия"];
    
    protected Footballer()
    {
    }

    public Footballer(string name, string surname, Gender gender, DateOnly birthDate, string country, Team team)
    {
        this.Name = name;
        this.Surname = surname;
        this.Gender = gender;
        this.BirthDate = birthDate;
        this.Country = country;
        this.Team = team;
    }

    [JsonConstructor]
    public Footballer(Guid id, string name, string surname, Gender gender, DateOnly birthDate, string country,
        Team team) : this(name, surname, gender, birthDate, country, team)
    {
        this.Id = id;
    }

    public Guid Id { get; private set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Country { get; set; } = null!;
    public Team Team { get; set; } = null!;

    public override string ToString()
    {
        return $"{this.Name} {this.Surname} {this.Country} {this.BirthDate} {this.Gender.ToString()} {this.Team?.Name}";
    }
}

public enum Gender
{
    Male,
    Female
}

public static class GenderExtensions
{
    public static string ToRussianString(this Gender gender)
    {
        return gender switch
        {
            Gender.Male => "Мужчина",
            Gender.Female => "Женщина",
            _ => throw new ArgumentOutOfRangeException(nameof(gender), gender, null)
        };
    }
}