using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4.Model
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(name: "Data_Compra",TypeName ="DATETIME")]
        public DateTime Data { get; set; }

        [Required]
        [Column(name: "Quant", TypeName = "INT")]
        public int Quant { get; set; }

        [MaxLength(15)]
        [ForeignKey("Cliente_Cpf")]
        [Column(name:"Cliente_Cpf",TypeName ="VARCHAR")]
        public string Cliente_Cpf { get; set; }
        
        
        [ForeignKey("Produto_Id")]
        [Column(name: "Produto_Id", TypeName = "INT")]
        public int Produto_Id{ get; set; }
        
        [ForeignKey("Cliente_Cpf")]
        public Cliente Cliente { get; set; }
        [ForeignKey("Produto_Id")]
        public Produto Produto { get; set; }
    }
}
