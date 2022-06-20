using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3.Model
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        [MaxLength(80)]
        [Column(name: "Cnpj", TypeName = "VARCHAR")]
        public string Cnpj { get; set; }
        [MaxLength(80)]
        [Column(name: "Nome", TypeName = "VARCHAR")]
        public string? Nome { get; set; }
        [MaxLength(80)]
        [Column(name: "Localizacao", TypeName = "VARCHAR")]
        public string? Localizacao { get; set; }

        public List<Computador> Computadores { get; set; }
        public List<Software> Softwares { get; set; }
    }
}
