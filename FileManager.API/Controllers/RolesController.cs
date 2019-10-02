using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FileManager.API.Data;
using FileManager.API.Dtos;
using FileManager.API.Helpers;
using FileManager.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FileManager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IFileManagerRepository _repo;
        private readonly IMapper _mapper;

        public RolesController(IFileManagerRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repository;
           
        }

        [HttpGet("{id}", Name="GetRole")]
        public async Task<IActionResult> GetRole(int id)
        {
            var rolefromRepo = await _repo.GetRole(id);

            var role = _mapper.Map<RoleForListDto>(rolefromRepo);

            return Ok(role);
        }


        // [HttpPost]
        // public async Task<IActionResult> AddRole([FromForm]PhotoForCreationDto photoForCreationDto)
        // {
        //     if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //         return Unauthorized();

        //     var userFromRepo = await _repo.GetUser(userId);
        //     var file = photoForCreationDto.File;
        //     var uploadResult = new ImageUploadResult();

        //     if (file.Length > 0)
        //     {
        //         using (var stream = file.OpenReadStream())
        //         {
        //             var uploadParams = new ImageUploadParams()
        //             {
        //                 File = new FileDescription(file.Name, stream),
        //                 Transformation = new Transformation()
        //                     .Width(500).Height(500).Crop("fill").Gravity("face")
        //             };
        //             uploadResult = _cloudinary.Upload(uploadParams);
        //         }
        //     }

        //     photoForCreationDto.Url = uploadResult.Uri.ToString();
        //     photoForCreationDto.PublicId = uploadResult.PublicId;

        //     var photo = _mapper.Map<Photo>(photoForCreationDto);

        //     if (!userFromRepo.Photos.Any(u => u.IsMain))
        //         photo.IsMain = true;
            
        //     userFromRepo.Photos.Add(photo);

        //     if (await _repo.SaveAll())
        //     {
        //         var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
        //         return CreatedAtRoute("GetPhoto",new {id = photo.Id}, photoToReturn);
        //     }

        //     return BadRequest("Could not add the photo");
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePhoto(int userId, int id)
        // {
        //     if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //         return Unauthorized();

        //     var user = await _repo.GetUser(userId);
        //     if (!user.Photos.Any(p => p.Id == id))
        //         return Unauthorized();
            
        //     var photoFromRepo = await _repo.GetPhoto(id);

        //     if (photoFromRepo.IsMain)
        //         return BadRequest("You cannot delete your main photo");
            
        //     if (photoFromRepo.PublicID != null) 
        //     {

        //         var deleteParams = new DeletionParams(photoFromRepo.PublicID);
        //         var result = _cloudinary.Destroy(deleteParams);

        //         if (result.Result == "ok") 
        //             _repo.Delete(photoFromRepo);
        //     }
            
        //     if (photoFromRepo.PublicID == null)
        //     {
        //         _repo.Delete(photoFromRepo);
        //     }

        //     if (await _repo.SaveAll())
        //         return Ok();

        //     return BadRequest("Failed to delete the photo");
        // }
    }
}