using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Infrastructure.Services;
using TesteFullStackPleno.Models;

namespace TesteFullStackPleno.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageQueueService _messageQueueService;
        public HomeController(IMessageQueueService messageQueueService)
        {
            _messageQueueService = messageQueueService;
        }

        public IActionResult Index()
        {
            //ExtractAndPublishComportamentoMessage();

            return View();
        }

        public IActionResult Checkout()
        {
            //ViewData["Message"] = "Tela de checkout.";

            //ExtractAndPublishComportamentoMessage();

            return View();
        }

        public IActionResult Confirmacao()
        {
            //ViewData["Message"] = "Tela de Confirmacao.";

            //ExtractAndPublishComportamentoMessage();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetUserAgent(HttpContext context)
        {
            var userAgent = context.Request.Headers["User-Agent"];
            return Convert.ToString(userAgent[0]);
        }

        private void ExtractAndPublishComportamentoMessage()
        {
            var httpContext = Request.HttpContext;

            var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            var browser = GetUserAgent(httpContext);
            var action = httpContext.Request.Path.Value;
            var parametros = httpContext.Request.QueryString.ToString();

            var comportamento = new Comportamento(ipAddress, action, browser, parametros);
            var comportamentoString = JsonConvert.SerializeObject(comportamento);

            _messageQueueService.Send(Encoding.UTF8.GetBytes(comportamentoString));
        }
    }
}
