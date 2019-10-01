using System;
using System.Collections.Generic;
using FileManager.API.Models;

namespace FileManager.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }      
        public string PhotoUrl {get; set;}  
    }
}