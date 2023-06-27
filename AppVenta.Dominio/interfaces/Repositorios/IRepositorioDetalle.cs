using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importamos las Interfaces
using AppVenta.Dominio.interfaces;

namespace AppVenta.Dominio.interfaces.Repositorios
{
    public interface IRepositorioDetalle<TEntidad, TMovimientoID>
    : IAgregar<TEntidad>, ITransaccion
    {
    }
}
