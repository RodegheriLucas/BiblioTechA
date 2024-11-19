namespace BiblioTechA.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public string BiblioNome { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Acervo?> LivroNoAcervo { get; set; }
    }
}
