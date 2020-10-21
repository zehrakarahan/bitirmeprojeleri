using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitirmeProjem.UI.Models.VM
{
    public class UyeOl
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Sifre { get; set; }
        public string Mesaj { get; set; }
    }
}