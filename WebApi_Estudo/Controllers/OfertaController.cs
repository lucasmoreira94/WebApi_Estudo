using Microsoft.AspNetCore.Mvc;
using WebApi_Estudo.Models;
using WebApi_Estudo.Service;

namespace WebApi_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaInterface _ofertainterface;
        public OfertaController(IOfertaInterface leadinterface)
        {
            _ofertainterface = leadinterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Oferta>>>> GetOferta()
        {
            return Ok(await _ofertainterface.GetOferta());
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Inscricao>>>> CreateOferta(Oferta novaOferta)
        {
            return Ok(await _ofertainterface.CreateOferta(novaOferta));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Oferta>>> GetOfertaById(int id)
        {
            ServiceResponse<Oferta> serviceResponse = await _ofertainterface.GetOfertaById(id);
            return Ok(serviceResponse);
        }

        [HttpPut("AtualizaOferta")]
        public async Task<ActionResult<ServiceResponse<List<Oferta>>>> UpdateOferta(Oferta oferta)
        {
            ServiceResponse<List<Oferta>> serviceResponse = await _ofertainterface.UpdateOferta(oferta);
            return Ok(serviceResponse);
        }

        [HttpDelete("DeletaOferta")]
        public async Task<ActionResult<ServiceResponse<List<Oferta>>>> DeletaOferta(int Id)
        {
            ServiceResponse<List<Oferta>> serviceResponse = await _ofertainterface.DeleteOferta(Id);
            return Ok(serviceResponse);
        }
    }
}
