using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
	public class Cliente
	{
        public int IdCliente { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe um nome", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Nome { get; set; }
        [Display(Name = "RG")]
        [Required(ErrorMessage = "Informe um RG", AllowEmptyStrings = false)]
        public int Rg { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe um CPF", AllowEmptyStrings = false)]
        public long Cpf { get; set; }
    }
}
