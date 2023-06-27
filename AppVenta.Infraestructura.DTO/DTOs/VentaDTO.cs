using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.DTO.DTOs
{
    public class VentaDTO
    {
        public int ventaId { get; set; }

        public long numeroVenta { get; set; }

        public DateTime fecha { get; set; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public string concepto { get; set; }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        public decimal subtotal1 { get; set; }

        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        public bool anulado { get; set; }
    }
}
