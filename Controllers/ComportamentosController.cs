using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Models;

namespace TesteFullStackPleno.Controllers
{
    [Route("api/v1/[controller]")]
    public class ComportamentosController : Controller
    {
        private readonly IMapper _mapper;

        public ComportamentosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Comportamento), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]ComportamentoRequest request)
        {
            var comportamento = _mapper.Map<Comportamento>(request);

            return Ok(comportamento);
        }
    }
}
