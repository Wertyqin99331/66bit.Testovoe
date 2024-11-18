using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class AddTeamModel
{
    [Required(ErrorMessage = "Название команды обязательно")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Название команды должно содержать от 2 до 50 символов")]
    public string Name { get; set; } = "";
}