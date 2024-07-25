using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Estudo.Models
{
    public class Inscricao
    {

        [Key]
        public int Id { get; set; }

        public string NumeroInscricao { get; set; }

        public DateTime Data { get; set; }

        public string Status { get; set; }

        // FK
        [ForeignKey("Lead")]
        public int LeadId { get; set; }
       
        public Lead Lead { get; set; }         

        // FK
        [ForeignKey("ProcessoSeletivo")]
        public int ProcessoSeletivoId { get; set; }

        public ProcessoSeletivo ProcessoSeletivo { get; set; }

        // FK
        [ForeignKey("Oferta")]
        public int OfertaId { get; set; }

        public Oferta Oferta { get; set; }
    }
}
