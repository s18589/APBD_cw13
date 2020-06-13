using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.DTO.Requests
{
    public class WyrobCukierniczyRequest
    {
        public int Ilość { get; set; }
        public string Wyrób { get; set; }
        public string Uwagi { get; set; }

    }
}
