using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Estudo.Models;
using WebApi_Estudo.Service;

namespace WebApi_Estudo.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class LeadController : ControllerBase
        {
            private readonly ILeadInterface _leadinterface;
            public LeadController(ILeadInterface leadinterface)
            {
                _leadinterface = leadinterface;
            }


            [HttpGet]
            public async Task<ActionResult<ServiceResponse<List<Lead>>>> GetLead()
            {
                return Ok(await _leadinterface.GetLead());
            }


            [HttpPost]
            public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> CreateLead(Lead novaLead)
            {
                return Ok(await _leadinterface.CreateLead(novaLead));
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<ServiceResponse<Lead>>> GetLeadById(int id)
            {
                ServiceResponse<Lead> serviceResponse = await _leadinterface.GetLeadById(id);
                return Ok(serviceResponse);
            }

            [HttpPut("AtualizaLead")]
            public async Task<ActionResult<ServiceResponse<List<Lead>>>> UpdateLead(Lead lead)
            {
                ServiceResponse<List<Lead>> serviceResponse = await _leadinterface.UpdateLead(lead);
                return Ok(serviceResponse);
            }

            [HttpDelete("DeletaLead")]
            public async Task<ActionResult<ServiceResponse<List<Lead>>>> DeletaLead(int Id)
            {
                ServiceResponse<List<Lead>> serviceResponse = await _leadinterface.DeleteLead(Id);
                return Ok(serviceResponse);
            }
        }
    }


 