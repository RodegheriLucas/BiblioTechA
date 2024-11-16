namespace BiblioTechA.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Empresta { get; set; }
        public DateTime Devolve { get; set; }
        public Leitor? Leitor { get; set; }
        public Livro? LivroNome { get; set; }
    }
}
