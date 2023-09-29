using ExamenServiciosWebCL1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamenServiciosWebCL1.Database.ExamenContext;

namespace ExamenServiciosWebCL1.Controllers
{
    public class HomeController : Controller
    {

        private readonly ExamenContext _context;

        public HomeController(ExamenContext context)
        {
            _context = context;
        }

        // Lista de Alumnos
        public IActionResult Index()
        {
            var alumnos = _context.Alumnos.ToList();
            return View(alumnos);
        }


        // Crear Nuevo(s) Alumno(s)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno model)
        {
            if (ModelState.IsValid)
            {
                var alumno = new Alumno
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    DNI = model.DNI,
                    FechaNacimiento = model.FechaNacimiento,
                    CorreoElectronico = model.CorreoElectronico,
                    Celular = model.Celular,
                    NombreContactoEmergencia = model.NombreContactoEmergencia,
                    TelefonoContactoEmergencia = model.TelefonoContactoEmergencia
                };

                _context.Alumnos.Add(alumno);
                _context.SaveChanges();

                return RedirectToAction("Index"); 
            }

         
            return View(model);
        }


        // Editar Datos de Alumno(s)
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var alumno = _context.Alumnos.FirstOrDefault(a => a.Id == id);

            if (alumno == null)
            {
                return NotFound(); 
            }

            return View(alumno);
        }
        [HttpPost]
        public IActionResult Edit(Alumno model)
        {
            if (ModelState.IsValid)
            {
                var alumno = _context.Alumnos.FirstOrDefault(a => a.Id == model.Id);

                if (alumno == null)
                {
                    return NotFound();
                }

                // Actualiza todas las propiedades del modelo Alumno
                alumno.Nombre = model.Nombre;
                alumno.Apellido = model.Apellido;
                alumno.DNI = model.DNI;
                alumno.FechaNacimiento = model.FechaNacimiento;
                alumno.CorreoElectronico = model.CorreoElectronico;
                alumno.Celular = model.Celular;
                alumno.NombreContactoEmergencia = model.NombreContactoEmergencia;
                alumno.TelefonoContactoEmergencia = model.TelefonoContactoEmergencia;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // Borrar Alumnos
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var alumno = _context.Alumnos.FirstOrDefault(a => a.Id == id);

            if (alumno == null)
            {
                return NotFound(); 
            }

            return View(alumno);
        }

        [HttpPost]
        public IActionResult ConfirmedDelete(int id)
        {
           
            var alumno = _context.Alumnos.FirstOrDefault(a => a.Id == id);

            if (alumno == null)
            {
                return NotFound();
            }

            
            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }



        // Otros
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
