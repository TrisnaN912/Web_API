using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaryawanController : ControllerBase
    {
        MyContext myContext;
        public KaryawanController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        //Read
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Karyawan.ToList();
            if (data == null)
                return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }
        //Create
        [HttpPost]
        public IActionResult Post(Karyawan karyawan)
        {
            myContext.Karyawan.Add(karyawan);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambahkan data" });
            return Ok(new { statusCode = 400, message = "gagal menambahkan data" });
        }
        //Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, Karyawan karyawan)
        {
            var data = myContext.Karyawan.Find(id);
            data.Nama = karyawan.Nama;
            data.Alamat = karyawan.Alamat;
            data.Email = karyawan.Email;
            data.NoHP = karyawan.NoHP;
            myContext.Karyawan.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return Ok(new { statusCode = 400, message = "gagal mengupdate data" });
        }
        //Delete
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var data = myContext.Karyawan.Find(id);
            myContext.Karyawan.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return Ok(new { statusCode = 400, message = "gagal menghapus data" });
        }
    }
}
