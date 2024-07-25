using System.ComponentModel.DataAnnotations;

namespace WebApi_Estudo.Models
{
    public class Lead
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string CPF { get; set; }

     }
}
