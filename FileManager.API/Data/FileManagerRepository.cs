using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.API.Helpers;
using FileManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FileManager.API.Data
{
    public class FileManagerRepository : IFileManagerRepository
    {
        private readonly DataContext _context;

        public FileManagerRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.OrderBy(u => u.LastName).AsQueryable();

            return await PagedList<User>.CreateAsync(users,userParams.PageNumber,userParams.PageSize);
        }

        public async Task<File> GetFile(int id)
        {
            var File = await _context.Files.FirstOrDefaultAsync(p => p.Id == id);

            return File;
        }
        public async Task<Role> GetRole(int id)
        {
            var Role = await _context.Roles.FirstOrDefaultAsync(p => p.Id == id);

            return Role;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}