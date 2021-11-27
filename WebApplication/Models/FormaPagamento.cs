using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
	public class FormaPagamento
	{
		public int IdFormaPagamento { get; set; }
		[Display(Name = "Descrição")]
		[Required(ErrorMessage = "Informe uma descrição", AllowEmptyStrings = false)]
		[DataType(DataType.Text)]
		public string Descricao { get; set; }
	}
}
