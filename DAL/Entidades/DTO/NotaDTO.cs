using DAL.Entidades.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades.DTO
{
    /// <summary>
    ///     Clase Nota DTO con los datos de la nota
    /// </summary>
    public class NotaDTO
    {
        // ATRIBUTOS
        string codAlumno;
        int notaEvaluacion;
        string codEvaluacion;
        string descripcionEvaluacion;

        // CONSTRUCTORES
        public NotaDTO(string cod_alumno, int nota_evaluacion, string cod_evaluacion)
        {
            codAlumno = cod_alumno;
            notaEvaluacion = nota_evaluacion;
            codEvaluacion = cod_evaluacion;
        }
        public NotaDTO(string cod_alumno, int nota_evaluacion, string cod_evaluacion, string descripcionEval)
        {
            codAlumno = cod_alumno;
            notaEvaluacion = nota_evaluacion;
            codEvaluacion = cod_evaluacion;
            DescripcionEvaluacion = descripcionEval;
        }
        public NotaDTO()
        {
        }

        // GETTERS Y SETTERS
        public string Cod_alumno1 { get => codAlumno; set => codAlumno = value; }
        public int Nota_evaluacion1 { get => notaEvaluacion; set => notaEvaluacion = value; }
        public string Cod_evaluacion1 { get => codEvaluacion; set => codEvaluacion = value; }
        public string DescripcionEvaluacion { get => descripcionEvaluacion; set => descripcionEvaluacion = value; }

        //METODOS

        /// <summary>
        ///     Muestra la información de la nota
        /// </summary>
        public void mostrarDatosNota()
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método mostrarDatosNota de NotaDTO");
            Console.WriteLine("\n\t*** Datos de la Nota ***\n\tCódigo de Alumno: {0}\n\tNota Evaluación: {1}\n\tDescripción Evaluación: {2}", this.codAlumno, this.notaEvaluacion,this.DescripcionEvaluacion);
            Console.WriteLine("\t\t--[INFO]-- Saliendo del método mostrarDatosNota de NotaDTO");

        }

    }
}
