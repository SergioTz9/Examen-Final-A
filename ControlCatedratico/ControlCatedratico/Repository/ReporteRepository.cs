using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlCatedratico.Models;
using ControlCatedratico.Connection;
using ControlCatedratico.Repository.iRepository;

namespace ControlCatedratico.Repository
{
    public class ReporteRepository: iReporteRepository
    {
        private readonly Conn _db;

        public ReporteRepository(Conn db)//metodo contructor inicializa obj de la cxlase
        {
            _db = db;
        }

        public ICollection<CatedraticoModel> GetCatedraticoModels()
        {
            return _db.tbl_RegistroCatedratico.OrderBy(p => p.NombreCatedratico).ToList();
        }

        public CatedraticoModel GetCatedraticoModels(int CodigoCatedratico)
        {
            throw new NotImplementedException();
        }

        public CatedraticoModel GetEstadoCatedratico(string Estadocatedratico)
        {
            return _db.tbl_RegistroCatedratico.FirstOrDefault(p => p.EstadoCatedratico == Estadocatedratico);
        }

        public bool GuardarCatedratico()
        {
            throw new NotImplementedException();
        }
    }
}