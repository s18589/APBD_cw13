using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_cw13.DTO.Requests;
using APBD_cw13.Models;
using APBD_cw13.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       private readonly IOrdersDbService _context;

       public OrdersController(IOrdersDbService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            IActionResult result;
            try
            {
                result = Ok(_context.GetOrders());
            }catch(Exception e)
            {
                result = BadRequest("Błąd przy pobieraniu danych " + e.StackTrace);
            }
            return result;
        }

        [HttpGet]
        public IActionResult GetOrders(GetOrdersByLastNameRequest request)
        {

            IActionResult result;
            try
            {
                result = Ok(_context.GetOrders(request));
            }
            catch (Exception e)
            {
                result = BadRequest("Błąd przy pobieraniu danych " + e.StackTrace);
            }
            return result;
        }
    }
}