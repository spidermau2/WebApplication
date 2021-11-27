using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
	public class CadastroController : Controller
	{
		static readonly string api = "https://localhost:44334/api/";

		public IActionResult Index()
		{
			ViewBag.Mensagem = "";
			return View();
		}

		public static List<Cliente> GetClientes()
		{
			List<Cliente> clientes = new();

			var client = new RestClient($"{api}Clientes")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);

			JArray jArray = JArray.Parse(response.Content);
			foreach(JObject jObject in jArray)
			{
				Cliente cliente = jObject.ToObject<Cliente>();
				clientes.Add(cliente);
			}

			return clientes;
		}

		public ActionResult DeleteCliente(Cliente cliente)
		{
			var client = new RestClient($"{api}Clientes/{cliente.IdCliente}")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.DELETE);
			IRestResponse response = client.Execute(request);

			return View("Index");
		}

		public static List<FormaPagamento> GetFormaPagamentos()
		{
			List<FormaPagamento> formaPagamentos = new();

			var client = new RestClient($"{api}FormaPagamentos")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);

			JArray jArray = JArray.Parse(response.Content);
			foreach (JObject jObject in jArray)
			{
				FormaPagamento formaPagamento = jObject.ToObject<FormaPagamento>();
				formaPagamentos.Add(formaPagamento);
			}

			return formaPagamentos;
		}

		public ActionResult DeleteFormaPagamento(FormaPagamento formaPagamento)
		{
			var client = new RestClient($"{api}FormaPagamentos/{formaPagamento.IdFormaPagamento}")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.DELETE);
			IRestResponse response = client.Execute(request);

			return View("Index");
		}

		public static List<Quarto> GetQuartos()
		{
			List<Quarto> quartos = new();

			var client = new RestClient($"{api}Quartos")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);

			JArray jArray = JArray.Parse(response.Content);
			foreach (JObject jObject in jArray)
			{
				Quarto quarto = jObject.ToObject<Quarto>();
				quartos.Add(quarto);
			}

			return quartos;
		}

		public ActionResult DeleteQuarto(Quarto quarto)
		{
			var client = new RestClient($"{api}Quartos/{quarto.IdQuarto}")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.DELETE);
			IRestResponse response = client.Execute(request);

			return View("Index");
		}

		public static List<Refeicao> GetRefeicoes()
		{
			List<Refeicao> refeicoes = new();

			var client = new RestClient($"{api}Refeicoes")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);

			JArray jArray = JArray.Parse(response.Content);
			foreach (JObject jObject in jArray)
			{
				Refeicao refeicao = jObject.ToObject<Refeicao>();
				refeicoes.Add(refeicao);
			}

			return refeicoes;
		}

		public ActionResult DeleteRefeicao(Refeicao refeicao)
		{
			var client = new RestClient($"{api}Refeicoes/{refeicao.IdRefeicao}")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.DELETE);
			IRestResponse response = client.Execute(request);

			return View("Index");
		}

		public static List<Reserva> GetReservas()
		{
			List<Reserva> reservas = new();

			var client = new RestClient($"{api}Reservas")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);

			JArray jArray = JArray.Parse(response.Content);
			foreach (JObject jObject in jArray)
			{
				Reserva reserva = jObject.ToObject<Reserva>();
				reservas.Add(reserva);
			}

			return reservas;
		}

		public ActionResult DeleteReserva(Reserva reserva)
		{
			var client = new RestClient($"{api}Reservas/{reserva.IdReserva}")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.DELETE);
			IRestResponse response = client.Execute(request);

			return View("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CadastroCliente(Cliente cliente)
		{
			if (ModelState.IsValid)
			{
				var client = new RestClient($"{api}Clientes")
				{
					Timeout = -1
				};
				var request = new RestRequest(Method.POST);
				request.AddHeader("Content-Type", "application/json");
				var body = $@"{{
					""nome"": ""{cliente.Nome}"",
					""rg"": ""{cliente.Rg}"",
					""cpf"": ""{cliente.Cpf}""
				}}";
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);

				if (response.IsSuccessful)
				{
					ModelState.Clear();
					ViewBag.Mensagem = "Pessoa cadastrada com sucesso";
				}
			}
			return View("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CadastroFormaPagamento(FormaPagamento formaPagamento)
		{
			if (ModelState.IsValid)
			{
				var client = new RestClient($"{api}FormaPagamentos")
				{
					Timeout = -1
				};
				var request = new RestRequest(Method.POST);
				request.AddHeader("Content-Type", "application/json");
				var body = $@"{{
					""descricao"": ""{formaPagamento.Descricao}""
				}}";
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);

				if (response.IsSuccessful)
				{
					ModelState.Clear();
					ViewBag.Mensagem = "Forma de pagamento cadastrada com sucesso";
				}
			}
			return View("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CadastroQuarto(Quarto quarto)
		{
			if (ModelState.IsValid)
			{
				var client = new RestClient($"{api}Quartos")
				{
					Timeout = -1
				};
				var request = new RestRequest(Method.POST);
				request.AddHeader("Content-Type", "application/json");
				var body = $@"{{
					""descricao"": ""{quarto.Descricao}"",
					""valor"": ""{quarto.Valor}""
				}}";
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);

				if (response.IsSuccessful)
				{
					ModelState.Clear();
					ViewBag.Mensagem = "Quarto cadastrado com sucesso";
				}
			}
			return View("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CadastroRefeicoes(Refeicao refeicao)
		{
			if (ModelState.IsValid)
			{
				var client = new RestClient($"{api}Refeicoes")
				{
					Timeout = -1
				};
				var request = new RestRequest(Method.POST);
				request.AddHeader("Content-Type", "application/json");
				var body = $@"{{
					""descricao"": ""{refeicao.Descricao}"",
					""valor"": ""{refeicao.Valor}""
				}}";
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);

				if (response.IsSuccessful)
				{
					ModelState.Clear();
					ViewBag.Mensagem = "Refeicao cadastrada com sucesso";
				}
			}
			return View("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CadastroReserva(Reserva reserva)
		{
			if (ModelState.IsValid)
			{
				var client = new RestClient($"{api}Reservas")
				{
					Timeout = -1
				};
				var request = new RestRequest(Method.POST);
				request.AddHeader("Content-Type", "application/json");
				var body = $@"{{
					""quantidadeReserva"": {reserva.QuantidadeReserva},
					""idCliente"": {reserva.IdCliente},
					""idPagamento"": {reserva.IdPagamento},
					""idQuarto"": {reserva.IdQuarto},
					""idRefeicao"": {reserva.IdRefeicao},
					""horaEntrada"": ""{reserva.HoraEntrada}"",
					""horaSaida"": ""{reserva.HoraSaida}"",
					""pago"": ""{reserva.Pago}""
				}}";
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);

				if (response.IsSuccessful)
				{
					ModelState.Clear();
					ViewBag.Mensagem = "Reserva cadastrada com sucesso";
				}
			}
			return View("Index");
		}
	}
}
