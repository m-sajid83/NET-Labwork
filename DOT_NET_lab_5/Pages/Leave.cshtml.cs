using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DOT_NET_lab_5.Pages
{
    public class LeaveModel : PageModel
    {
        public string UserName { get; set; }

        [BindProperty]
        public string LeaveType { get; set; }

        [BindProperty]
        public DateTime? LeaveDate { get; set; }

        public string Result { get; set; }

        public void OnGet()
        {
            if (Request.Cookies["EmployeeUser"] == null)
            {
                Response.Redirect("/");
                return;
            }

            UserName = Request.Cookies["EmployeeUser"];

            HttpContext.Session.SetString("UserName", UserName);
        }

        public IActionResult OnPostApply()
        {
            if (Request.Cookies["EmployeeUser"] == null)
            {
                return RedirectToPage("/Index");
            }

            UserName = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(UserName))
            {
                UserName = Request.Cookies["EmployeeUser"];
            }

            if (string.IsNullOrEmpty(LeaveType))
            {
                Result = "Please select a Leave Type.";
                return Page();
            }

            if (!LeaveDate.HasValue)
            {
                Result = "Please select a Leave Date.";
                return Page();
            }

            string leaveDate = LeaveDate.Value.ToString("dd-MM-yyyy");

            Result =
                "Leave Applied Successfully!<br/>" +
                "Employee Name: " + UserName + "<br/>" +
                "Leave Type: " + LeaveType + "<br/>" +
                "Leave Date: " + leaveDate;

            return Page();
        }

        public IActionResult OnPostLogout()
{
            HttpContext.Session.Clear();

            Response.Cookies.Delete("EmployeeUser");

            return RedirectToPage("/Index");
}
    }
}