
namespace PostagemFacil.Solicitacoes.API.Business.DTOs
{
    public class CriarSolicitacaoDTO
    {
        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string Endereco { get; set; }
        public int TransportadoraId { get; set; }
        public int PesoLimiteId { get; set; }
        public int TipoCaixaId { get; set; }
        public decimal Custo { get; set; }
        public IFormFile Etiqueta { get; set; }
    }
}
