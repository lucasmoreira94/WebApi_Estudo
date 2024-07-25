using WebApi_Estudo.Models;
using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.DataContext;

namespace WebApi_Estudo.Service
{
    public class InscricaoService : IInscricaoInterface
    {
        private readonly ApplicationDbContext _context;
        public InscricaoService(ApplicationDbContext context)
        {
            _context = context;
        }
                
        public async Task<ServiceResponse<List<Inscricao>>> GetInscricao()
        {
            ServiceResponse<List<Inscricao>> serviceResponse = new ServiceResponse<List<Inscricao>>();
            try
            {
                serviceResponse.Dados = await _context.Inscricao.ToListAsync();

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

        public async Task<ServiceResponse<List<Inscricao>>> CreateInscricao(Inscricao novaInscricao)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = new ServiceResponse<List<Inscricao>>();

            try
            {
                if(novaInscricao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados !";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }


                _context.Add(novaInscricao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Inscricao.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Inscricao>> GetInscricaoById(int id)
        {
            ServiceResponse <Inscricao> serviceResponse = new ServiceResponse<Inscricao>();

            try
            {
                Inscricao inscricao = await _context.Inscricao
                                            .Include(e => e.Lead)
                                            .Include(e => e.Oferta)
                                            .Include(e => e.ProcessoSeletivo)
                                            .FirstOrDefaultAsync(x => x.Id == id);
                if(inscricao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Inscrição Não Encontrada !";
                    serviceResponse.Success = false;
                }
                serviceResponse.Dados = inscricao;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Inscricao>>> GetInscricaoByCPF(string cpf)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = new ServiceResponse<List<Inscricao>>();

            try
            {
                List<Inscricao> inscricoes = await _context.Inscricao
                                            .Include(e => e.Lead)
                                            .Include(e => e.Oferta)
                                            .Include(e => e.ProcessoSeletivo)
                                            .Where(x => x.Lead.CPF == cpf).ToListAsync();
                if (inscricoes == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Inscrição Não Encontrada !";
                    serviceResponse.Success = false;
                }
                serviceResponse.Dados = inscricoes;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Inscricao>>> GetInscricaoByOfertaId(int ofertaId)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = new ServiceResponse<List<Inscricao>>();

            try
            {
                List<Inscricao> inscricoes = await _context.Inscricao
                                            .Include(e => e.Lead)
                                            .Include(e => e.Oferta)
                                            .Include(e => e.ProcessoSeletivo)
                                            .Where(x => x.OfertaId == ofertaId).ToListAsync();
                if (inscricoes == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Inscrição Não Encontrada !";
                    serviceResponse.Success = false;
                }
                serviceResponse.Dados = inscricoes;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Inscricao>>> UpdateInscricao(Inscricao editadoInscricao)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = new ServiceResponse<List<Inscricao>>();
           
            Inscricao inscricao = _context.Inscricao.AsNoTracking().FirstOrDefault(x=>x.Id== editadoInscricao.Id);

            if (inscricao == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Inscrição Não Encontrado !";
                serviceResponse.Success = false;
            }

            try
            {
                _context.Inscricao.Update(editadoInscricao);
                 await _context.SaveChangesAsync();
                 serviceResponse.Dados = _context.Inscricao.ToList(); 
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Inscricao>>> DeleteInscricao(int id)
        {
            ServiceResponse<List<Inscricao>> serviceResponse = new ServiceResponse<List<Inscricao>>();

            try
            {
                Inscricao inscricao = _context.Inscricao.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (inscricao == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Inscrição Não Encontrado !";
                serviceResponse.Success = false;
            }

            _context.Inscricao.Remove(inscricao);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Inscricao.ToList();          

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
