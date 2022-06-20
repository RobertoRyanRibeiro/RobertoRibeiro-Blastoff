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
    [Table("Software")]
    [Index(propertyNames: "Id_Empresa", Name = "IX_Software_IdEmpresa", IsUnique = false)]
    public class Software
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(80)]
        [Column(name: "Nome", TypeName = "VARCHAR")]
        public string? Nome { get; set; }
        [Column(name: "AnoFab", TypeName = "INT")]
        public int? AnoFab { get; set; }
        [MaxLength(80)]
        [Column(name: "Armazenamento", TypeName = "VARCHAR")]
        public string? Armazenamento { get; set; }
        [MaxLength(80)]
        [ForeignKey("Empresa")]
        [Column(name: "Id_Empresa", TypeName = "VARCHAR")]
        public string? Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }
        public List<Funciona> Funcionas { get; set; }

    }
}
