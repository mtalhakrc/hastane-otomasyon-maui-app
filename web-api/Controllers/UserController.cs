using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_api.Dtos;
using web_api.Models;
using web_api.ViewModels;

namespace web_api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController :Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public UserController(ILogger<UserController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser>signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        // Retrieve the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        // Retrieve the roles of the current user
        var roles = await _userManager.GetRolesAsync(user);
        

        // Create the view model
        var meViewModel = new UserViewmodel.MeViewModel
        {
            UserName = user.UserName!,
            Email = user.Email!,
            Roles = roles // todo: yalnızca bir rolü olması lazım aslında
        };

        return Ok(meViewModel);
    }
    
    [HttpPut("me")]
    [Authorize]
    public async Task<IActionResult> MeUpdate([FromBody] User.UserDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        user.UserName = model.UserName ?? user.UserName;
        user.Email = model.Email ?? user.Email;
        user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return NoContent(); // HTTP 204 No Content
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }
    
    [HttpPost]
    [Route("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            if (model is null)
                return BadRequest("");


            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("No user found!");

            Microsoft.AspNetCore.Identity.SignInResult checkOldPassword =
                await _signInManager.PasswordSignInAsync(user.UserName, model.OldPassword, false, false);

            if (!checkOldPassword.Succeeded)
                return BadRequest("Old password does not matched.");

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (string.IsNullOrEmpty(resetToken))
                return BadRequest("Error while generating reset token.");

            var result = await _userManager.ResetPasswordAsync(user, resetToken, model.Password);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
