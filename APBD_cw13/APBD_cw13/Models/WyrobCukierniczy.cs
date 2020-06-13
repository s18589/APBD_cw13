﻿using System;
using System.Collections.Generic;

namespace APBD_cw13.Models
{
    public partial class WyrobCukierniczy
    {
        public WyrobCukierniczy()
        {
            ZamowienieWyrobCukierniczy = new HashSet<ZamowienieWyrobCukierniczy>();
        }

        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public int CenaZaSzt { get; set; }
        public string Typ { get; set; }

        public virtual ICollection<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }
    }
}
