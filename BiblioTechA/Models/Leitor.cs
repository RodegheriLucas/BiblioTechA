namespace BiblioTechA.Models
{
    public class Leitor
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        //Relacionando o Livro com o Leitor
        public int Cpf { get; set; }
        public DateTime Nascimento { get; set; }
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
