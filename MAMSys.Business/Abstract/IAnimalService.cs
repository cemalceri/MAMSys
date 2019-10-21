using System;
using System.Collections.Generic;
using System.Text;
using MAMSys.Core.Utilities.Result;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Abstract
{
    public interface IAnimalService
    {
        IDataResult<Animal> GetById(int Id);
        IDataResult<List<Animal>> GetList();
        IDataResult<List<Animal>> GetListByIrkId(int irkId);
        IDataResult<Animal> Add(Animal animal);
        IDataResult<Animal> Update(Animal animal);
        IDataResult<Animal> Delete(Animal animal);


    }
}
