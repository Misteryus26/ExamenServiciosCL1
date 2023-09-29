using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenServiciosWebCL1.Models
{
    public class Alumno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo DNI es obligatorio.")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Correo Electrónico debe ser una dirección de correo válida.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El campo Celular es obligatorio.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Contacto (Emergencia) es obligatorio.")]
        public string NombreContactoEmergencia { get; set; }

        [Required(ErrorMessage = "El campo Teléfono de Contacto (Emergencia) es obligatorio.")]
        public string TelefonoContactoEmergencia { get; set; }
    }
}