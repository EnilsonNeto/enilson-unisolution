using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace EnilsonSolution.Tanks.Dto
{
    [AutoMap(typeof(Tank))]
    public class TankDto : FullAuditedEntityDto<string>
    {
        [Required]
        [StringLength(Tank.MaxDepositoLength, ErrorMessage = "O campo Deposito deve ter no máximo 1024 caracteres.")]
        public string Deposito { get; set; }

        [Required(ErrorMessage = "O campo Capacidade é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "A capacidade deve ser um valor positivo.")]
        public decimal Capacity { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Produto é obrigatório.")]
        [StringLength(Tank.MaxProductTypeLength, ErrorMessage = "O campo Tipo de Produto deve ter no máximo 512 caracteres.")]
        public string ProductType { get; set; }
    }
}
