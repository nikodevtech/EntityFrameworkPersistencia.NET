using DAL.Entidades.DAO;
using DAL.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models.ToDAO
{

    /// <summary>
    ///     Clase que convierte entre objetos DTO a entidades DAO
    /// </summary>
    public class ToDAO
    {
        /// <summary>
        ///     Método que convierte una NotaDTO en una NotaDAO
        /// </summary>
        /// <param name="notaDTO">
        ///     Recibe una nota del tipo NotaDTO
        /// </param>
        /// <returns>
        ///     Devuelve una nota del tipo Nota (entidad original)
        /// </returns>
        public static Nota NotaDTOToDAO(NotaDTO notaDTO)
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método estático NotaDTOToDAO de la clase ToDAO");

            Nota nota = new Nota();

            nota.codAlumno = notaDTO.Cod_alumno1;
            nota.notaEval = notaDTO.Nota_evaluacion1;
            nota.codEvaluacion = notaDTO.Cod_evaluacion1;

            Console.WriteLine("\t\t--[INFO]-- Saliendo del método estático NotaDTOToDAO de la clase ToDAO");

            return nota;
        }

        /// <summary>
        ///     Método que convierte una EvaluacionDTO en una EvaluacionDAO
        /// </summary>
        /// <param name="evaluacionDTO">
        ///     Recibe una Evaluacion del tipo EvaluacionDTO
        /// </param>
        /// <returns>
        ///     Devuelve una evaluacion del tipo Evaluacion (entidad original)
        /// </returns>
        public static Evaluacion EvaluacionDTOToDao(EvaluacionDTO evaluacionDTO) 
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método estático EvaluacionDTOToDAO de la clase ToDAO");

            Evaluacion evaluacion = new Evaluacion();

            evaluacion.codEvaluacion = evaluacionDTO.CodEvaluacion;
            evaluacion.descripcionEval = evaluacionDTO.DescripcionEval;

            List<Nota> notas = new List<Nota>();
            foreach (NotaDTO n in evaluacionDTO.Notas)
            {
                notas.Add(NotaDTOToDAO(n));
            }

            evaluacion.listaNotas = notas;

            Console.WriteLine("\t\t--[INFO]-- Saliendo del método estático EvaluacionDTOToDAO de la clase ToDAO");

            return evaluacion;
        }
    }
}
