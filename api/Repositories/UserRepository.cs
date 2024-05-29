using api.Data;
using api.DTOModels;
using api.Entities;
using api.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _context.Users
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            var user = await _context.Users
                .Where(x => x.UserName == username)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<UserDTO> GetUserDTOByIdAsync(int id)
        {
            var user = await _context.Users
                .Where(x => x.Id == id)
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public Task<UserDTO> GetUserDTOByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync() { 
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
