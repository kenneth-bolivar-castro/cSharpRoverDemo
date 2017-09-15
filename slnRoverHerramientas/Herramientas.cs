using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace slnRoverHerramientas
{
    public class Herramientas
    {
        private int maximoPorPagina;
        private Configuraciones configuracion;

        public Herramientas()
        {
            configuracion = Configuraciones.Instancia;
            maximoPorPagina = configuracion.MaximoPorPagina;
        }

        public long obtenCantidadDeEnlaces(long CantidadDeElementos)
        {
            long residuo = 0;
            long cantidad = Math.DivRem(CantidadDeElementos, maximoPorPagina, out residuo);
            if (residuo > 0)
            {
                cantidad += 1;
            }
            return cantidad;
        }

        public void obtenPaginasDesdeHasta(long pagina, out long paginaDesde, out long paginaHasta)
        {
            paginaHasta = (pagina * maximoPorPagina) + maximoPorPagina;
            paginaDesde = (paginaHasta - maximoPorPagina) + 1;
        }

        public static Exception Excepcion { get; set; }
    }
}
