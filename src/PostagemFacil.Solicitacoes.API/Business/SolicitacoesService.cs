using Microsoft.EntityFrameworkCore;
using PostagemFacil.Solicitacoes.API.Business.DTOs;
using PostagemFacil.Solicitacoes.API.Business.Enums;
using PostagemFacil.Solicitacoes.API.Data;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Business
{
    public interface ISolicitacoesService
    {
        Task CriarSolicitacao(CriarSolicitacaoDTO dto);
        Task AtualizarStatus(int solicitacaoId, StatusEnum status);
        Task<IEnumerable<Solicitacao>> ObterSolicitacoes(int pagina, int itensPorPagina);
        Task<IEnumerable<Solicitacao>> ObterSolicitacoesPorUsuario(Guid clienteId);
    }

    public class SolicitacoesService : ISolicitacoesService
    {
        private readonly SolictacoesContext _solictacoesContext;

        public SolicitacoesService(SolictacoesContext solictacoesContext)
        {
            _solictacoesContext = solictacoesContext;
        }

        public async Task CriarSolicitacao(CriarSolicitacaoDTO dto)
        {
            var model = new Solicitacao
            {
                ClienteId = dto.ClienteId,
                NomeCliente = dto.NomeCliente,
                Endereco = dto.Endereco,
                Transportadora = new Transportadora { Id = dto.TransportadoraId },
                TipoCaixa = new TipoCaixa { Id = dto.TipoCaixaId },
                PesoLimite = new PesoLimite { Id = dto.PesoLimiteId },
                Status = new StatusSolicitacao { Id = (int)StatusEnum.PAGAMENTO_PENDENTE },
                Custo = dto.Custo,
                EtiquetaUrl = $"{Guid.NewGuid()}_{dto.Etiqueta.FileName}",
                DataSolicitacao = DateTime.Now,
            };

            _solictacoesContext.Attach(model.Transportadora);
            _solictacoesContext.Attach(model.TipoCaixa);
            _solictacoesContext.Attach(model.PesoLimite);
            _solictacoesContext.Attach(model.Status);

            await _solictacoesContext.Solictacoes.AddAsync(model);
            await _solictacoesContext.SaveChangesAsync();
        }

        public async Task AtualizarStatus(int solicitacaoId, StatusEnum status)
        {
            var solicitacao = _solictacoesContext.Solictacoes.Find(solicitacaoId);
            solicitacao.Status = new StatusSolicitacao { Id = (int)status };
            _solictacoesContext.Attach(solicitacao.Status);
            await _solictacoesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Solicitacao>> ObterSolicitacoes(int pagina, int itensPorPagina)
        {
            return await _solictacoesContext.Solictacoes
                            .Skip((pagina - 1) * itensPorPagina)
                            .Take(itensPorPagina)
                            .Include(x => x.Transportadora)
                            .Include(x => x.TipoCaixa)
                            .Include(x => x.PesoLimite)
                            .Include(x => x.Status)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Solicitacao>> ObterSolicitacoesPorUsuario(Guid clienteId)
        {
            return await _solictacoesContext.Solictacoes
                            .Include(x => x.Transportadora)
                            .Include(x => x.TipoCaixa)
                            .Include(x => x.PesoLimite)
                            .Include(x => x.Status)
                            .Where(x => x.ClienteId.Equals(clienteId))
                            .ToListAsync();
        }
    }
}
