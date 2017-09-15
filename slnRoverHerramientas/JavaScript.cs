using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace slnRoverHerramientas
{
    public class JavaScript
    {
        private const string _codigo_mensaje_emergente = "<script type='text/javascript'>alert('{0}');</script>";

        private static readonly JavaScript _instancia = new JavaScript();

        private JavaScript()
        {
        }

        public static JavaScript Instancia
        {
            get
            {
                return JavaScript._instancia;
            }
        }

        public string codigoMensajeEmergente()
        {
            return _codigo_mensaje_emergente;
        }

    }
}
