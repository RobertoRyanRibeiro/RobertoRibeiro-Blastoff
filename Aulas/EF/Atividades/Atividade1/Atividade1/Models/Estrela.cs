using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1.Models
{
    [Table("Estrela")]
    public class Estrela
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
        [Column("Luminosidade", TypeName = "FLOAT")]
        public float Luminosidade { get; set; }

        [Required]
        [ForeignKey("Galaxia_Id")]
        [Column("Galaxia_Id", TypeName = "INT")]
        public int GalaxiaId { get; set; }
        public Galaxia Galaxia { get; set; }
        
    }
}
