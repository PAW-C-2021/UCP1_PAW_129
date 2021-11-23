using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ucp1_129.Models
{
    public partial class Obat
    {
        public int IdObat { get; set; }
        public string NamaObat { get; set; }
        public string Harga { get; set; }
    }
}
