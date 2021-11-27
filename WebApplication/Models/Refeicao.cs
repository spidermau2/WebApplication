using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
	public class Refeicao
	{
		public int IdRefeicao { get; set; }
		[Display(Name = "Prato")]
		[Required(ErrorMessage = "Informe um prato", AllowEmptyStrings = false)]
		[DataType(DataType.Text)]
		public string Descricao { get; set; }
		[Display(Name = "Valor")]
		[Required(ErrorMessage = "Informe um valor", AllowEmptyStrings = false)]
		[DataType(DataType.Currency)]
		public decimal Valor { get; set; }
	}
}
