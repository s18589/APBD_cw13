using APBD_cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.DTO.Requests
{
    public class PutOrderRequest
    {
        public DateTime DataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        public List<WyrobCukierniczyRequest> Wyroby { get; set; }
    }
}
