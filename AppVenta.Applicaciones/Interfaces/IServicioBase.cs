using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importamos las interfaces de dominio
using AppVenta.Dominio.interfaces;

namespace AppVenta.Applicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID>
    : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad,TEntidadID> {

    }
}
