using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades.DAO
{

    /// <summary>
    ///     Clase Nota de tipo Entidad DAO que representa y mapea con la tabla 'eva_tch_notas_evaluacion' en la base de datos
    /// </summary>
    [Table("eva_tch_notas_evaluacion", Schema = "sc_evaluacion")]
    public class Nota
    {
        [Column("md_uuid")]
        public string? mdUuid { get; set; }

        [Column("md_fch")]
        public DateTime? mdFch { get; set; }

        [Key]
        [Column("id_nota_evaluacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idNotaEval { get; set; }

        [Required]
        [Column("cod_alumno")]
        public string codAlumno { get; set; }

        [Required]
        [Column("nota_evaluacion")]
        public int notaEval { get; set; }

        [Required]
        [Column("cod_evaluacion")]
        public string codEvaluacion { get; set; }

        [ForeignKey("codEvaluacion")]
        public Evaluacion evaluacion { get; set; }


        public Nota()
        {
        }

        public Nota(string codAlumno, int notaEval, Evaluacion eval) 
        {
            this.codAlumno = codAlumno;
            this.notaEval = notaEval;
            this.evaluacion = eval;
        }

    }
}
