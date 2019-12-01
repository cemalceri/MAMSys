using System.Collections.Generic;
using MAMSys.Core.Entities.Concrete;

namespace MAMSys.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Kullanici kullanici, List<Rol> roller);
    }
}
