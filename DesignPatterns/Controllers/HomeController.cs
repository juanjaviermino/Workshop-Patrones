using DesignPatterns.Factories;
using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;
using DesignPatterns.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// Espacio de nombres para los controladores en la aplicación.
namespace DesignPatterns.Controllers
{
    // Controlador HomeController que hereda de Controller.
    public class HomeController : Controller
    {
        // Inyección de dependencias para ILogger y IVehicleRepository.
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleRepository _vehicleRepository;

        // Constructor que recibe las dependencias.
        public HomeController(IVehicleRepository vehicleRepository, ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        // Acción Index que se llama al cargar la página principal.
        public IActionResult Index()
        {
            // Creación del modelo de vista.
            var model = new HomeViewModel();
            // Obtención de vehículos desde el repositorio y asignación al modelo.
            model.Vehicles = _vehicleRepository.GetVehicles();
            // Manejo de mensajes de error pasados en la consulta.
            string error = Request.Query.ContainsKey("error") ? Request.Query["error"].ToString() : null;
            ViewBag.ErrorMessage = error;

            // Retorno de la vista con el modelo.
            return View(model);
        }

        // Método privado para crear un vehículo utilizando el Factory Method.
        private void CreateVehicle(Creator creator)
        {
            _vehicleRepository.AddVehicle(creator.Create());
        }

        // Acción para añadir un Mustang a través de una solicitud HTTP GET.
        [HttpGet]
        public IActionResult AddMustang()
        {
            var creator = new FordMustangCreator();
            CreateVehicle(creator);
            return Redirect("/");
        }

        // Acción para añadir un Explorer a través de una solicitud HTTP GET.
        [HttpGet]
        public IActionResult AddExplorer()
        {
            var creator = new FordExplorerCreator();
            CreateVehicle(creator);
            return Redirect("/");
        }

        // Acción para añadir un Escape a través de una solicitud HTTP GET.
        [HttpGet]
        public IActionResult AddEscape()
        {
            var creator = new FordEscapeCreator();
            CreateVehicle(creator);
            return Redirect("/");
        }

        // Acción para arrancar el motor de un vehículo a través de una solicitud HTTP GET.
        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StartEngine();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y redirección con mensaje de error.
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para añadir gasolina a un vehículo a través de una solicitud HTTP GET.
        [HttpGet]
        public IActionResult AddGas(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.AddGas();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y redirección con mensaje de error.
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para detener el motor de un vehículo a través de una solicitud HTTP GET.
        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StopEngine();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y redirección con mensaje de error.
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción que devuelve la vista de privacidad.
        public IActionResult Privacy()
        {
            return View();
        }

        // Acción para manejar errores con una caché específica.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Retorna la vista de error con un modelo que incluye el ID de la solicitud.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
