using AppVenta.Dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Applicaciones.Interfaces
{
    public interface IServicioMovimiento<TEntidad, TentidadID>
        :IAgregar<TEntidad>, IListar<TEntidad, TentidadID>
    {
        void Anular(int ventaId);
    }
}
