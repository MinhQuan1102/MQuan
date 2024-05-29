using api.DTOModels;
using api.Entities;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthDTO>> Register([FromBody] RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Username)) return BadRequest("Username has been taken!");
            var user = _mapper.Map<User>(registerDTO);
            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return new AuthDTO
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthDTO>> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.Username);
            if (user == null) return Unauthorized("Invalid username or password");

            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!result) return Unauthorized("Invalid username of password");

            return new AuthDTO
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email);
        }
    }
}
