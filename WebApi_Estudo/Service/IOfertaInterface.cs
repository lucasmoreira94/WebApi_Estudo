using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service
{
    public interface IOfertaInterface
    {
        Task<ServiceResponse<List<Oferta>>> GetOferta();
        Task<ServiceResponse<List<Oferta>>> CreateOferta(Oferta novaOferta);
        Task<ServiceResponse<Oferta>> GetOfertaById(int id);
        Task<ServiceResponse<List<Oferta>>> UpdateOferta(Oferta editadoOferta);
        Task<ServiceResponse<List<Oferta>>> DeleteOferta(int id);
    }
}
