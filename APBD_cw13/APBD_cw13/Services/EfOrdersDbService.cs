using APBD_cw13.DTO.Requests;
using APBD_cw13.DTO.Responses;
using APBD_cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Services
{
    public class EfOrdersDbService : IOrdersDbService
    {
        private readonly s18589Context _context;

        public EfOrdersDbService(s18589Context context)
        {
            _context = context;
        }

        public GetOrdersResponse GetOrders()
        {
            return new GetOrdersResponse
            {
                Orders = _context.Zamowienie.ToList()
            };
        }

        public GetOrdersResponse GetOrders(GetOrdersByLastNameRequest request)
        {
            Klient k = _context.Klient.FirstOrDefault(s => s.Nazwisko == request.LastName);
            var query = from zamowienie in _context.Zamowienie
                        .Where(zamowienie => zamowienie.IdKlient == k.IdKlient)
                        select zamowienie;

            return new GetOrdersResponse
            {
                Orders = query.ToList()
            };
        }
    }
}
