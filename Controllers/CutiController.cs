using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutiController : ControllerBase
    {
        MyContext myContext;
        public CutiController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        //Read
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Cuti.Include(x => x.Karyawan).Include(y => y.JenisCuti).ToList();
            if (data == null)
                return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }
        //Create
        [HttpPost]
        public IActionResult Post(Cuti cuti)
        {
            myContext.Cuti.Add(cuti);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambahkan data" });
            return Ok(new { statusCode = 400, message = "gagal menambahkan data" });
        }
        //Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, Cuti cuti)
        {
            var data = myContext.Cuti.Find(id);
            data.StartDate = cuti.StartDate;
            data.EndDate = cuti.EndDate;
            data.IdKaryawan = cuti.IdKaryawan;
            data.IdJenisCuti = cuti.IdJenisCuti;
            myContext.Cuti.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return Ok(new { statusCode = 400, message = "gagal mengupdate data" });
        }
        //Delete
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var data = myContext.Cuti.Find(id);
            myContext.Cuti.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return Ok(new { statusCode = 400, message = "gagal menghapus data" });
        }
    }
}
