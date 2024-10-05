using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HypermediaValidation.Models;

public class UserWebModel
{
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Длинна имени должна быть от 3 до 10 символов")]
    public string? Name { get; init; }

    [Display(Name = "Дата рождения")]
    [Required(ErrorMessage = "Пожалуйста, ведите дату рождения")]
    [DataType(DataType.Date)]
    public DateTime? BirthDay { get; init; }
    
    [Display(Name = "Согласен с правилами")]
    public bool IsTermsAccepted { get; init; }

    public void Validate(ModelStateDictionary state)
    {
        if (IsTermsAccepted == false)
        {
            state.AddModelError(nameof(IsTermsAccepted), 
                "Необходимо подтвердить согласие с правилами");
        }
        if (BirthDay >= DateTime.Now)
        {
            state.AddModelError(nameof(BirthDay), 
                "Дата рождения должна быть в прошлом");
        }
    }
}