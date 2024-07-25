using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service
{
    public interface IProcessoSeletivoInterface
    {
        Task<ServiceResponse<List<ProcessoSeletivo>>> GetProcessoSeletivo();
        Task<ServiceResponse<List<ProcessoSeletivo>>> CreateProcessoSeletivo(ProcessoSeletivo novaProcessoSeletivo);
        Task<ServiceResponse<ProcessoSeletivo>> GetProcessoSeletivoById(int id);
        Task<ServiceResponse<List<ProcessoSeletivo>>> UpdateProcessoSeletivo(ProcessoSeletivo editadoProcessoSeletivo);
        Task<ServiceResponse<List<ProcessoSeletivo>>> DeleteProcessoSeletivo(int id);
    }
}
