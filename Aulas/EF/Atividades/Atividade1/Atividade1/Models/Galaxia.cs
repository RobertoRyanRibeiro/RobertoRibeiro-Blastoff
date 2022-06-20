using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1.Models
{
    [Table("Galaxia")]
    public class Galaxia
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
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Tamanho", TypeName = "VARCHAR")]
        public string Tamanho { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Column("Tipo", TypeName = "VARCHAR")]
        public string Tipo { get; set; }

    }
}
