using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service
{
    public interface IInscricaoInterface
    {
        Task<ServiceResponse<List<Inscricao>>> GetInscricao();
        Task<ServiceResponse<List<Inscricao>>> CreateInscricao(Inscricao novaInscricao);
        Task<ServiceResponse<Inscricao>> GetInscricaoById(int id);
        Task<ServiceResponse<List<Inscricao>>> GetInscricaoByCPF(string cpf);
        Task<ServiceResponse<List<Inscricao>>> GetInscricaoByOfertaId(int ofertaId);
        Task<ServiceResponse<List<Inscricao>>> UpdateInscricao(Inscricao editadoInscricao);
        Task<ServiceResponse<List<Inscricao>>> DeleteInscricao(int id);
        
    }
}
