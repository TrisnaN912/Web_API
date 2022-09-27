using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Cuti
    {
        [Key]
        public int IdCuti { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        private string _Status = "Menunggu Konfirmasi";
        public string Status { get { return _Status; } set { _Status = "Menunggu Konfirmasi"; } }
        public Karyawan Karyawan { get; set; }
        [ForeignKey ("Karyawan")]
        public int IdKaryawan { get; set; }
        public JenisCuti JenisCuti { get; set; }
        [ForeignKey("JenisCuti")]
        public int IdJenisCuti { get; set; }
    }
}
