using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostagemFacil.Solicitacoes.API.Business;
using PostagemFacil.Solicitacoes.API.Business.DTOs;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacoesController : ControllerBase
    {
        private readonly ISolicitacoesService _service;

        public SolicitacoesController(ISolicitacoesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterSolicitacoes(int pagina = 1, int itensPorPagina = 10)
        {
            var solicitacoes = await _service.ObterSolicitacoes(pagina, itensPorPagina);
            return Ok(solicitacoes);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObterSolicitacoesPorUsuario(Guid usuarioId)
        {
            var solicitacoes = await _service.ObterSolicitacoesPorUsuario(usuarioId);
            return Ok(solicitacoes);
        }

        [HttpPost]
        public async Task<IActionResult> CriarSolicitacao([FromForm] CriarSolicitacaoDTO dto)
        {
            await _service.CriarSolicitacao(dto);
            return Ok();
        }
    }
}
