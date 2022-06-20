using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3.Model
{
    [Table("Computador")]
    [Index(propertyNames:"Id_Empresa",Name = "IX_Computador_IdEmpresa",IsUnique = false)]
    public class Computador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [MaxLength(80)]
        [Column(name: "Nome", TypeName = "VARCHAR")]
        public string? Nome { get; set; }
        [Column(name:"Ano_Fab",TypeName = "INT")]
        public int? AnoFab { get; set; }
        [MaxLength(80)]
        [Column(name: "Linha", TypeName = "VARCHAR")]
        public string? Linha { get; set; }
        [MaxLength(80)]
        [Column(name: "Modelo_Cpu", TypeName = "VARCHAR")]
        public string? Modelo_Cpu{ get; set; }
        [Column(name: "Qtd_Cpu", TypeName = "INT")]
        public int? Qtd_Cpu{ get; set; }
        [MaxLength(80)]
        [Column(name: "Qtd_Ram", TypeName = "VARCHAR")]
        public string? Qtd_Ram{ get; set; }
        
        [MaxLength(80)]
        [ForeignKey("Empresa")]
        [Column(name: "Id_Empresa", TypeName = "VARCHAR")]
        public string? Id_Empresa{ get; set; }
        public Empresa Empresa { get; set; }

        public ICollection<Compativel> Compativels{ get; set; }
        public ICollection<Compativel> Compativels2{ get; set; }
        public ICollection<Funciona> Funcionas{ get; set; }


    }
}
