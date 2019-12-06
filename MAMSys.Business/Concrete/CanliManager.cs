using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMSys.Business.Abstract;
using MAMSys.Business.Constants;
using MAMSys.Business.ValidationRules.FluentValidation;
using MAMSys.Core.Aspects.Autofac;
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
            return new SuccessDataResult<Canli>(_CanliDal.Getir(x => x.Id == Id));
        }

        public IDataResult<List<Canli>> GetList()
        {
            return new SuccessDataResult<List<Canli>>(_CanliDal.GetirListe().ToList());
        }

        public IDataResult<List<Canli>> GetListByIrkId(int irkId)
        {
            return new SuccessDataResult<List<Canli>>(_CanliDal.GetirListe(x => x.IrkId == irkId).ToList());
        }
        [ValidationAspect(typeof(CanliValidator))]
        public IDataResult<Canli> Add(Canli Canli)
        {
            return new SuccessDataResult<Canli>(_CanliDal.Ekle(Canli), Messages.HayvanEklendi);

        }

        public IDataResult<Canli> Update(Canli Canli)
        {
            return new SuccessDataResult<Canli>(_CanliDal.Guncelle(Canli), Messages.HayvanEklendi);
        }

        public IDataResult<Canli> Delete(Canli Canli)
        {
            return new SuccessDataResult<Canli>(_CanliDal.Sil(Canli), Messages.HayvanEklendi);

        }
    }
}
