namespace BiblioTechA.Models
{
    public class LivroPedido
    {
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }
    }
}
