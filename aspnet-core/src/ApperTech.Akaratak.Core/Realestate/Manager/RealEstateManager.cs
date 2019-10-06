using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.ObjectMapping;
using Abp.UI;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ApperTech.Akaratak.Realestate.Manager
{
    public class TagManager : DomainService, ITagManager
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagManager(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<ICollection<Tag>> GetByIds(ICollection<int> ids)
        {
            var tags = new List<Tag>();
            foreach (var id in ids) tags.Add(await _tagRepository.GetAsync(id));
            return tags;
        }

        public async Task<ICollection<Tag>> GetTags()
        {
            return await _tagRepository.GetAllListAsync();
        }
    }

    public class PhotoManager : DomainService, IPhotoManager
    {
        private readonly IRepository<Photo> _repository;
        private readonly ISettingManager _settingManager;
        private Cloudinary _cloudinary;
        public PhotoManager(IRepository<Photo> repository
            , ISettingManager settingManager)
        {
            _repository = repository;
            _settingManager = settingManager;
            InitCloudinary();
        }

        private async void InitCloudinary()
        {
            _cloudinary = new Cloudinary(
                new Account(
                    await _settingManager.GetSettingValueAsync("CloudinaryCloudName"),
                    await _settingManager.GetSettingValueAsync("CloudinaryApiKey"),
                    await _settingManager.GetSettingValueAsync("CloudinaryApiSecret")
                )
            );
        }

        public async Task<Photo> UploadPhoto(IFormFile file)
        {
            if (file.Length <= 0)
                throw new UserFriendlyException("No Image");

            ImageUploadResult uploadResult = await Task.Run(() =>
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(1200).Height(1000).Crop("fill")
                    };
                    return _cloudinary.Upload(uploadParams);
                }
            });
            return new Photo
            {
                Url = uploadResult.Uri.ToString(),
                PublicId = uploadResult.PublicId
            };
        }
    }
}
