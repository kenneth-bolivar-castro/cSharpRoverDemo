using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosRepuestos
    {
        List<v_repuestosPorTipoDeModelo> buscaRepuestosSegunCriterios(string Nombre, int IdCategoria,
            int IdTipoModelo, int IdCombustible, bool EsUsado);
        List<v_repuestosPorTipoDeModelo> tomaNRepuestosSegunIdTipoModelo(int IdTipoModelo, int tomarN);
        IQueryable<dynamic> obtenLasDiferentesCategoriasSegunIdTipoModelo(int IdTipoModelo);
        List<Repuestos> obtenerTodos();
    }

    public class AccionesRepuestos : IServiciosRepuestos
    {
        private RoverDataContext contexto;

        public AccionesRepuestos()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesRepuestos(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public List<v_repuestosPorTipoDeModelo> buscaRepuestosSegunCriterios(string Nombre, int IdCategoria, int IdTipoModelo, int IdCombustible, bool EsUsado)
        {
            var repuestos = from vista in contexto.v_repuestosPorTipoDeModelo
                            where
                            vista.IdTipoModelo == IdTipoModelo &&
                            vista.Nombre.Contains(Nombre) &&
                            vista.EsUsado == EsUsado &&
                            vista.IdCombustible == IdCombustible
                            select vista;
            if (IdCategoria != 0)
            {
                repuestos = from vista in contexto.v_repuestosPorTipoDeModelo
                            where
                            vista.IdTipoModelo == IdTipoModelo &&
                            vista.Nombre.Contains(Nombre) &&
                            vista.EsUsado == EsUsado &&
                            vista.IdCombustible == IdCombustible &&
                            vista.IdCategoria == IdCategoria
                            select vista;
            }
            return repuestos.ToList();
        }

        public List<v_repuestosPorTipoDeModelo> tomaNRepuestosSegunIdTipoModelo(int IdTipoModelo, int tomarN)
        {
            return this.contexto.v_repuestosPorTipoDeModelo
                .Where(v => v.IdTipoModelo == IdTipoModelo).OrderByDescending(v => v.IdRepuesto)
                    .Take(tomarN).ToList();
        } 

        public IQueryable<dynamic> obtenLasDiferentesCategoriasSegunIdTipoModelo(int IdTipoModelo)
        {
            return (from vista in this.contexto.v_repuestosPorTipoDeModelo
                    where vista.IdTipoModelo == IdTipoModelo
                    orderby vista.IdRepuesto descending
                    select new
                    {
                        vista.IdCategoria,
                        vista.Categoria
                    }).Distinct();
        }

        public List<Repuestos> obtenerTodos()
        {
            return this.contexto.Repuestos.ToList();
        }
    }
}
