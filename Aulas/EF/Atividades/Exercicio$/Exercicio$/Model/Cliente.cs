using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4.Model
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [MaxLength(15)]
        [Column(name: "Cpf", TypeName = "VARCHAR")]
        public string Cpf { get; set; }
        [Required]
        [MaxLength(80)]
        [Column(name: "Nome",TypeName = "VARCHAR")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(15)]
        [Column(name: "Telefone",TypeName = "VARCHAR")]
        public string Telefone { get; set; }

        [MaxLength(9)]
        [Column(name: "Cep", TypeName = "VARCHAR")]
        public string? Cep { get; set; }
    }
}
