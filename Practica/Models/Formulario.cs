using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Practica.Models
{
    public class Formulario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido paterno es requerido")]
        [Display(Name = "Apellido Paterno")]
        public string apellidoP { get; set; }

        [Required(ErrorMessage = "El campo apellido materno es requerido")]
        [Display(Name = "Apellido Materno")]
        public string apellidoM { get; set; }

        [Required(ErrorMessage = "El campo usuario es requerido")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "El campo contraseña es requerido")]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }

        [Required(ErrorMessage = "El campo telefono es requerido")]
        [Display(Name = "Telefono")]
        public int telefono { get; set; }

        [Required(ErrorMessage = "El campo dirección es requerido")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
    

        





       
        
    }
}
