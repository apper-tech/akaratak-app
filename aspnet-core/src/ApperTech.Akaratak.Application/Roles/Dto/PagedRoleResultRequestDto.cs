using Abp.Application.Services.Dto;

namespace ApperTech.Akaratak.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

