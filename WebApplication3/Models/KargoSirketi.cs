using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class KargoSirketi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int VergiNo { get; set; }
        public ICollection<Kargocu> Kargocu { get; set; }
    }
}