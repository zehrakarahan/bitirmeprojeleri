using Core.Utilities.Enum;

namespace BitirmeProjem.UI.Areas.Admin.Models
{
    public class BaseModel
    {
        public string Message { get; set; }
        public Enums.StatusEnum Status { get; set; }
    }
}