using ControlCatedratico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCatedratico.Repository.iRepository
{
    interface iReporteRepository
    {
        ICollection<CatedraticoModel> GetCatedraticoModels();
        CatedraticoModel GetCatedraticoModels(int CodigoCatedratico);//obtener segun codigo envio
        CatedraticoModel GetEstadoCatedratico(string Estadocatedratico);

       
        bool GuardarCatedratico();

    }
}
