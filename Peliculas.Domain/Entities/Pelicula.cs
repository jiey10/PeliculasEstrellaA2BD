using System;
using System.Collections.Generic;

#nullable disable

namespace Peliculas.Domain.Entities
{
    public partial class Pelicula
    {
        public int IdPelicula { get; set; }
        public string NombrePelicula { get; set; }
        public string DirectorPelicula { get; set; }
        public string GeneroPelicula { get; set; }
        public int? CalfPelicula { get; set; }
        public int? PuntPelicula { get; set; }
        public string AnoPelicula { get; set; }
    }
}
