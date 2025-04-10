﻿using Microsoft.EntityFrameworkCore;

namespace UserServiceAPI.Models
{
    public class UserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?>GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id); 
        }
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);    
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
           var user = await _context.Users.FindAsync(id);
            if(user !=null)
                 _context.Users.Remove(user);
            await _context.SaveChangesAsync();  
        }
    }
}
