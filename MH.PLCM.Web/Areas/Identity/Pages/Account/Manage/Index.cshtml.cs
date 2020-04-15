using MH.PLCM.Core.Entities;
using MH.PLCM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }



        private async Task LoadAsync(ApplicationUser user)
        {
            var dbUser = _db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            // var userName = await _userManager.GetUserNameAsync(user);
            // var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = dbUser.UserName;

            Input = new InputModel
            {
                PhoneNumber = dbUser.PhoneNumber,
                ContactName = dbUser.ContactName,
                Company = dbUser.Company,
                Location = dbUser.Location,
                Department = dbUser.Department,
                ContributionLevel = dbUser.ContributionLevel
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var applicationUser = _db.Users.Where(u => u.NormalizedEmail == User.Identity.Name.ToUpper()).FirstOrDefault();
            if (applicationUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(applicationUser);
                return Page();
            }
            else
            {


                applicationUser.PhoneNumber = Input.PhoneNumber;
                applicationUser.Department = Input.Department;
                applicationUser.Company = Input.Company;
                applicationUser.Location = Input.Location;
                applicationUser.ContactName = Input.ContactName;
                applicationUser.ContributionLevel = Input.ContributionLevel;

                try
                {

                    _db.Users.Update(applicationUser);
                    await _db.SaveChangesAsync();
                }
                catch
                {
                    throw new InvalidOperationException("Unexpected error occured in updating user");
                }
            }

            // var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            // if (Input.PhoneNumber != phoneNumber)
            // {
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //     if (!setPhoneResult.Succeeded)
            //     {
            //         var userId = await _userManager.GetUserIdAsync(user);
            //        throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
            //    }
            // }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public string ContactName { get; set; }
            public Company Company { get; set; }
            public Location Location { get; set; }
            public Department Department { get; set; }
            public ContributionLevel ContributionLevel { get; set; }
        }
    }
}
