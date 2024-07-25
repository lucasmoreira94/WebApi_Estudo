using System.ComponentModel.DataAnnotations;
//using WebApi_Estudo.Enums;

namespace WebApi_Estudo.Models
{
    public class ProcessoSeletivo
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeTermino { get; set; }

    }
}
