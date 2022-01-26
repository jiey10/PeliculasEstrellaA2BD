using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peliculas.Domain.Entities;
using Peliculas.Infraestructure.Data;

namespace Peliculas.Infraestructure.Repositories
{
    public class PeliculaSQLRepositorie
    {
        private readonly PeliculasEstrellaContext _context;

        public PeliculaSQLRepositorie()
        {
            _context = new PeliculasEstrellaContext();
        }

        public IEnumerable<Pelicula> ObtenerTodas()
        {
            return _context.Peliculas;
        }
        
        public Pelicula ObtenerPorId(int id)
        {
            var peliculas = _context.Peliculas.Where(pelicula => pelicula.IdPelicula == id);
            return peliculas.FirstOrDefault();
        }

        public IEnumerable<Pelicula> BuscarPorDirector(string director)
        {
            var peliculas = _context.Peliculas.Where(pelicula => pelicula.DirectorPelicula == director);
            return peliculas;
        }

        public void AgregarPelicula(Pelicula nuevaPelicula)
        {
            var dato = nuevaPelicula;
            _context.Peliculas.Add(dato);
            var filas = _context.SaveChanges();
            if(filas <= 0)
            {
                throw new Exception("Hubo un error al registrar la pelicula. Intentelo nuevamente.");
            }
            return;
        }

        public void ActualizarPelicula(int id, Pelicula actualizarPelicula)
        {
            if (id <= 0 || actualizarPelicula == null)
            {
                throw new ArgumentException("Completar todos los campos por favor.");
            }
            
            var datos = ObtenerPorId(id);

            datos.NombrePelicula = actualizarPelicula.NombrePelicula;
            datos.DirectorPelicula = actualizarPelicula.DirectorPelicula;
            datos.GeneroPelicula = actualizarPelicula.GeneroPelicula;
            datos.CalfPelicula = actualizarPelicula.CalfPelicula;
            datos.PuntPelicula = actualizarPelicula.PuntPelicula;
            datos.AnoPelicula = actualizarPelicula.AnoPelicula;

            _context.Update(datos);
            var filas = _context.SaveChanges();
            return;
        }

        public void EliminarPelicula(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("El ID ingresado no existe en el sistema.");
            }

            var dato = ObtenerPorId(id);
            _context.Remove(dato);
            var filas = _context.SaveChanges();
            return;
        }


    }
}