using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostagemFacil.Solicitacoes.API.Business;
using PostagemFacil.Solicitacoes.API.Business.DTOs;

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

        [HttpPost]
        public async Task<IActionResult> CriarSolicitacao([FromForm] CriarSolicitacaoDTO dto)
        {
            await _service.CriarSolicitacao(dto);
            return Ok();
        }
    }
}
