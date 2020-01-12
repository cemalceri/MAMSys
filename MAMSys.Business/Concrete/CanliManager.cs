using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMSys.Business.Abstract;
using MAMSys.Business.BusinessAspects.Autofac;
using MAMSys.Business.Constants;
using MAMSys.Business.ValidationRules.FluentValidation;
using MAMSys.Core.Aspects.Autofac;
using MAMSys.Core.Aspects.Autofac.Caching;
using MAMSys.Core.Aspects.Autofac.Performance;
using MAMSys.Core.Aspects.Autofac.Validation;
using MAMSys.Core.Utilities.Result;
using MAMSys.DataAccess.Abstract;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.Concrete
{
    class CanliManager : ICanliServis
    {
        private readonly ICanliDal _canliDal;

        public CanliManager(ICanliDal canliDal)
        {
            _canliDal = canliDal;
        }

        public IDataResult<Canli> GetById(int id)
        {
            return new SuccessDataResult<Canli>(_canliDal.Getir(x => x.Id == id));
        }

        public IDataResult<List<Canli>> GetList()
        {
            return new SuccessDataResult<List<Canli>>(_canliDal.GetirListe().ToList());
        }
        [PerformanceAspect(1)]
        public IDataResult<List<Canli>> GetListByIrkId(int irkId)
        {
            return new SuccessDataResult<List<Canli>>(_canliDal.GetirListe(x => x.IrkId == irkId).ToList());
        }
        [ValidationAspect(typeof(CanliValidator))]
        [CacheRemoveAspect("ICanliService.GetList")]
        public IDataResult<Canli> Add(Canli canli)
        {
            return new SuccessDataResult<Canli>(_canliDal.Ekle(canli), Messages.HayvanEklendi);

        }
        [SecuredOperation("Canli.Update,Admin")]
        public IDataResult<Canli> Update(Canli canli)
        {
            return new SuccessDataResult<Canli>(_canliDal.Guncelle(canli), Messages.HayvanEklendi);
        }

        public IDataResult<Canli> Delete(Canli canli)
        {
            return new SuccessDataResult<Canli>(_canliDal.Sil(canli), Messages.HayvanEklendi);

        }
    }
}
