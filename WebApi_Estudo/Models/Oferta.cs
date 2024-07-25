using System.ComponentModel.DataAnnotations;

namespace WebApi_Estudo.Models
{
    public class Oferta
    {

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int VagasDisponiveis { get; set; }

    }
}
