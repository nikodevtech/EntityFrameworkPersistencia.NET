using DAL.Entidades.DAO;
using DAL.Entidades.DTO;

namespace Repaso.NET2ev.Servicios
{
    /// <summary>
    /// Interfaz que declara los servicios relacionados con las evaluaciones y las notas. 
    /// Proporciona métodos para realizar el CRUD y consultas específicas.
    /// </summary>
    public interface ConsultasService
    {
        /// <summary>
        ///     Registra una nueva evaluacion.
        /// </summary>
        /// <param name="evaluacion">
        ///     La evaluación a insertar
        /// </param>
        public void insertarEvaluacion(EvaluacionDTO evaluacionDto);

        /// <summary>
        ///     Recupera todas las evaluaciones registradas en el sistema
        /// </summary>
        /// <returns>
        ///     Una lista de todas las evaluaciones
        /// </returns>
        /// <exception cref="Exception">
        ///     Si la evaluación no existe, se lanza una excepción
        /// </exception>
        public List<EvaluacionDTO> buscarTodasLasEvaluaciones();

        /// <summary>
        ///     Busca una evaluación por su identificador
        /// </summary>
        /// <param name="codEvaluacion">
        ///     El codigo de la evaluación que es su identificador
        /// </param>
        /// <returns>
        ///     La evaluación que se buscaba
        /// </returns>
        /// <exception cref="Exception">
        ///     Si el identificador de la evaluación no existe, se lanza una excepción
        /// </exception>
        public EvaluacionDTO buscarEvaluacionPorId(string codEvaluacion);

        /// <summary>
        ///     Modifica una evaluación previamente persistida en el sistema
        /// </summary>
        /// <param name="evaluacion">
        ///     La evaluacion modificada para ser persistida
        /// </param>
        public void actualizarEvaluacion(EvaluacionDTO evaluacionDto);

        /// <summary>
        ///     Elimina una evaluación previamente persistida en el sistema
        /// </summary>
        /// <param name="codEvaluacion">
        ///     Identificador de la evaluacion que se va a eliminar
        /// </param>
        /// <exception cref="Exception">
        ///     Si la evaluación no existe, se lanza una excepción
        /// </exception>
        public void eliminarEvaluacion(string codEvaluacion);
        /// <summary>
        ///     Consulta registros específicos de una evaluación
        /// </summary>
        /// <param name="codEvaluacion">
        ///     Identificador de la evaluación a buscar todas sus notas
        /// </param>
        /// <returns>
        ///     Lista de notas <see cref="NotaDTO"/>
        /// </returns>
        /// <exception cref="Exception">
        ///     Si el id de la evaluación no existe, se lanza una excepción
        /// </exception>
        public List<NotaDTO> buscarRegistrosPorEvaluacion(string codEvaluacion);

        /// <summary>
        ///     Consulta registros específicos de un alumno de una evaluación
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
        public List<NotaDTO> buscarRegistrosPorAlumno(string codAlumno);


    }
}
