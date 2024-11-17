namespace BiblioTechA.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public int BibliotecaId { get; set; }
        public Biblioteca? Biblioteca { get; set; }
    }
}
