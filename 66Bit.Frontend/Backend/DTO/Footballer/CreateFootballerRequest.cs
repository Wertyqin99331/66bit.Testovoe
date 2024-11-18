using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Backend.DTO.Footballer;

public class CreateFootballerRequest
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Surname { get; set; } = null!;

    [Required] public Gender Gender { get; set; }
    [Required] public DateOnly BirthDate { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Country { get; set; } = null!;

    public Guid TeamId { get; set; }
}