using Modelo;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Controladora
{
    public class ControladoraOrigen
    {
        private static ControladoraOrigen instancia;

        private ControladoraOrigen() { }

        public static ControladoraOrigen Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraOrigen();
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<Origen> RecuperarOrigenes()
        {
            try
            {
                return RepositorioOrigen.Instancia.RecuperarOrigenes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarOrigen(Origen origen)
        {
            try
            {
                var listaOrigenes = RepositorioOrigen.Instancia.RecuperarOrigenes();
                var origenEncontrado = listaOrigenes.FirstOrDefault(x => x.NombreHistoria == origen.NombreHistoria);
                if (origenEncontrado == null)
                {
                    var ok = RepositorioOrigen.Instancia.Agregar(origen);
                    if (ok)
                    {
                        return $"{origen.NombreHistoria} se agregó correctamente";
                    }
                    else
                    {
                        return $"{origen.NombreHistoria} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"{origen.NombreHistoria} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarOrigen(Origen origen)
        {
            try
            {
                var listaOrigenes = RepositorioOrigen.Instancia.RecuperarOrigenes();
                var origenEncontrado = listaOrigenes.FirstOrDefault(x => x.NombreHistoria == origen.NombreHistoria);
                if (origenEncontrado != null)
                {
                    var ok = RepositorioOrigen.Instancia.Modificar(origen);
                    if (ok)
                    {
                        return $"{origen.NombreHistoria} se modificó correctamente";
                    }
                    else
                    {
                        return $"{origen.NombreHistoria} no se ha podido modificar";
                    }
                }
                else
                {
                    return $"{origen.NombreHistoria} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarOrigen(Origen origen)
        {
            try
            {
                var listaOrigenes = RepositorioOrigen.Instancia.RecuperarOrigenes();
                var origenEncontrado = listaOrigenes.FirstOrDefault(x => x.NombreHistoria.ToLower() == origen.NombreHistoria.ToLower());

                if (origenEncontrado != null)
                {
                    var ok = RepositorioOrigen.Instancia.Eliminar(origen);
                    if (ok)
                    {
                        return $"{origen.NombreHistoria} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"{origen.NombreHistoria} no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"{origen.NombreHistoria} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido.";
            }
        }
    }
}
