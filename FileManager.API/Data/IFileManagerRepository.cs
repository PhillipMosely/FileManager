using System.Collections.Generic;
using System.Threading.Tasks;
using FileManager.API.Helpers;
using FileManager.API.Models;

namespace FileManager.API.Data
{
    public interface IFileManagerRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<PagedList<User>> GetUsers(UserParams userParams);
         Task<User> GetUser(int id);
         
         Task<File> GetFile(int id);
         
         Task<Role> GetRole(int id);

        
    }
}