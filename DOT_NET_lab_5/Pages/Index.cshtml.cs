using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DOT_NET_lab_5.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            if (Request.Cookies["EmployeeUser"] != null)
            {
                Response.Redirect("/Leave");
            }
        }

        public IActionResult OnPost()
        {
            Name = Name?.Trim();
            Password = Password?.Trim();

            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Password))
            {
                Message = "Please enter Name and Password.";
                return Page();
            }

            HttpContext.Session.SetString("UserName", Name);

            CookieOptions options = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(30),
                HttpOnly = true
            };

            Response.Cookies.Append("EmployeeUser", Name, options);

            return RedirectToPage("/Leave");
        }
    }
}