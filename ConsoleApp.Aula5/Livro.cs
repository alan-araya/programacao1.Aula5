using System;
using System.Collections.Generic;

namespace ConsoleApp.Aula5
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime PublicadoEm { get; set; }
        public List<LivroAutor> Autores { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
