﻿using PostagemFacil.Solicitacoes.API.Business.DTOs;
using PostagemFacil.Solicitacoes.API.Business.Enums;
using PostagemFacil.Solicitacoes.API.Data;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Business
{
    public interface ISolicitacoesService
    {
        Task CriarSolicitacao(CriarSolicitacaoDTO dto);
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
                UsuarioId = dto.UsuarioId,
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
    }
}