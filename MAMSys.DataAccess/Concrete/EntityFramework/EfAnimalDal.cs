using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.DataAccess.EntityFramework;
using MAMSys.DataAccess.Abstract;
using MAMSys.DataAccess.Concrete.EntityFramework.Context;
using MAMSys.Entites.Concrete;

namespace MAMSys.DataAccess.Concrete.EntityFramework
{
    public class EfAnimalDal : EfEntityRepositoryBase<Animal, MamsysContext>, IAnimalDal
    {
    }
}
