using DAL;
using DAL.Entidades.DAO;
using DAL.Entidades.DTO;
using DAL.Entidades.ToDTO;
using DAL.models.ToDAO;
using Microsoft.EntityFrameworkCore;

namespace Repaso.NET2ev.Servicios
{
    /// <summary>
    /// Implementación de la interfaz <see cref="ConsultasService"/> que proporciona servicios CRUD relacionados con las evaluaciones y las notas
    /// </summary>
    public class EvaluacionServiceImpl : ConsultasService
    {
        private readonly Contexto _context; //Inyección de dependencia del contexto para persitencia

        public EvaluacionServiceImpl(Contexto context)
        {
            _context = context;
        }

        /// <summary>
        ///     Metodo para modificar una evaluación ya registrada anteriormente
        /// </summary>
        /// <param name="evaluacionDto">
        ///     Evaluación de tipo <see cref="EvaluacionDTO"/> para ser convertida a <see cref="Evaluacion"/> y persistida
        /// </param>
        public void actualizarEvaluacion(EvaluacionDTO evaluacionDto)
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método actualizarEvaluacion de EvaluaciónServiceImpl");

            Evaluacion evaluacion = ToDAO.EvaluacionDTOToDao(evaluacionDto);
            _context.Evaluaciones.Update(evaluacion);
            _context.SaveChanges();

            Console.WriteLine("\t\t--[INFO]-- Saliendo del método actualizarEvaluacion de EvaluaciónServiceImpl");
        }

        /// <summary>
        ///     Metodo para buscar una evaluación por su identificador y ser convertida a <see cref="EvaluacionDTO"/>
        /// </summary>
        /// <param name="codEvaluacion">
        ///     Identificador de la evaluación a buscar 
        /// </param>
        /// <returns>
        ///     Evaluación de tipo <see cref="EvaluacionDTO"/>
        /// </returns>
        /// <exception cref="Exception">
        ///     Si el identificador dado no existe para ninguna evaluación, se lanza una excepción.
        /// </exception>
        public EvaluacionDTO buscarEvaluacionPorId(string codEvaluacion)
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método buscarEvaluacionPorId de EvaluaciónServiceImpl");

