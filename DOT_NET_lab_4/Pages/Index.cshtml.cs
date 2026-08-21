using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "Enter Name")]
    public string FullName { get; set; } = "";

    [BindProperty]
    [Required(ErrorMessage = "Enter Email")]
    [RegularExpression(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        ErrorMessage = "Invalid Email")]
    public string Email { get; set; } = "";

    [BindProperty]
    [Required(ErrorMessage = "Enter Mobile")]
    [RegularExpression(
        @"^[0-9]{10}$",
        ErrorMessage = "Enter 10 Digit Mobile")]
    public string Mobile { get; set; } = "";

    [BindProperty]
    [Required(ErrorMessage = "Enter College")]
    public string College { get; set; } = "";

    [BindProperty]
    public string Department { get; set; } = "";

    [BindProperty]
    public string Event { get; set; } = "";

    [BindProperty]
    public string Gender { get; set; } = "";

    [BindProperty]
    public List<string> Skills { get; set; } = new List<string>();

    [BindProperty]
    public string Address { get; set; } = "";

    [BindProperty]
    public bool TermsAccepted { get; set; }

    public bool IsSubmitted { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        IsSubmitted = true;
    }
}