using ProjetNoelWeb.WebApplication.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetNoelWeb.WebApplication.Models
{
    public class Idea : BaseModel
    {
        [Required]
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? UrlIdea { get; set; }
        [Required]
        public bool? IsTake { get; set; }
        [JsonIgnore]
        public Liste? Liste { get; set; }
        public int IdListe { get; set; }
    }
}
