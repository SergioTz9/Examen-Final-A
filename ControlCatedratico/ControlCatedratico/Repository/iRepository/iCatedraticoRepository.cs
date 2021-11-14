using ControlCatedratico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCatedratico.Repository.iRepository
{
    public interface iCatedraticoRepository
    {
        ICollection<CatedraticoModel> GetCatedraticoModels();
        CatedraticoModel GetCatedraticoModels(int CodigoCatedratico);

        bool CrearCatedratico(CatedraticoModel catedratico);
        bool ActualizarCatedratico(CatedraticoModel catedratico);

        bool BorrarCatedratico(CatedraticoModel catedratico);

        bool GuardarCatedratico();
    }
}
