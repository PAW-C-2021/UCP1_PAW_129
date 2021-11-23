using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ucp1_129.Models
{
    public partial class Kasir
    {
        public int IdKasir { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string Umur { get; set; }
    }
}
