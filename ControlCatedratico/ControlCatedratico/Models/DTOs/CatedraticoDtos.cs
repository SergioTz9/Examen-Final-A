using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ControlCatedratico.Models.DTOs
{
    public class CatedraticoDtos
    {


        [Display(Name = "Nombre Catedratico")]
        public String NombreCatedratico { get; set; }


   
        [Display(Name = "Genero Catedratico")]
        public String Genero { get; set; }


      
        [Display(Name = "Estado Civil")]
        public String EstadoCivil { get; set; }

        [Display(Name = "Telefono Catedratico")]
        public String TelCatedratico { get; set; }

     
        [Display(Name = "Correo Catedratico")]
        public String CorreoCatedratico { get; set; }

    
        [Display(Name = "No DPI ")]
        public int NoDpi { get; set; }

        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

       
    }
}
