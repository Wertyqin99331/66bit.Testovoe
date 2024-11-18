using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Frontend.Models;

public class AddFootballerModel
{
    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 50 символов")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна содержать от 2 до 50 символов")]
    public string Surname { get; set; } = "";

    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required(ErrorMessage = "Страна обязательна")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Страна должна содержать от 2 до 50 символов")]
    public string Country { get; set; } = "";

    [Required(ErrorMessage = "Команда обязательна")]
    public Guid? TeamId { get; set; }
}