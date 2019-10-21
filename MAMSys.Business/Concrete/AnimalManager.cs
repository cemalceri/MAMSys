using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMSys.Business.Abstract;
using MAMSys.Business.Constants;
using MAMSys.Core.Utilities.Result;
using MAMSys.DataAccess.Abstract;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Concrete
{
    class AnimalManager : IAnimalService
    {
        private IAnimalDal _animalDal;

        public AnimalManager(IAnimalDal animalDal)
        {
            _animalDal = animalDal;
        }

        public IDataResult<Animal> GetById(int Id)
        {
            return new SuccessDataResult<Animal>(_animalDal.Get(x => x.Id == Id));
        }

        public IDataResult<List<Animal>> GetList()
        {
            return new SuccessDataResult<List<Animal>>(_animalDal.GetList().ToList());
        }

        public IDataResult<List<Animal>> GetListByIrkId(int irkId)
        {
            return new SuccessDataResult<List<Animal>>(_animalDal.GetList(x => x.IrkId == irkId).ToList());
        }

        public IDataResult<Animal> Add(Animal animal)
        {
            return new SuccessDataResult<Animal>(_animalDal.Add(animal), Messages.HayvanEklendi);

        }

        public IDataResult<Animal> Update(Animal animal)
        {
            return new SuccessDataResult<Animal>(_animalDal.Update(animal), Messages.HayvanEklendi);
        }

        public IDataResult<Animal> Delete(Animal animal)
        {
            return new SuccessDataResult<Animal>(_animalDal.Delete(animal), Messages.HayvanEklendi);

        }
    }
}
