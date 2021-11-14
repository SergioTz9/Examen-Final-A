using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlCatedratico.Models.DTOs
{
    public class CatedraticoSaveDtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Display(Name = "Código Catedratico")]
        public int CodigoCatedratico { get; set; }
        public string NombreCatedratico{ get; set; }
               
        public String Genero { get; set; }
               
        public String EstadoCivil { get; set; }
              
        public String TelCatedratico { get; set; }
               
        public String CorreoCatedratico { get; set; }
            
        public int NoDpi { get; set; }
             
        public DateTime FechaIngreso { get; set; }

       }
}

