using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnilsonSolution.Tanks
{
    [Table("Tanque")]
    public class Tank : AuditedEntity<string>
    {
        public const int MaxDepositLength = 1024;
        public const int MaxProductTypeLength = 512;

        [Key]
        [Column("Deposito")]
        [StringLength(MaxDepositLength)]
        public string Deposit { get; set; } 

        [Column("Capacidade")]
        public decimal Capacity { get; set; }

        [Required]
        [Column("TipoDeProduto")]
        [StringLength(MaxProductTypeLength)]
        public string ProductType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
