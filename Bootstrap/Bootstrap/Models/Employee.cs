using System;
using System.ComponentModel.DataAnnotations;

namespace Bootstrap.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Apellido Paterno es requerido")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage ="Apellido Materno es requerido")]
        public string ApellidoMaterno { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int Test { get; set; }
    }
}