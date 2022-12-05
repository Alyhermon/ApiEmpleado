using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string fechaNacimiento { get; set; }

        public string Cargo { get; set; }

        public string Departamento { get; set; }

        public string HorarioTrabajo { get; set; }

        public string Telefono { get; set; }
        public string correo { get; set; }
    }
}