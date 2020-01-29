using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Kargo
    {
        public int Id { get; set; }
        public int KargocuId { get; set; }
        public int DurumID { get; set; }
        public int UrunId { get; set; }
        public DateTime SonIslemTarihi { get; set; }
        public virtual Durum Durum { get; set; }
        public virtual Kargocu Kargocu { get; set; }
        public virtual Urun Urun { get; set; }
    }
}