using APBD_cw13.DTO.Requests;
using APBD_cw13.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Services
{
    public interface IClientsDbService
    {
        public void PutOrder(int id, PutOrderRequest request);
    }
}
