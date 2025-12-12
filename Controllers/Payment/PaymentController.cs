using System.Runtime.CompilerServices;
using System.Text.Json;
using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Dtos.Payment;
using LibreriaLogicaAplicacion.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using N3C_348209_parodi_client.Models.Dtos.Payment;
using RestSharp;

namespace N3C_348209_parodi_client.Controllers.Payment
{
    public class PaymentController : Controller
    {
        private string _url = "https://mauricioapi-eddggufkfza4a3gv.brazilsouth-01.azurewebsites.net";

        [HttpGet]
        public IActionResult Create()
        {
            var expenses = GetExpensesForSelect();
            var users = GetUsersForSelect();
            ViewBag.Expenses = expenses;
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddPaymentDto dto)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/api/v1/Payments", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {HttpContext.Session.GetString("token")}");

            request.AddJsonBody(dto);

            RestResponse response = client.Execute(request);

            if ((int)response.StatusCode == 400)
            {
                ViewBag.Message = "Por favor verifique los campos ingresados";
            }
            else if ((int)response.StatusCode == 500)
            {
                ViewBag.Message = "Un error inesperado ha ocurrido";
            }
            else if ((int)response.StatusCode == 201)
            {
                ViewBag.CreatedMessage = "Pago creado correctamente";
            }
            else
            {
                ViewBag.Message = $"Error inesperado: {response.StatusCode}";
            }

            var expenses = GetExpensesForSelect();
            var users = GetUsersForSelect();
            ViewBag.Expenses = expenses;
            ViewBag.Users = users;

            return View(dto);
        }

        [HttpGet]
        public IActionResult UserPayments()
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/api/v1/Users/payments", Method.Get);

            request.AddHeader("Authorization", $"Bearer {HttpContext.Session.GetString("token")}");

            RestResponse response = client.Execute(request);

            if ((int)response.StatusCode == 200)
            {
                var payments = JsonSerializer.Deserialize<IEnumerable<GetAllPaymentsDto>>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                return View(payments);
            }

            ViewBag.Error = "No hay pagos para este usuario";
            return View(new List<GetAllPaymentsDto>());
        }


        public IEnumerable<ExpenseDto> GetExpensesForSelect()
        {
            string endpointUrl = "/api/v1/Expenses";
            var client = new RestClient(_url);
            var request = new RestRequest(endpointUrl, Method.Get);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {HttpContext.Session.GetString("token")}");

            RestResponse response = client.Execute(request);

            if ((int)response.StatusCode == 200)
            {
                var expenses = JsonSerializer.Deserialize<IEnumerable<ExpenseDto>>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                return expenses;
            }

            return new List<ExpenseDto>();
        }

        private IEnumerable<UserSelectDto> GetUsersForSelect()
        {
            string endpointUrl = "/api/v1/Users/getAll";
            var client = new RestClient(_url);
            var request = new RestRequest(endpointUrl, Method.Get);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {HttpContext.Session.GetString("token")}");

            RestResponse response = client.Execute(request);

            if ((int)response.StatusCode == 200)
            {
                var users = JsonSerializer.Deserialize<IEnumerable<UserSelectDto>>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                return users;
            }

            return new List<UserSelectDto>();
        }
    }
}
