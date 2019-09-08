using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Infrastructure.Services;
using TesteFullStackPleno.Models;

namespace TesteFullStackPleno.Controllers
{
    [Route("api/v1/[controller]")]
    public class ComportamentosController : Controller
    {
        private readonly IMessageQueueService _messageQueueService;
        private readonly IMapper _mapper;

        public ComportamentosController(IMessageQueueService messageQueueService, IMapper mapper)
        {
            _messageQueueService = messageQueueService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Comportamento), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]ComportamentoRequest request)
        {
            var httpContext = Request.HttpContext;

            var parametros = httpContext.Request.QueryString.ToString();
            var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            request.Ip = ipAddress;
            request.Parametros = parametros;

            var comportamento = _mapper.Map<Comportamento>(request);

            var comportamentoString = JsonConvert.SerializeObject(comportamento);
            _messageQueueService.Send(Encoding.UTF8.GetBytes(comportamentoString));

            return Ok(comportamento);
        }
    }
}
