﻿using Finshark.Dtos.Account;
using Finshark.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finshark.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if (roleResult.Succeeded)
                    {
                        return Ok("User created successfully");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }

                return StatusCode(500, createUser.Errors);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
