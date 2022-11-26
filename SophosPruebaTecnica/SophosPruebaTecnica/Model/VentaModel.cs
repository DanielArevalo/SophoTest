using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Model
{
    public class VentaModel
    {
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

    public class VentasQueryModel
    {
        public int Id { get; set; }

        public string Nombre_Cliente { get; set; }

        public string Nombre_Producto { get; set; }

        public int Valor_Unitario { get; set; }

        public int Valor_Total { get; set; }
    }
}
