using MAMSys.Business.Abstract;
using MAMSys.Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MAMSys.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanliController : ControllerBase
    {
        private readonly ICanliServis _Canliervice;

        public CanliController(ICanliServis Canliervice)
        {
            _Canliervice = Canliervice;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _Canliervice.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _Canliervice.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getlistbyirkid")]
        public IActionResult GetByIrkId(int id)
        {
            var result = _Canliervice.GetListByIrkId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Canli Canli)
        {
            var result = _Canliervice.Add(Canli);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Canli Canli)
        {
            var result = _Canliervice.Add(Canli);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Canli Canli)
        {
            var result = _Canliervice.Delete(Canli);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}