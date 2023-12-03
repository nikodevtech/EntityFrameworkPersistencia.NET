using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades.DTO
{
    /// <summary>
    ///     Clase Evaluación DTO con los datos de la evaluación
    /// </summary>
    public class EvaluacionDTO
    {

        private string codEvaluacion;
        private string descripcionEval;

        private List<NotaDTO> listaNotas = new List<NotaDTO>();

        public EvaluacionDTO() 
        { 
        }

        public EvaluacionDTO(string cod_evaluacion, string desc_evaluacion) 
        {
            this.CodEvaluacion = cod_evaluacion;
            this.DescripcionEval = desc_evaluacion;
        }

        public EvaluacionDTO(string cod_evaluacion, string desc_evaluacion, List<NotaDTO> notas) 
        {
            this.CodEvaluacion = cod_evaluacion;
            this.DescripcionEval = desc_evaluacion;
            this.Notas = notas;
        }

        public string DescripcionEval { get => descripcionEval; set => descripcionEval = value; }
        public string CodEvaluacion { get => codEvaluacion; set => codEvaluacion = value; }
        public List<NotaDTO> Notas { get => listaNotas; set => listaNotas = value; }


        /// <summary>
        ///     Muestra la información de la evaluación
        /// </summary>
        public void mostrarDatosEvaluacion() 
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método mostrarDatosEvaluacion de EvaluacionDTO");
            Console.WriteLine("\n\t*** Datos de la Evaluación ***\n\tDescripción de Evaluación: {0}",this.DescripcionEval);
            Console.WriteLine("\t\t--[INFO]-- Saliendo del método mostrarDatosEvaluacion de EvaluacionDTO");

        }
    }
}
