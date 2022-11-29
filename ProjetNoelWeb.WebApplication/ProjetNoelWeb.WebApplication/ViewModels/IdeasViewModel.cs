using ProjetNoelWeb.WebApplication.Models;

namespace ProjetNoelWeb.WebApplication.ViewModels
{
    public class IdeasViewModel
    {
        public Liste Liste { get; set; }
        public IEnumerable<Idea> Ideas { get; set; }
    }
}
