using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAMSys.Business.Abstract;
using MAMSys.Business.Constants;
using MAMSys.Entites.Dtos;

namespace MAMSys.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(KullaniciGirisDto kullaniciGirisDto)
        {
            var kullaniciGiris = _authService.Giris(kullaniciGirisDto);
            if (!kullaniciGiris.Success)
            {
                return BadRequest(kullaniciGiris.Message);
            }

            var result = _authService.AccessTokenOlustur(kullaniciGiris.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("kayit")]
        public ActionResult Kaydet(KullaniciKayitDto kullaniciKayitDto)
        {
            var kayitliMi = _authService.KullaniciVarMi(kullaniciKayitDto.Mail);
            if (!kayitliMi.Success)
            {
                return BadRequest(kayitliMi.Message);
            }
            var kullaniciKayit = _authService.Kaydet(kullaniciKayitDto,kullaniciKayitDto.Sifre);
            var result = _authService.AccessTokenOlustur(kullaniciKayit.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
