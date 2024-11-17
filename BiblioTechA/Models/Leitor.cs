namespace BiblioTechA.Models
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //Relacionando o Livro com o Leitor
        public string Cpf { get; set; }
        //Alterado o tipo para DateOnly, para remover o horário que vinha junto a data
        public DateOnly Nascimento { get; set; }
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
// Precisa adicionar um meio de gerar a ID Automaticamente ao criar um novo Leitor