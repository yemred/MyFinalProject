using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _prodcutDal;                                // Şu Demek Sen bana IPRoductDal referansı var. Yarın Hibernate de olabilir, EntityFramework'te olabilir, InMemory de olabilir demek

        public ProductManager(IProductDal prodcutDal)
        {
            _prodcutDal = prodcutDal;
        }

        public List<Product> GetAll()
        {
            return _prodcutDal.GetAll();
        }
    }
}
