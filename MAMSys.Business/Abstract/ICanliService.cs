using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Utilities.Result;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Abstract
{
    public interface ICanliServis
    {
        IDataResult<Canli> GetById(int Id);
        IDataResult<List<Canli>> GetList();
        IDataResult<List<Canli>> GetListByIrkId(int irkId);
        IDataResult<Canli> Add(Canli Canli);
        IDataResult<Canli> Update(Canli Canli);
        IDataResult<Canli> Delete(Canli Canli);


    }
}
