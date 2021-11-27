using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
	public class Quarto
	{
        public int IdQuarto { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe uma descrição", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Informe um valor", AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        public float Valor { get; set; }
    }
}
