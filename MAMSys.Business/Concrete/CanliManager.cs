using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMSys.Business.Abstract;
using MAMSys.Business.Constants;
using MAMSys.Business.ValidationRules.FluentValidation;
using MAMSys.Core.Aspects.Autofac;
using MAMSys.Core.Aspects.Autofac.Caching;
using MAMSys.Core.Aspects.Autofac.Validation;
using MAMSys.Core.Utilities.Result;
using MAMSys.DataAccess.Abstract;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Concrete
{
    class CanliManager : ICanliServis
    {
        private ICanliDal _CanliDal;

        public CanliManager(ICanliDal CanliDal)
        {
            _CanliDal = CanliDal;
        }

        public IDataResult<Canli> GetById(int Id)
        {
            return new SuccessDataResult<Canli>(_CanliDal.Get(x => x.Id == Id));
        }

        public IDataResult<List<Canli>> GetList()
        {
            return new SuccessDataResult<List<Canli>>(_CanliDal.GetList().ToList());
        }

        public IDataResult<List<Canli>> GetListByIrkId(int irkId)
        {
            return new SuccessDataResult<List<Canli>>(_CanliDal.GetList(x => x.IrkId == irkId).ToList());
        }
        [ValidationAspect(typeof(CanliValidator))]
        [CacheRemoveAspect("ICanliService.GetList")]
        public IDataResult<Canli> Add(Canli canli)
        {
            return new SuccessDataResult<Canli>(_CanliDal.Add(canli), Messages.HayvanEklendi);

        }

        public IDataResult<Canli> Update(Canli canli)
        {
            return new SuccessDataResult<Canli>(_CanliDal.Update(canli), Messages.HayvanEklendi);
        }

        public IDataResult<Canli> Delete(Canli canli)
        {
            return new SuccessDataResult<Canli>(_CanliDal.Delete(canli), Messages.HayvanEklendi);

        }
    }
}
