using ProjetNoelWeb.WebApplication.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetNoelWeb.WebApplication.Models
{
    public class Squad : BaseModel
    {
        [JsonIgnore]
        public List<User>? Users { get; set; }
        [JsonIgnore]
        public List<Liste>? Listes { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Code { get; set; }
    }
}
