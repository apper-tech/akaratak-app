using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace ApperTech.Akaratak.Realestate.Manager
{
    public interface ITagManager : IDomainService
    {
        Task<ICollection<Tag>> GetByIds(ICollection<int> ids);
        Task<ICollection<Tag>> GetTags();

    }

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
}
