using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using N3C_348209_parodi_client.Models.Dtos.User;
using RestSharp;

namespace N3C_348209_parodi_client.Controllers.Home
{
    public class HomeController : Controller
    {
        private string _url = "https://mauricioapi-eddggufkfza4a3gv.brazilsouth-01.azurewebsites.net";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto dto)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/api/v1/Auth/login", Method.Post);

            request.AddJsonBody(dto);

            RestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var loginResponse = JsonSerializer.Deserialize<UserLoginResponseDto>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                HttpContext.Session.SetString("token", loginResponse.Token);
                HttpContext.Session.SetString("email", loginResponse.Email);
                HttpContext.Session.SetString("role", loginResponse.Role);
                HttpContext.Session.SetString("userId", loginResponse.Id.ToString());

                return RedirectToAction("Create", "Payment");
            }

            ViewBag.Error = "Email o contraseña incorrectos";
            return View(dto);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
