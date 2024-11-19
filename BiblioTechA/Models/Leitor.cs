using System.ComponentModel.DataAnnotations;

namespace BiblioTechA.Models
{
    public class Leitor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        //Relacionando o Livro com o Leitor
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve ter 11 números.")]
        public string Cpf { get; set; }
        //Alterado o tipo para DateOnly, para remover o horário que vinha junto a data
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateOnly Nascimento { get; set; }
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
// Precisa adicionar um meio de gerar a ID Automaticamente ao criar um novo Leitor