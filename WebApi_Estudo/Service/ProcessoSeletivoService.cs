using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.DataContext;
using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service
{
    public class ProcessoSeletivoService : IProcessoSeletivoInterface
    {
        private readonly ApplicationDbContext _context;
        public ProcessoSeletivoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProcessoSeletivo>>> GetProcessoSeletivo()
        {
            ServiceResponse<List<ProcessoSeletivo>> serviceResponse = new ServiceResponse<List<ProcessoSeletivo>>();
            try
            {
                serviceResponse.Dados = _context.ProcessoSeletivo.ToList();

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

        public async Task<ServiceResponse<List<ProcessoSeletivo>>> CreateProcessoSeletivo(ProcessoSeletivo novaProcessoSeletivo)
        {
            ServiceResponse<List<ProcessoSeletivo>> serviceResponse = new ServiceResponse<List<ProcessoSeletivo>>();

            try
            {
                if (novaProcessoSeletivo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados !";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }


                _context.Add(novaProcessoSeletivo);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.ProcessoSeletivo.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ProcessoSeletivo>> GetProcessoSeletivoById(int id)
        {
            ServiceResponse<ProcessoSeletivo> serviceResponse = new ServiceResponse<ProcessoSeletivo>();

            try
            {
                ProcessoSeletivo processoseletivo = _context.ProcessoSeletivo.FirstOrDefault(x => x.Id == id);
                if (processoseletivo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Processo Seletivo Não Encontrado !";
                    serviceResponse.Success = false;
                }
                serviceResponse.Dados = processoseletivo;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<ProcessoSeletivo>>> UpdateProcessoSeletivo(ProcessoSeletivo editadoProcessoSeletivo)
        {
            ServiceResponse<List<ProcessoSeletivo>> serviceResponse = new ServiceResponse<List<ProcessoSeletivo>>();

            ProcessoSeletivo processoseletivo = _context.ProcessoSeletivo.AsNoTracking().FirstOrDefault(x => x.Id == editadoProcessoSeletivo.Id);

            if (processoseletivo == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Processo Seletivo Não Encontrado !";
                serviceResponse.Success = false;
            }
            try
            {
                _context.ProcessoSeletivo.Update(editadoProcessoSeletivo);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.ProcessoSeletivo.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<ProcessoSeletivo>>> DeleteProcessoSeletivo(int id)
        {
            ServiceResponse<List<ProcessoSeletivo>> serviceResponse = new ServiceResponse<List<ProcessoSeletivo>>();

            try
            {
                ProcessoSeletivo processoseletivo = _context.ProcessoSeletivo.AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (processoseletivo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Processo Seletivo Não Encontrado !";
                    serviceResponse.Success = false;
                }

                _context.ProcessoSeletivo.Remove(processoseletivo);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.ProcessoSeletivo.ToList();

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
