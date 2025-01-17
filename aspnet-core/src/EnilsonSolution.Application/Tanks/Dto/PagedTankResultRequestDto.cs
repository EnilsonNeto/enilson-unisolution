using Abp.Application.Services.Dto;

namespace EnilsonSolution.Tanks.Dto
{
    public class PagedTankResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
