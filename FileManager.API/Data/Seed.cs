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
                var role = new Role { 
                    RoleName="Admin",
                    Description="Administrative Role"};
                context.Roles.Add(role);
                    
                var role2 = new Role {
                    RoleName="Users",
                    Description="User Role"};
                context.Roles.Add(role2);

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

                var user2 = new User {
                    FirstName = "Test",
                    LastName = "User",
                    UserName = "testuser",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };            
                
                CreatePasswordHash("password",out passwordHash, out passwordSalt);
                user2.PasswordHash = passwordHash;
                user2.PasswordSalt = passwordSalt;

                context.Users.Add(user2);

                var userRole = new UserRole {
                    User = user,
                    Role = role
                };

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