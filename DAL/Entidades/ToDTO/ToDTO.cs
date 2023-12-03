using DAL.Entidades.DAO;
using DAL.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades.ToDTO
{

    /// <summary>
    ///     Clase que convierte entre Entidades DAO a DTO
    /// </summary>
    public class ToDTO
    {

        /// <summary>
        ///     Método que convierte una NotaDAO en una NotaDTO
        /// </summary>
        /// <param name="nota">
        ///     Recibe una nota del tipo Nota (entidad original)
        /// </param>
        /// <returns>
        ///     Devuelve una nota del tipo NotaDTO
        /// </returns>
        public static NotaDTO NotaDAOtoDTO(Nota nota)
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método estático NotaDAOToDTO de la clase ToDTO");

            NotaDTO notaDTO = new NotaDTO();

            notaDTO.Cod_alumno1 = nota.codAlumno;
            notaDTO.Cod_evaluacion1 = nota.codEvaluacion;
            notaDTO.Nota_evaluacion1 = nota.notaEval;
            switch (nota.codEvaluacion) 
            {
                case "PR":
                    notaDTO.DescripcionEvaluacion = "Primera Evaluación";
                    break;
                case "SG":
                    notaDTO.DescripcionEvaluacion = "Segunda Evaluación";
                    break;
                case "TC":
                    notaDTO.DescripcionEvaluacion = "Tercera Evaluación";
                    break;
            }

            Console.WriteLine("\t\t--[INFO]-- Saliendo del método estático NotaDAOToDTO de la clase ToDTO");

            return notaDTO;
        }
        /// <summary>
        ///     Método que convierte una EvaluacionDAO en una EvaluacionDTO
        /// </summary>
        /// <param name="evaluacion">
        ///     Recibe una Evaluacion del tipo EvaluacionDAO
        /// </param>
        /// <returns>
        ///     Devuelve una evaluacion del tipo EvaluacionDTO 
        /// </returns>
        public static EvaluacionDTO EvaluacionDAOtoDTO(Evaluacion evaluacion)
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método estático EvaluacionDAOToDTO de la clase ToDTO");

            EvaluacionDTO evaluacionDTO = new EvaluacionDTO();
            evaluacionDTO.CodEvaluacion = evaluacion.codEvaluacion;
            evaluacionDTO.DescripcionEval = evaluacion.descripcionEval;

            List<NotaDTO> notasDTO = new List<NotaDTO>();
            foreach(Nota notaDao in evaluacion.listaNotas) 
            {
                notasDTO.Add(NotaDAOtoDTO(notaDao));
            }

            evaluacionDTO.Notas = notasDTO;

            Console.WriteLine("\t\t--[INFO]-- Saliendo del método estático EvaluacionDAOToDTO de la clase ToDTO");

            return evaluacionDTO;
        }
    }
}
