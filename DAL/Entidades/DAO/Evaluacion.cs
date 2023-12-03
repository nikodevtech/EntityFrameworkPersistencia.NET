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
    ///     Clase Evaluacion de tipo Entidad DAO que representa y mapea con la tabla 'eva_cat_evaluacion' en la base de datos
    /// </summary>
    [Table("eva_cat_evaluacion", Schema = "sc_evaluacion")]
    public class Evaluacion
    {
        [Key]
        [Column("cod_evaluacion")]
        public string codEvaluacion { get; set; }
        [Required]
        [Column("desc_evaluacion")]
        public string descripcionEval { get; set; }

        [InverseProperty("evaluacion")]
        public virtual List<Nota> listaNotas { get; set; }

        public Evaluacion() { }

        public Evaluacion(string codEvaluacion, string descEvaluacion)
        {
            this.codEvaluacion = codEvaluacion;
            this.descripcionEval = descEvaluacion;
            this.listaNotas = new List<Nota>();
        }

       
    }
}
