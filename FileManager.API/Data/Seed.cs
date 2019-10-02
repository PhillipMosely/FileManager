using System;
using System.Collections.Generic;
using System.Linq;
using FileManager.API.Models;
using Newtonsoft.Json;

namespace FileManager.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context) 
        {
            if (!context.Users.Any())
            {
                var roles = new Role[2];
                var role = new Role { 
                    RoleName="Admin",
                    Description="Administrative Role"};
                roles.Append(role);
                    
                var role2 = new Role {
                    RoleName="Users",
                    Description="User Role"};
                roles.Append(role2);

                context.Roles.AddRange(roles);

                var user = new User {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };            
                
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password",out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                context.Users.Add(user);
            }


            // if (!context.Users.Any())
            // {
            //     var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            //     var users = JsonConvert.DeserializeObject<List<User>>(userData);
            //     foreach (var user in users)
            //     {
            //         byte[] passwordHash, passwordSalt;
            //         CreatePasswordHash("password",out passwordHash, out passwordSalt);
            //         user.PasswordHash = passwordHash;
            //         user.PasswordSalt = passwordSalt;
            //         user.Username = user.Username.ToLower();
            //         context.Users.Add(user);
            //     }
            // }


            context.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }        

    }
}