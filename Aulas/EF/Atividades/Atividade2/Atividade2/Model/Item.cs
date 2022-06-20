using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade2.Model
{
    [Table("Itens_Vendidos")]
    public class Item
    {
        [Key]
        [Column(name:"ID",TypeName ="INT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(name: "ID_NF", TypeName = "INT")]
        public int IdNF{ get; set; }

        [Required]
        [Column(name: "ID_ITEM", TypeName = "INT")]
        public int IdItem{ get; set; }

        [Required]
        [Column(name: "COD_PROD", TypeName = "INT")]
        public int CodProd{ get; set; }
        
        [Required]
        [Column(name: "VALOR_UNIT", TypeName = "FLOAT")]
        public float ValorUnit{ get; set; }
        
        [Required]
        [Column(name: "QUANTIDADE", TypeName = "INT")]
        public int Quantidade{ get; set; }
        
        [Column(name: "DESCONTO", TypeName = "INT")]
        public int? Desconto{ get; set; }
    }
}
