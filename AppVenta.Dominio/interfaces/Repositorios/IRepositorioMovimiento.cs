using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importar las interfaves
using AppVenta.Dominio.interfaces;



namespace AppVenta.Dominio.interfaces.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad,TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID entidadId);
    }
}
