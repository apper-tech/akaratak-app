using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using Abp.Domain.Services;
using ApperTech.Akaratak.Authorization.Users;
using Microsoft.AspNetCore.Http;

namespace ApperTech.Akaratak.Realestate.Manager
{
    public interface ITagManager : IDomainService
    {
        Task<ICollection<Tag>> GetByIds(ICollection<int> ids);
        Task<ICollection<Tag>> GetTags();

    }

    public interface IPhotoManager : IDomainService
    {
        Task<Photo> UploadPhoto(IFormFile file);
    }
}
