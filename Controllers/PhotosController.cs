using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using akaratak_app.Data;
using akaratak_app.Dtos;
using akaratak_app.Helpers;
using akaratak_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace akaratak_app.Controllers
{
    [Route("api/[controller]")]
    public class PhotosController : Controller
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IPropertyRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this._cloudinaryConfig = cloudinaryConfig;
            this._mapper = mapper;
            this._repo = repo;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);

        }
        [HttpGet("{propertyId}", Name = "GetPhotos")]
        public async Task<IActionResult> GetPhotos(int propertyId)
        {
            var photosFromRepo = await _repo.GetPhotos(propertyId);
            var photo = _mapper.Map<ICollection<PhotoForReturnDto>>(photosFromRepo);
            return Ok(photo);
        }

        [HttpPost("{propertyId}")]
        public async Task<IActionResult> AddPhotoForProperty(int propertyId)
        {
            var property = await _repo.GetProperty(propertyId);

            if (property == null)
                return BadRequest("Invalid Property");
            foreach (var item in Request.Form.Files)
            {
                //check with idenety
                var photoDto = new PhotoToInsertDto();
                var file = item;

                var uploadResult = new ImageUploadResult();

                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.Name, stream),
                            Transformation = new Transformation().Width(1200).Height(1000).Crop("fill")
                        };
                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }
                photoDto.Url = uploadResult.Uri.ToString();
                photoDto.PublicId = uploadResult.PublicId;

                var photo = _mapper.Map<Photo>(photoDto);

                if (!property.Photos.Any(m => m.IsMain))
                    photo.IsMain = true;

                property.Photos.Add(photo);
            }

            if (await _repo.SaveAll())
            {
                return CreatedAtRoute("GetPhotos", new { id = propertyId });
            }
            return BadRequest("Could Not Add Photo");
        }

    }
}
