using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using N3C_348209_parodi_client.Models.Dtos.Log;
using N3C_348209_parodi_client.ServicesInterfaces;
using RestSharp;

namespace N3C_348209_parodi_client.Controllers.Expense
{
    public class ExpenseController : Controller
    {
        private string _url = "https://mauricioapi-eddggufkfza4a3gv.brazilsouth-01.azurewebsites.net";
        private readonly ISelectionServices _selectionServices;

        public ExpenseController(ISelectionServices selectionServices)
        {
            _selectionServices = selectionServices;
        }
        public IActionResult Logs()
        {
            ViewBag.Expenses = _selectionServices.GetExpensesForSelect();
            return View();
        }
        [HttpPost]
        public IActionResult Logs(int expenseId)
        {
            var client = new RestClient(_url);
            var request = new RestRequest($"/api/v1/Expenses/{expenseId}/logs", Method.Get);

            request.AddHeader("Authorization", $"Bearer {HttpContext.Session.GetString("token")}");

            var response = client.Execute(request);

            if ((int)response.StatusCode == 200)
            {
                var logs = JsonSerializer.Deserialize<IEnumerable<LogDto>>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (!logs.Any())
                {
                    ViewBag.Error = "Este gasto no tiene logs registrados.";
                    ViewBag.Expenses = _selectionServices.GetExpensesForSelect();
                    return View(new List<LogDto>());
                }

                ViewBag.Expenses = _selectionServices.GetExpensesForSelect();
                return View(logs);
            }

            ViewBag.Error = "No se encontraron logs.";
            ViewBag.Expenses = _selectionServices.GetExpensesForSelect();
            return View(new List<LogDto>());
        }

    }
}
