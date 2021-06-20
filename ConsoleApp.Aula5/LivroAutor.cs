using System.Collections.Generic;

namespace ConsoleApp.Aula5
{
    public class LivroAutor
    {
        public int AutorId { get; set; }
        public int LivroId { get; set; }
        public string Tipo { get; set; }
        public Autor Autor { get; set; }
        public Livro Livro { get; set; }
    }
}
