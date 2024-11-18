using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.Team;

public class CreateTeamRequest
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = null!;
}