            if (codEvaluacion != null && codEvaluacion != String.Empty)
            {
                Evaluacion? evaluacion = _context.Evaluaciones
                    .Include(e => e.listaNotas)  // Carga de listaNotas correspondientes a dicha evaluación
                    .FirstOrDefault(e => e.codEvaluacion == codEvaluacion);
                if (evaluacion != null)
                {
                    return ToDTO.EvaluacionDAOtoDTO(evaluacion);
                }
            }
            else
            {
                throw new Exception("El id " + codEvaluacion + " introducido para buscar la evaluación no es válido");

            }
            Console.WriteLine("\t\t--[INFO]-- Saliendo del método buscarEvaluacionPorId de EvaluaciónServiceImpl");
            return null;
        }


        /// <summary>
        ///     Metodo para buscar todas evaluación registradas y ser convertida a <see cref="EvaluacionDTO"/>
        /// </summary>
        /// <exception cref="Exception">
        ///     Si la evaluación no se encuentra, se lanza una excepción.
        /// </exception>
        public List<EvaluacionDTO> buscarTodasLasEvaluaciones()
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método buscarTodasLasEvaluacion de EvaluaciónServiceImpl");

            List<EvaluacionDTO> evaluacionesDTO = new List<EvaluacionDTO>();
            List<Evaluacion> evaluaciones = _context.Evaluaciones.Include(e => e.listaNotas).ToList(); //Carga de evals con notas

            if (evaluaciones != null)
            {
                foreach (Evaluacion evaluacion in evaluaciones)
                {
                    evaluacionesDTO.Add(ToDTO.EvaluacionDAOtoDTO(evaluacion));
                }
                Console.WriteLine("\t\t--[INFO]-- Saliendo del método buscarTodasLasEvaluaciones de EvaluaciónServiceImpl");
                return evaluacionesDTO;
            }
            else
            {
                throw new Exception("No existen evaluaciones registradas");
            }

        }

        /// <summary>
        ///     Metodo para registrar una nueva evaluación tras ser convertida a DAO una <see cref="Evaluacion"/>
        /// </summary>
        /// <param name="evaluacionDto">
        ///    La nueva Evaluación a registrar 
        /// </param>
        public void insertarEvaluacion(EvaluacionDTO evaluacionDto)
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método insertarEvaluacion de EvaluaciónServiceImpl");

            _context.Evaluaciones.Add(ToDAO.EvaluacionDTOToDao(evaluacionDto));
            _context.SaveChanges();

            Console.WriteLine("\t\t--[INFO]-- Saliendo del método insertarEvaluacion de EvaluaciónServiceImpl");

        }

        /// <summary>
        ///    Metodo para eliminar una evaluación antes registrada
        /// </summary>
        /// <param name="codEvaluacion">
        ///    El identificador de la Evaluación a eliminar
        /// </param>
        /// <exception cref="Exception">
        ///     Si la evaluación no existe, se lanza una excepción
        /// </exception>
        public void eliminarEvaluacion(string codEvaluacion)
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método eliminarEvaluacion de EvaluaciónServiceImpl");

            Evaluacion? evalEliminar = _context.Evaluaciones.Find(codEvaluacion);
            if (evalEliminar == null)
            {
                throw new Exception("Evaluación " + codEvaluacion + " no encontrada");
            }
            _context.Evaluaciones.Remove(evalEliminar);
            _context.SaveChanges();

            Console.WriteLine("\t\t--[INFO]-- Saliendo del método eliminarEvaluacion de EvaluaciónServiceImpl");

        }

        /// <summary>
        ///     Consulta registros específicos de una evaluación
        /// </summary>
        /// <param name="codEvaluacion">
        ///     Identificador de la evaluación a buscar todas sus notas
        /// </param>
        /// <returns>
        ///     Se convierte a DTO y se devuelve una lista de notas <see cref="NotaDTO"/>
        /// </returns>
        /// <exception cref="Exception">
        ///     Si la evaluación no existe, se lanza una excepción
        /// </exception>
        public List<NotaDTO> buscarRegistrosPorEvaluacion(string codEvaluacion)
        {

            Console.WriteLine("\t\t--[INFO]-- Accediendo al método buscarRegistrosPorEvaluacion de EvaluaciónServiceImpl");
            List<NotaDTO> notasDTO = new List<NotaDTO>();
            List<Nota> notas = _context.Notas
                .Where(n => n.codEvaluacion == codEvaluacion)
                .ToList();
            if (notas != null)
            {
                foreach (Nota nota in notas)
                {
                    notasDTO.Add(ToDTO.NotaDAOtoDTO(nota));
                }
                Console.WriteLine("\t\t--[INFO]-- Saliendo del método buscarRegistrosPorEvaluacion de EvaluaciónServiceImpl");
                return notasDTO;
            }
            else
            {
                throw new Exception("No existen registros de evaluación " + codEvaluacion + " registrados");
            }
        }
        /// <summary>
        ///     Consulta registros de notas específicos de un alumno de una evaluación y los convierte a DTO <see cref="NotaDTO"/>
        /// </summary>
        /// <param name="codAlumno"> 
        ///     El identificador del alumno que se quieren buscar sus notas
        /// </param>
        /// <returns>
        ///     Lista de notas del alumno <see cref="NotaDTO"/>
        /// </returns>
        /// <exception cref="Exception">
        ///     Si el id del alumno no existe, se lanza una excepción
        /// </exception>
        public List<NotaDTO> buscarRegistrosPorAlumno(string codAlumno) 
        {
            Console.WriteLine("\t\t--[INFO]-- Accediendo al método buscarRegistroPorAlumno de EvaluaciónServiceImpl");
            List<NotaDTO> notasDTO = new List<NotaDTO>();
            List<Nota> notas = _context.Notas
                .Where(n => n.codAlumno == codAlumno)
                .ToList();
            if (notas != null)
            {
                foreach (Nota nota in notas)
                {
                    notasDTO.Add(ToDTO.NotaDAOtoDTO(nota));
                }
                Console.WriteLine("\t\t--[INFO]-- Saliendo del método buscarRegistroPorAlumno de EvaluaciónServiceImpl");
                return notasDTO;
            }
            else
            {
                throw new Exception("No existen registros de evaluación " + codAlumno + " registrados");
            }

        }
    }

}
