namespace ConsoleApp.Aula5
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string NomeRevisor { get; set; }
        public int QtdEstrelas { get; set; }
        public string Comentario { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
