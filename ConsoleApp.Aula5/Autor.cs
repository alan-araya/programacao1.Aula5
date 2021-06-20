using System.Collections.Generic;

namespace ConsoleApp.Aula5
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string WebUrl { get; set; }
        public List<LivroAutor> Livros { get; set; }
    }
}
