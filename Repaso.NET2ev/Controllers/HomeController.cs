using DAL;
using DAL.Entidades.DAO;
using DAL.Entidades.DTO;
using DAL.Entidades.ToDTO;
using Microsoft.AspNetCore.Mvc;
using Repaso.NET2ev.Models;
using Repaso.NET2ev.Servicios;
using System.Diagnostics;

namespace Repaso.NET2ev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _contexto;
        private readonly ConsultasService _evaluacionService;


        public HomeController(ILogger<HomeController> logger, Contexto contexto, ConsultasService evaluacionService)
        {
            _logger = logger;
            _contexto = contexto;
            _evaluacionService = evaluacionService;
        }

        public IActionResult Index()
        {
            try
            {

                EvaluacionDTO evaluacion1 = new EvaluacionDTO("PR", "Primera Evaluación");
                EvaluacionDTO evaluacion2 = new EvaluacionDTO("SG", "Segunda Evaluación");
                EvaluacionDTO evaluacion3 = new EvaluacionDTO("TC", "Tercera Evaluación");

                NotaDTO nota1 = new NotaDTO("Alumno1", 6, evaluacion1.CodEvaluacion);
                NotaDTO nota2 = new NotaDTO("Alumno1", 7, evaluacion1.CodEvaluacion);
                NotaDTO nota3 = new NotaDTO("Alumno1", 8, evaluacion1.CodEvaluacion);

                evaluacion1.Notas.Add(nota1);
                evaluacion1.Notas.Add(nota2);
                evaluacion1.Notas.Add(nota3);

                ////INSERT
                //_evaluacionService.insertarEvaluacion(evaluacion1);
                //_evaluacionService.insertarEvaluacion(evaluacion2);
                //_evaluacionService.insertarEvaluacion(evaluacion3);

                //DELETE
                //_evaluacionService.eliminarEvaluacion(evaluacion1.CodEvaluacion);

                //UPDATE
                //evaluacion1.DescripcionEval = "UPDATE";
                //_evaluacionService.actualizarEvaluacion(evaluacion1);

                //SELECT ALL
                //List<EvaluacionDTO> evaluaciones = _evaluacionService.buscarTodasLasEvaluaciones();
                //foreach (EvaluacionDTO evaluacion in evaluaciones)
                //{
                //    evaluacion.mostrarDatosEvaluacion();
                //    evaluacion.Notas.ForEach(nota => nota.mostrarDatosNota());
                //}

                //SELECT BY ID
                //EvaluacionDTO evaluacion = _evaluacionService.buscarEvaluacionPorId(evaluacion1.CodEvaluacion);
                //evaluacion.mostrarDatosEvaluacion();
                //evaluacion.Notas.ForEach(nota => nota.mostrarNota());

                //SELECT BY EVALUACION
                //List<NotaDTO> notas = _evaluacionService.buscarRegistrosPorEvaluacion(evaluacion1.CodEvaluacion);
                //foreach (NotaDTO nota in notas)
                //{
                //    nota.mostrarDatosNota();
                //}

                //SELECT BY ALUMNO
                List<NotaDTO> notas = _evaluacionService.buscarRegistrosPorAlumno("Alumno1");
                foreach (NotaDTO nota in notas)
                {
                    nota.mostrarDatosNota();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
