using Microsoft.AspNetCore.Mvc;
using WebApi_Estudo.Models;
using WebApi_Estudo.Service;

namespace WebApi_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly IProcessoSeletivoInterface _processoseletivointerface;
        public ProcessoSeletivoController(IProcessoSeletivoInterface leadinterface)
        {
            _processoseletivointerface = leadinterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProcessoSeletivo>>>> GetProcessoSeletivo()
        {
            return Ok(await _processoseletivointerface.GetProcessoSeletivo());
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> CreateProcessoSeletivo(ProcessoSeletivo novaProcessoSeletivo)
        {
            return Ok(await _processoseletivointerface.CreateProcessoSeletivo(novaProcessoSeletivo));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProcessoSeletivo>>> GetProcessoSeletivoById(int id)
        {
            ServiceResponse<ProcessoSeletivo> serviceResponse = await _processoseletivointerface.GetProcessoSeletivoById(id);
            return Ok(serviceResponse);
        }


        [HttpPut("AtualizaProcessoSeletivo")]
        public async Task<ActionResult<ServiceResponse<List<ProcessoSeletivo>>>> UpdateProcessoSeletivo(ProcessoSeletivo processoseletivo)
        {
            ServiceResponse<List<ProcessoSeletivo>> serviceResponse = await _processoseletivointerface.UpdateProcessoSeletivo(processoseletivo);
            return Ok(serviceResponse);
        }


        [HttpDelete("DeletaProcessoSeletivo")]
        public async Task<ActionResult<ServiceResponse<List<ProcessoSeletivo>>>> DeletaProcessoSeletivo(int Id)
        {
            ServiceResponse<List<ProcessoSeletivo>> serviceResponse = await _processoseletivointerface.DeleteProcessoSeletivo(Id);
            return Ok(serviceResponse);
        }
    }
}