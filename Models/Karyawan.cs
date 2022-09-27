using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Karyawan
    {
        [Key]
        public int IdKaryawan { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
        public string NoHP { get; set; }
    }
}
