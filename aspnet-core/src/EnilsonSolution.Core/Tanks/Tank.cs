using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnilsonSolution.Tanks
{
    [Table("Tank")]
    public class Tank : FullAuditedEntity<string>
    {
        public const int MaxDepositoLength = 1024;
        public const int MaxProductTypeLength = 512;

        [Key]
        [Column("Deposito")]
        [StringLength(MaxDepositoLength)]
        public string Deposito { get; set; } 

        [Column("Capacidade")]
        public decimal Capacity { get; set; }

        [Required]
        [Column("TipoDeProduto")]
        [StringLength(MaxProductTypeLength)]
        public string ProductType { get; set; }
    }
}
