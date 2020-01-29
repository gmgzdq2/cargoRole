using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Kargocu
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public string TelNo { get; set; }
        public int KargoSirketiId { get; set; }
        public KargoSirketi KargoSirketi { get; set; }
        public ICollection<Kargo> Kargo { get; set; }
    }
}