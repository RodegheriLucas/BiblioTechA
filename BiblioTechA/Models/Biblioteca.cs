namespace BiblioTechA.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public string BiblioNome { get; set; }
        public string Endereco { get; set; }
        private string Proprietario { get; set; }
        public Livro? Livro { get; set; }
        public Leitor? Leitor { get; set; }
        
    }
}
