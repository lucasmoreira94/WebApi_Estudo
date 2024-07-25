using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Estudo.Models;
using WebApi_Estudo.Service;

namespace WebApi_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoInterface _inscricaoInterface;
        public InscricaoController(IInscricaoInterface inscricaointerface)
        {
            _inscricaoInterface = inscricaointerface;
        }

        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> GetInscricao()
        {
            return Ok(await _inscricaoInterface.GetInscricao());
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> CreateInscricao(Inscricao novaInscricao)
        {
            return Ok(await _inscricaoInterface.CreateInscricao(novaInscricao));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse <Inscricao>>> GetInscricaoById(int id)
        {
            ServiceResponse<Inscricao> serviceResponse = await _inscricaoInterface.GetInscricaoById(id);
            return Ok(serviceResponse);
        }

        [HttpGet("GetInscricaoByCPF/{cpf}")]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> GetInscricaoByCPF(string cpf)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = await _inscricaoInterface.GetInscricaoByCPF(cpf);
            return Ok(serviceResponse.Dados);
        }

        [HttpGet("GetInscricaoByOfertaId/{ofertaId}")]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> GetInscricaoByOfertaId(int ofertaId)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = await _inscricaoInterface.GetInscricaoByOfertaId(ofertaId);
            return Ok(serviceResponse.Dados);
        }

        [HttpPut("AtualizaInscricao")]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> UpdateInscricao(Inscricao inscricao)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = await _inscricaoInterface.UpdateInscricao(inscricao);
            return Ok(serviceResponse);
        }

        [HttpDelete("DeletaInscricao")]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> DeletaInscricao(int Id)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = await _inscricaoInterface.DeleteInscricao(Id);
            return Ok(serviceResponse);
        }
    }
}
