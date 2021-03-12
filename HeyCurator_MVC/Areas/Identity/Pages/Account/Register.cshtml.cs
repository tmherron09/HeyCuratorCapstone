using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace HeyCurator_MVC.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private ApplicationDbContext _context;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public SelectList CuratorRoles { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [AllowNull]
            [Display(Name = "Assigned Curator Role")]
            public int CuratorRoleId { get; set; }
            [AllowNull]
            public string Title { get; set; }

            [Required]
            public string AdminSecretsPasscode { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var roles = _context.CuratorRoles.ToList();
            CuratorRoles = new SelectList(roles, "CuratorRoleId", "NameOfRole");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Admin/Index");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            // Remove hardcoded AdminSecrets Passcode.
            if (ModelState.IsValid && Input.AdminSecretsPasscode == "!2020!HeyCuratorAdmim")
            {
                var user = new IdentityUser { UserName = Input.FirstName + Input.LastName[0], Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    Employee addedEmployee = new Employee
                    {
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        EmployeeUserName = Input.FirstName + Input.LastName[0],
                        IdentityUser = user.Id,
                        Title = Input.Title
                    };

                    _context.Employees.Add(addedEmployee);
                    _context.SaveChanges();

                    EmployeeRoles employeeRole = new EmployeeRoles
                    {
                        EmployeeId = addedEmployee.EmployeeId,
                        CuratorRoleId = Input.CuratorRoleId
                    };
                    _context.EmployeeRoles.Add(employeeRole);
                    _context.SaveChanges();


                    _logger.LogInformation("User created a new account with password.");

                    HttpContext.Session.SetString("username", user.UserName);
                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
