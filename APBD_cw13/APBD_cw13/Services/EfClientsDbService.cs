using APBD_cw13.DTO.Requests;
using APBD_cw13.DTO.Responses;
using APBD_cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Services
{
    public class EfClientsDbService : IClientsDbService
    {
        private readonly s18589Context _context;

        public EfClientsDbService(s18589Context context)
        {
            _context = context;
        }
        public void PutOrder(int id, PutOrderRequest request)
        {
            if(!_context.Klient.Any(k => k.IdKlient == id))
            { 
                throw new ArgumentException($"Nie ma klienta z {id} w bazie");
            }
            
            foreach(var wyrob in request.Wyroby)
            {
                var check = _context.WyrobCukierniczy.Any(w => w.Nazwa.Equals(wyrob.Wyrób));
                if (!check)
                {
                    throw new ArgumentException($"Nie ma takiego wyrobu jak {wyrob.Wyrób}");
                }
            }

            int noweId = _context.Zamowienie.Max(z => z.IdZamowienia) + 1;
            _context.Zamowienie.Add(new Zamowienie
            {
                IdZamowienia = noweId,
                DataPrzyjecia = request.DataPrzyjecia,
                Uwagi = request.Uwagi,
                IdKlient = id
            });

            foreach(var wyrob in request.Wyroby)
            {
                _context.ZamowienieWyrobCukierniczy.Add(new ZamowienieWyrobCukierniczy
                {
                    IdWyrobuCukierniczego = _context.WyrobCukierniczy.Single(w => w.Nazwa.Equals(wyrob.Nazwa)).IdWyrobuCukierniczego,
                    IdZamowienia = noweId,
                    Ilosc = wyrob.Ilość,
                    Uwagi = wyrob.Uwagi
                });
            }

            _context.SaveChanges();
        }
    }
}
