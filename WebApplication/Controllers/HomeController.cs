using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;
using WebApplication.Models;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		static readonly string api = "https://localhost:44334/api/";
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult QuartosOcupados()
		{
			return View();
		}

		public IActionResult Reservas()
		{
			return View();
		}

		public IActionResult Cardapio()
		{
			return View();
		}

		public IActionResult Caixa()
		{
			return View();
		}

		public static List<Quarto> GetQuartosOcupados()
		{
			List<Quarto> quartos = new();

			var client = new RestClient($"{api}Quartos/Ocupados")
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

		public static List<Resumo> GetResumos()
		{
			List<Resumo> resumos = new();

			var client = new RestClient($"{api}Resumo")
			{
				Timeout = -1
			};
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);

			JArray jArray = JArray.Parse(response.Content);
			foreach (JObject jObject in jArray)
			{
				Resumo resumo = jObject.ToObject<Resumo>();
				resumos.Add(resumo);
			}

			return resumos;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
