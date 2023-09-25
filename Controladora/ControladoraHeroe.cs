using Modelo;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Controladora
{
    public class ControladoraHeroe
    {
        private static ControladoraHeroe instancia;

        private ControladoraHeroe() { }

        public static ControladoraHeroe Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraHeroe();
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<Heroe> RecuperarHeroes()
        {
            try
            {
                return RepositorioHeroe.Instancia.RecuperarHeroes();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool OrigenAsociadoOtroHeroe(Origen origen, string nombreHeroe = null)
        {
            var heroes = RecuperarHeroes().Where(h => h.Nombre != nombreHeroe).ToList();

            var booleano = heroes.Any(x => x.Origen.NombreHistoria == origen.NombreHistoria);

            return booleano;
        }

        public string AgregarHeroe(Heroe heroe)
        {
            try
            {
                var listaHeroes = RepositorioHeroe.Instancia.RecuperarHeroes();
                var heroeEncontrado = listaHeroes.FirstOrDefault(x => x.Nombre == heroe.Nombre);
                if (heroeEncontrado == null)
                {
                    var ok = RepositorioHeroe.Instancia.Agregar(heroe);
                    if (ok)
                    {
                        return $"{heroe.Nombre} se agregó correctamente";
                    }
                    else
                    {
                        return $"{heroe.Nombre} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"{heroe.Nombre} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarHeroe(Heroe heroe)
        {
            try
            {
                var listaHeroes = RepositorioHeroe.Instancia.RecuperarHeroes();
                var heroeEncontrado = listaHeroes.FirstOrDefault(x => x.Nombre == heroe.Nombre);
                if (heroeEncontrado != null)
                {
                    var ok = RepositorioHeroe.Instancia.Modificar(heroe);
                    if (ok)
                    {
                        return $"{heroe.Nombre} se modificó correctamente";
                    }
                    else
                    {
                        return $"{heroe.Nombre} no se ha podido modificar";
                    }
                }
                else
                {
                    return $"{heroe.Nombre} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarHeroe(Heroe heroe)
        {
            try
            {
                var listaHeroes = RepositorioHeroe.Instancia.RecuperarHeroes();
                var heroeEncontrado = listaHeroes.FirstOrDefault(x => x.Nombre.ToLower() == heroe.Nombre.ToLower());

                if (heroeEncontrado != null)
                {
                    var ok = RepositorioHeroe.Instancia.Eliminar(heroe);
                    if (ok)
                    {
                        return $"{heroeEncontrado.Nombre} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"{heroeEncontrado.Nombre} no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"{heroe.Nombre} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido.";
            }
        }
    }
}
