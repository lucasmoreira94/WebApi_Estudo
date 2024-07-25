using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.DataContext;
using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service
{
     public class OfertaService : IOfertaInterface
        {
            private readonly ApplicationDbContext _context;
            public OfertaService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ServiceResponse<List<Oferta>>> GetOferta()
            {
                ServiceResponse<List<Oferta>> serviceResponse = new ServiceResponse<List<Oferta>>();
                try
                {
                    serviceResponse.Dados = _context.Oferta.ToList();

                    if (serviceResponse.Dados.Count == 0)
                    {
                        serviceResponse.Mensagem = "Sem dados";
                    }
                }
                catch (Exception ex)
                {
                    serviceResponse.Mensagem = ex.Message;
                    serviceResponse.Success = false;
                }
                return serviceResponse;
            }

            public async Task<ServiceResponse<List<Oferta>>> CreateOferta(Oferta novaOferta)
            {
                ServiceResponse<List<Oferta>> serviceResponse = new ServiceResponse<List<Oferta>>();

                try
                {
                    if (novaOferta == null)
                    {
                        serviceResponse.Dados = null;
                        serviceResponse.Mensagem = "Informar Dados !";
                        serviceResponse.Success = false;

                        return serviceResponse;
                    }


                    _context.Add(novaOferta);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = _context.Oferta.ToList();

                }
                catch (Exception ex)
                {
                    serviceResponse.Mensagem = ex.Message;
                    serviceResponse.Success = false;
                }
                return serviceResponse;
            }

            public async Task<ServiceResponse<Oferta>> GetOfertaById(int id)
            {
                ServiceResponse<Oferta> serviceResponse = new ServiceResponse<Oferta>();

                try
                {
                    Oferta oferta = _context.Oferta.FirstOrDefault(x => x.Id == id);
                    if (oferta == null)
                    {
                        serviceResponse.Dados = null;
                        serviceResponse.Mensagem = "Oferta Não Encontrada !";
                        serviceResponse.Success = false;
                    }
                    serviceResponse.Dados = oferta;
                }
                catch (Exception ex)
                {
                    serviceResponse.Mensagem = ex.Message;
                    serviceResponse.Success = false;
                }
                return serviceResponse;

            }

            public async Task<ServiceResponse<List<Oferta>>> UpdateOferta(Oferta editadoOferta)
            {
                ServiceResponse<List<Oferta>> serviceResponse = new ServiceResponse<List<Oferta>>();

                Oferta oferta = _context.Oferta.AsNoTracking().FirstOrDefault(x => x.Id == editadoOferta.Id);

                if (oferta == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Oferta Não Encontrada !";
                    serviceResponse.Success = false;
                }

                try
                {
                    _context.Oferta.Update(editadoOferta);
                     await _context.SaveChangesAsync();
                     serviceResponse.Dados = _context.Oferta.ToList();
                }
                catch (Exception ex)
                {
                    serviceResponse.Mensagem = ex.Message;
                    serviceResponse.Success = false;
                }
                return serviceResponse;
            }

            public async Task<ServiceResponse<List<Oferta>>> DeleteOferta(int id)
            {
                ServiceResponse<List<Oferta>> serviceResponse = new ServiceResponse<List<Oferta>>();

                try
                {
                    Oferta oferta = _context.Oferta.AsNoTracking().FirstOrDefault(x => x.Id == id);

                    if (oferta == null)
                    {
                        serviceResponse.Dados = null;
                        serviceResponse.Mensagem = "Oferta Não Encontrada !";
                        serviceResponse.Success = false;
                    }

                    _context.Oferta.Remove(oferta);
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Oferta.ToList();

                }
                catch (Exception ex)
                {
                    serviceResponse.Mensagem = ex.Message;
                    serviceResponse.Success = false;
                }
                return serviceResponse;
            }

      }    
}
