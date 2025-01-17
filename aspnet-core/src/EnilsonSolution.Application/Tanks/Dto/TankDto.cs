using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace EnilsonSolution.Tanks.Dto
{
    [AutoMap(typeof(Tank))]
    public class TankDto : AuditedEntityDto<string>
    {
        [Required]
        [StringLength(Tank.MaxDepositLength)]
        public string Deposit { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Capacity { get; set; }

        [Required]
        [StringLength(Tank.MaxProductTypeLength)]
        public string ProductType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
