using Business.Abstract;
using Core.Utilities.Abstract.Results;
using Core.Utilities.Results.Abstract;
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

        public IResult Add(Product product)
        {
            throw new NotImplementedException();
        }

        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
