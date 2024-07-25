using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.DataContext;
using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service
{
    public class LeadService : ILeadInterface
    {
        private readonly ApplicationDbContext _context;
        public LeadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Lead>>> GetLead()
        {
            ServiceResponse<List<Lead>> serviceResponse = new ServiceResponse<List<Lead>>();
            try
            {
                serviceResponse.Dados = _context.Lead.ToList();

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

        public async Task<ServiceResponse<List<Lead>>> CreateLead(Lead novaLead)
        {
            ServiceResponse<List<Lead>> serviceResponse = new ServiceResponse<List<Lead>>();

            try
            {
                if (novaLead == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados !";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }


                _context.Add(novaLead);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Lead.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Lead>> GetLeadById(int id)
        {
            ServiceResponse<Lead> serviceResponse = new ServiceResponse<Lead>();

            try
            {
                Lead lead = _context.Lead.FirstOrDefault(x => x.Id == id);
                if (lead == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário Não Encontrado !";
                    serviceResponse.Success = false;
                }
                serviceResponse.Dados = lead;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Lead>>> UpdateLead(Lead editadoLead)
        {
            ServiceResponse<List<Lead>> serviceResponse = new ServiceResponse<List<Lead>>();

            Lead lead = _context.Lead.AsNoTracking().FirstOrDefault(x => x.Id == editadoLead.Id);

            if (lead == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuário Não Encontrado !";
                serviceResponse.Success = false;
            }

            try
            {
                _context.Lead.Update(editadoLead);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Lead.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<Lead>>> DeleteLead(int id)
        {
            ServiceResponse<List<Lead>> serviceResponse = new ServiceResponse<List<Lead>>();

            try
            {
                Lead lead = _context.Lead.AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (lead == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário Não Encontrado !";
                    serviceResponse.Success = false;
                }

                _context.Lead.Remove(lead);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Lead.ToList();

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
 
