using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class JenisCuti
    {
        [Key]
        public int IdJenisCuti { get; set; }
        public string Nama { get; set; }
    }
}
