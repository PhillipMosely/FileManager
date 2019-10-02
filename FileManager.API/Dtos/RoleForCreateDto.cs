using System;

namespace FileManager.API.Dtos
{
    public class RoleForCreateDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }        
        public RoleForCreateDto()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}