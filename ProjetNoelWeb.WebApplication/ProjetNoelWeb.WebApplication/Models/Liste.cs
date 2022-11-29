using ProjetNoelWeb.WebApplication.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetNoelWeb.WebApplication.Models
{
    public class Liste : BaseModel
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [Required]
        public int IdCreator { get; set; }
        [JsonIgnore]
        public Squad? Squad { get; set; }
        [Required]
        public int IdSquad { get; set; }
        [JsonIgnore]
        public List<Idea>? Ideas { get; set; }
    }
}
