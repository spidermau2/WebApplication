using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
	public class Reserva
	{
        public int IdReserva { get; set; }
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Informe uma quantidade", AllowEmptyStrings = false)]
        public int QuantidadeReserva { get; set; }
        [Display(Name = "Hora Entrada")]
        [Required(ErrorMessage = "Informe uma hora de entrada", AllowEmptyStrings = false)]
        public string HoraEntrada { get; set; }
        [Display(Name = "Hora Saída")]
        [Required(ErrorMessage = "Informe uma hora de saída", AllowEmptyStrings = false)]
        public string HoraSaida { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Informe um cliente", AllowEmptyStrings = false)]
        public int IdCliente { get; set; }
        [Display(Name = "Pagamento")]
        [Required(ErrorMessage = "Informe uma forma de pagamento", AllowEmptyStrings = false)]
        public int IdPagamento { get; set; }
        [Display(Name = "Quarto")]
        [Required(ErrorMessage = "Informe um quarto", AllowEmptyStrings = false)]
        public int IdQuarto { get; set; }
        [Display(Name = "Refeição")]
        [Required(ErrorMessage = "Informe uma refeição", AllowEmptyStrings = false)]
        public int IdRefeicao { get; set; }
        public string Pago { get; set; }
    }
}
