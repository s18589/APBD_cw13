using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_cw13.DTO.Requests;
using APBD_cw13.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cw13.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsDbService _context;

        public ClientsController(IClientsDbService context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/clients/{id}/orders")]
        public IActionResult PutOrder(int id, PutOrderRequest request)
        {
            IActionResult result;

            try
            {
                _context.PutOrder(id, request);
                result = Ok();
            }catch (ArgumentException e)
            {
                result = BadRequest(e.Message);
            }
            return result;
        }
    }
}