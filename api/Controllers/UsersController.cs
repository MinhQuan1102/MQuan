using api.DTOModels;
using api.Entities;
using api.Extensions;
using api.Interfaces;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserDTOByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO userDTO)
        {
            var id = User.GetUserId();
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            _mapper.Map(userDTO, user);

            if (!(await _unitOfWork.UserRepository.SaveAllAsync())) 
            {
                return BadRequest("Failed to update user");   
            }
            return Ok(user);
        }

    }
}
