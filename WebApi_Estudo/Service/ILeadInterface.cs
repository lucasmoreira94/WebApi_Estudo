using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service
{
    public interface ILeadInterface
    {
        Task<ServiceResponse<List<Lead>>> GetLead();
        Task<ServiceResponse<List<Lead>>> CreateLead(Lead novaLead);
        Task<ServiceResponse<Lead>> GetLeadById(int id);
        Task<ServiceResponse<List<Lead>>> UpdateLead(Lead editadoLead);
        Task<ServiceResponse<List<Lead>>> DeleteLead(int id);

    }
}
