using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlCatedratico.Connection;
using ControlCatedratico.Models;
using ControlCatedratico.Repository.iRepository;

namespace ControlCatedratico.Repository
{
    public class CatedraticoRepository : iCatedraticoRepository
    {
        private readonly Conn _db;

        public CatedraticoRepository(Conn db)//metodo contructor inicializa obj de la cxlase
        {
            _db = db;
        }

        public bool ActualizarCatedratico(CatedraticoModel catedratico)
        {
            _db.tbl_RegistroCatedratico.Update(catedratico);
            return GuardarCatedratico();
        }

        public bool BorrarCatedratico(CatedraticoModel catedratico)
        {
            _db.tbl_RegistroCatedratico.Remove(catedratico);
            return GuardarCatedratico();
        }

        public bool CrearCatedratico(CatedraticoModel catedratico)
        {
            _db.tbl_RegistroCatedratico.Add(catedratico);
            return GuardarCatedratico();
        }

        public ICollection<CatedraticoModel> GetCatedraticoModels( )
        {
            return _db.tbl_RegistroCatedratico.OrderBy(p => p.NombreCatedratico).ToList();
        }

        public CatedraticoModel GetCatedraticoModels(int CodigoCatedratico)
        {
            return _db.tbl_RegistroCatedratico.FirstOrDefault(p => p.CodigoCatedratico == CodigoCatedratico);
        }

        public bool GuardarCatedratico()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}