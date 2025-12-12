using Microsoft.AspNetCore.Mvc;
using N3C_348209_parodi_client.Models.Dtos.Team;
using RestSharp;

namespace N3C_348209_parodi_client.Controllers.Team
{
    public class TeamController : Controller
    {
        private string _url = "https://mauricioapi-eddggufkfza4a3gv.brazilsouth-01.azurewebsites.net";
        [HttpGet]
        public IActionResult GetTeamsByPayments()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetTeams(double amount)
        {
            var client = new RestClient(_url);
            var request = new RestRequest($"/api/v1/Teams/TeamsByAmount?amount={amount}", Method.Get);

            request.AddHeader("Authorization", $"Bearer {HttpContext.Session.GetString("token")}");

            var response = client.Execute<IEnumerable<TeamDto>>(request);

            if ((int)response.StatusCode != 200)
            {
                ViewBag.Message = "No se encontraron equipos con ese monto.";
                return View("GetTeamsByPayments", Enumerable.Empty<TeamDto>());
            }

            return View("GetTeamsByPayments", response.Data);
        }
    }
}
