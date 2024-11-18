using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Frontend.Models;

public class EditFootballerModel(Footballer footballer)
{
    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 50 символов")]
    public string Name { get; set; } = footballer.Name;

    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна содержать от 2 до 50 символов")]
    public string Surname { get; set; } = footballer.Surname;

    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; } = footballer.BirthDate;

    [Required(ErrorMessage = "Страна обязательна")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Страна должна содержать от 2 до 50 символов")]
    public string Country { get; set; } = footballer.Country;

    [Required(ErrorMessage = "Команда обязательна")]
    public Guid TeamId { get; set; } = footballer.Team.Id;
}