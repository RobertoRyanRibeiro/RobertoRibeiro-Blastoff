using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1.Models
{
    [Table("Planeta")]
    public class Planeta
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Nome", TypeName = "VARCHAR")]
        public string Nome { get; set; }

        [Column("Massa", TypeName = "DECIMAL")]
        public decimal? Massa { get; set; }

        [Required]
        [Column("Tamanho", TypeName = "DECIMAL")]
        public decimal Tamanho { get; set; }

        [Required]
        [Column("Habitavel", TypeName = "BIT")]
        public bool Habitavel{ get; set; }
        
        [Required]
        [Column("Distancia", TypeName = "DECIMAL")]
        public decimal Distancia{ get; set; }

        [Required]
        [ForeignKey("Estrela_Id")]
        [Column("Estrela_Id", TypeName = "INT")]
        public int EstrelaId { get; set; }
        public Estrela Estrela { get; set; }
    }
}
