using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3.Model
{
    [Table("Compativel")]
    public class Compativel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(name: "Id_Computador ", TypeName = "INT")]
        public int? Id_Computador { get; set; }
        public Computador Computador { get; set; }

        [Column(name: "Id_Computador2 ", TypeName = "INT")]
        public int? Id_Computador2 { get; set; }
        public Computador Computador2 { get; set; }
    }
}
