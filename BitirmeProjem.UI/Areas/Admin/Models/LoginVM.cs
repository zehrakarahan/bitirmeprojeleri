using System.ComponentModel.DataAnnotations;

namespace BitirmeProjem.UI.Areas.Admin.Models
{
    public class LoginVM : BaseModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}