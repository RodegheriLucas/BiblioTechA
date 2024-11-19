namespace BiblioTechA.Models
{
    public class Acervo
    {
        public int BibliotecaId { get; set; }
        public Biblioteca? Biblioteca { get; set; }
        public int LivroAcervoId { get; set; }
        public Livro? Livro { get; set; }
    }
}
