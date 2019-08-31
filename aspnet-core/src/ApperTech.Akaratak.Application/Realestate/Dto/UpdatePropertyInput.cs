using Abp.Application.Services.Dto;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class UpdatePropertyInput : IEntityDto<int>
    {
        public virtual int Id { get; set; }
    }
}