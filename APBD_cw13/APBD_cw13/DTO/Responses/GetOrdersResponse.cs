using APBD_cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.DTO.Responses
{
    public class GetOrdersResponse
    {
        public List<Zamowienie> Orders { get; set; }
    }
}
