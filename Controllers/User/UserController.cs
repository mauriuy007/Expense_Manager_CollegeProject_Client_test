using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using N3C_348209_parodi_client.Models.Dtos.User;
using RestSharp;

namespace N3C_348209_parodi_client.Controllers.User
{
    public class UserController : Controller
    {
        private string _url = "https://mauricioapi-eddggufkfza4a3gv.brazilsouth-01.azurewebsites.net";

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View(new UserIndexDto());
        }

        [HttpPost]
        public IActionResult ResetPassword(UserIndexDto dto)
        {
            var endpoint = "/api/v1/Users/reset";

            var client = new RestClient(_url);
            var request = new RestRequest(endpoint, Method.Put);

            request.AddHeader("Content-Type", "application/json");

            request.AddHeader("Authorization", $"Bearer {HttpContext.Session.GetString("token")}");

            request.AddJsonBody(dto);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonSerializer.Deserialize<UserPasswordResetResponse>(
                    response.Content!,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                ViewBag.NewPassword = result.newPassword;
                return View(dto);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                ViewBag.Error = "El usuario no existe.";
            }
            else
            {
                ViewBag.Error = "Error desconocido al resetear la contraseña.";
            }

            return View(dto);
        }

    }
}

