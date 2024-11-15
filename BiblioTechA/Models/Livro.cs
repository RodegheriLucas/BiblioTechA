namespace BiblioTechA.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        //Criando um relacionamento entre o Leitor e o Livro
        public int? LeitorCpf { get; set; }
        public Leitor? Leitor { get; set; }
        //Criando um relacionamento entre a Biblioteca e o Livro
        public int BibliotecaId { get; set; }   
        public Biblioteca Biblioteca { get; set; }
    }
}
