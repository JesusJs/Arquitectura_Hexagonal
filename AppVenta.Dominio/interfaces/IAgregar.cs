﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.interfaces
{
    public interface IAgregar<TEntidad>
    {
        TEntidad Agregar(TEntidad nuevaVenta);
    }
}
