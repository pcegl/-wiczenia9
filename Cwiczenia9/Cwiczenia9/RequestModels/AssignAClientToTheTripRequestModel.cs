namespace Cwiczenia9.RequestModels;

using System;
using System.ComponentModel.DataAnnotations;

public class AssignAClientToTheTripRequestModel
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(120, ErrorMessage = "First name cannot be longer than 50 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(120, ErrorMessage = "Last name cannot be longer than 50 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Telephone is required")]
    [Phone(ErrorMessage = "Invalid telephone number")]
    public string Telephone { get; set; }

    [Required(ErrorMessage = "PESEL is required")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must be 11 digits")]
    public string Pesel { get; set; }

    [DataType(DataType.Date)]
    public DateTime? PaymentDate { get; set; }
}