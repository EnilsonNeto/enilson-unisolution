using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace EnilsonSolution.Tanks.Dto
{
    [AutoMapTo(typeof(Tank))]
    public class CreateTankDto
    {
        [Required]
        [StringLength(Tank.MaxDepositoLength)]
        public string Deposito { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Capacity { get; set; }

        [Required]
        [StringLength(Tank.MaxProductTypeLength)]
        public string ProductType { get; set; }
    }
}
