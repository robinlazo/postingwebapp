
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SocialMedia.Controllers;


public class AccountController : Controller {
    private SignInManager<ApplicationUser> signInManager { get; }
    private UserManager<ApplicationUser> userManager { get; }

    private PostingContextUnitOfWork data { get; }

    public AccountController(SignInManager<ApplicationUser> signIn, 
                             UserManager<ApplicationUser> userMngr, PostingContext ctx) {
        signInManager = signIn;
        userManager = userMngr;
        data = new PostingContextUnitOfWork(ctx);
    }

    [Authorize]
    public async Task<IActionResult> Info(int? id) {

        id = id ?? GetUserID();
        var userInfo = await userManager.FindByIdAsync(id.ToString());

        var vm = new UserInfoViewModel
        {
            User = userInfo,
            UserPosts = data.Posts.List(new QueryOptions<Post> {
                Where = p => p.UserID == id,
                Include = "Comments, Category",
                OrderBy = p => p.Time
            })
        };

        return View(vm);
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterUserDTO());
     
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> LogOut() {
        await signInManager.SignOutAsync();
        return RedirectToAction("Register");
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult LogIn(string returnUrl = "") {
        var model = new LogInDTO {ReturnURL = returnUrl};
        return View(model);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> LogIn(LogInDTO userData) {
        if(ModelState.IsValid) {
            ApplicationUser user = await userManager.FindByEmailAsync(userData.Email);

            if(user == null) {
                ModelState.AddModelError(nameof(LogInDTO.Email), $"{userData.Email} not found with any existing account");
                return View(userData);
            }
            
            var result = await signInManager.PasswordSignInAsync(user.UserName, userData.Password, userData.RememberMe, lockoutOnFailure: false);
            if(result.Succeeded) {
                if(!string.IsNullOrEmpty(userData.ReturnURL) && 
                    Url.IsLocalUrl(userData.ReturnURL)) {
                    return Redirect(userData.ReturnURL);
                } else {
                    return RedirectToAction("Index", "Home");
                }
            }     
        }

        ModelState.AddModelError(nameof(LogInDTO.Email), "Invalid Email/Password");
        return View(userData);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserDTO userData) {
        if(ModelState.IsValid)  {

            ApplicationUser newUser = new ApplicationUser { UserName = userData.Username, 
                                    CreationTime = DateTime.Now, Email = userData.Email};

            var result = await userManager.CreateAsync(newUser, userData.Password);

            if(result.Succeeded) {
                await signInManager.SignInAsync(newUser, isPersistent: true);
                return RedirectToAction("Index", "Home");
            } else {
                foreach(var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }   
        return View(userData);
    }

    private int GetUserID() => Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
}