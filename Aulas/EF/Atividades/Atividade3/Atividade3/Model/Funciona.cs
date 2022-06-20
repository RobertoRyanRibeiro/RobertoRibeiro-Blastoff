using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3.Model
{
    [Table("Funciona")]
    public class Funciona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("Computador")]
        [Column(name: "Id_Computador ", TypeName = "INT")]
        public int? Id_Computador { get; set; }
        public Computador Computador{ get; set; }
        
        [ForeignKey("Software")]
        [Column(name: "Id_Software ", TypeName = "INT")]
        public int? Id_Software { get; set; }
        public Software Software{ get; set; }

        
    }
}
