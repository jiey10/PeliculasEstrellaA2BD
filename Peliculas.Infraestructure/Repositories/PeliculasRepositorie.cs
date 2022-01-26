using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peliculas.Domain.Entities;

namespace Peliculas.Infraestructure.Repositories
{
    public class PeliculasRepositorie
    {
        public static List<Pelicula> _peliculas = new List<Pelicula>();

        public IEnumerable<Pelicula> ObtenerTodas()
        {
            return _peliculas;
        }

        
        public Pelicula ObtenerPorId(int id)
        {
            var peliculas = _peliculas.Where(pelicula => pelicula.IdPelicula == id);
            return peliculas.FirstOrDefault();
        }

        /*
        public IEnumerable<Pelicula> BuscarPorDirector(string director)
        {
            var peliculas = _peliculas.Where(pelicula => pelicula.directorPelicula == director);
            return peliculas;
        }
        */

        public void AgregarPelicula(Pelicula nuevaPelicula)
        {
            _peliculas.Add(nuevaPelicula);
        }

        /*
        public void ActualizarPelicula(int id, Pelicula actualizarPelicula)
        {
            if (id <= 0 || actualizarPelicula == null)
            {
                throw new ArgumentException("Completar todos los campos por favor.");
            }
            
            var datos = ObtenerPorId(id);

            datos.nombrePelicula = actualizarPelicula.nombrePelicula;
            datos.directorPelicula = actualizarPelicula.directorPelicula;
            datos.generoPelicula = actualizarPelicula.generoPelicula;
            datos.calfPelicula = actualizarPelicula.calfPelicula;
            datos.puntPelicula = actualizarPelicula.puntPelicula;
            datos.anoPelicula = actualizarPelicula.anoPelicula;

            _peliculas.Remove(datos);
            _peliculas.Add(datos);
        }
        */

        public void EliminarPelicula(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("El ID ingresado no existe en el sistema.");
            }

            var respuesta = ObtenerPorId(id);
            _peliculas.Remove(respuesta);
        }
    }
}