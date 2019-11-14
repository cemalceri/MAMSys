using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Entities.Concrete;

namespace MAMSys.Core.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Kullanici kullanici, List<Rol> roller);
    }
}
