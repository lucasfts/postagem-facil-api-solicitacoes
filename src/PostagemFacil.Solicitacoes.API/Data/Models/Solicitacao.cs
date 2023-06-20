namespace PostagemFacil.Solicitacoes.API.Data.Models
{
    public class Solicitacao
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Transportadora Transportadora { get; set; }
        public PesoLimite PesoLimite { get; set; }
        public TipoCaixa TipoCaixa { get; set; }
        public StatusSolicitacao Status { get; set; }
        public decimal Custo { get; set; }
        public string EtiquetaUrl { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}
