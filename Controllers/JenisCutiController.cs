using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenisCutiController : ControllerBase
    {
        MyContext myContext;
        public JenisCutiController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        //Read
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.JenisCuti.ToList();
            if (data == null)
                return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }
        //Create
        [HttpPost]
        public IActionResult Post(JenisCuti jenisCuti)
        {
            myContext.JenisCuti.Add(jenisCuti);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambahkan data" });
            return Ok(new { statusCode = 400, message = "gagal menambahkan data" });
        }
        //Update
        [HttpPut("{id}")]

        public IActionResult Put(int id, JenisCuti jenisCuti)
        {
            var data = myContext.JenisCuti.Find(id);
            data.Nama = jenisCuti.Nama;
            myContext.JenisCuti.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return Ok(new { statusCode = 400, message = "gagal mengupdate data" });
        }
        //Delete
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var data = myContext.JenisCuti.Find(id);
            myContext.JenisCuti.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return Ok(new { statusCode = 400, message = "gagal menghapus data" });
        }
    }
}
