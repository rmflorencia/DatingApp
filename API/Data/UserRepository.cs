using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        public async Task<MemberDTO> GetMemberAsync(string username)
        {
            return await context.Users
                .Where(u => u.UserName == username)
                .ProjectTo<MemberDTO>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersAsync()
        {
            return await context.Users
                .ProjectTo<MemberDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await context.Users
            .Include(u => u.Photos)
            .SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await context.Users
            .Include(u => u.Photos)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}