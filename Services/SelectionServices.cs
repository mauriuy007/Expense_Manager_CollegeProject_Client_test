using System.Text.Json;
using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Dtos.User;
using N3C_348209_parodi_client.ServicesInterfaces;
using RestSharp;

namespace N3C_348209_parodi_client.Services
{
    public class SelectionServices : ISelectionServices
    {
        private readonly string _url;
        private readonly IHttpContextAccessor _http;

        public SelectionServices(IHttpContextAccessor http)
        {
            _url = "https://mauricioapi-eddggufkfza4a3gv.brazilsouth-01.azurewebsites.net";  
            _http = http;
        }
        public IEnumerable<ExpenseDto> GetExpensesForSelect()
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/api/v1/Expenses", Method.Get);

            request.AddHeader("Content-Type", "application/json");

            var token = _http.HttpContext!.Session.GetString("token");
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            if ((int)response.StatusCode == 200)
            {
                var expenses = JsonSerializer.Deserialize<IEnumerable<ExpenseDto>>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return expenses ?? new List<ExpenseDto>();
            }

            return new List<ExpenseDto>();
        }

        public IEnumerable<UserSelectDto> GetUsersForSelect()
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/api/v1/Users/getAll", Method.Get);

            request.AddHeader("Content-Type", "application/json");

            var token = _http.HttpContext!.Session.GetString("token");
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            if ((int)response.StatusCode == 200)
            {
                var users = JsonSerializer.Deserialize<IEnumerable<UserSelectDto>>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return users ?? new List<UserSelectDto>();
            }

            return new List<UserSelectDto>();
        }
    }
}
