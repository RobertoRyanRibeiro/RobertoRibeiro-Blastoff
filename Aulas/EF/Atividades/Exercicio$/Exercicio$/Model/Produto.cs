using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4.Model
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [Column(name: "Nome",TypeName ="VARCHAR")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(80)]
        [Column(name: "Tipo", TypeName = "VARCHAR")]
        public string Tipo{ get; set; }

        [Required]
        [Column(name: "Preco")]
        public float Preco { get; set; }

        [Required]
        [Column(name : "Quant", TypeName ="INT")]
        public int Quant{ get; set; }
    }
}
