using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcens.Validation;
using Core.Utilities.Abstract.Results;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Bir Servise sadece kendinin dalını alabilir
        IProductDal _prodcutDal;                                // Şu Demek Sen bana IPRoductDal referansı var. Yarın Hibernate de olabilir, EntityFramework'te olabilir, InMemory de olabilir demek
        ICategoryService _categoryService;                      // Micro Servis örneğidir.

        public ProductManager(IProductDal prodcutDal, ICategoryService categoryService)
        {
            _prodcutDal = prodcutDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]   // Method Success olduğunda çalışacak. Bellekteki IProducService içerisinde tüm Get olan tüm Key leri sil demek
        public IResult Add(Product product)
        {
            // Pollymorhizm'e iyi bir örnek
           IResult result =  BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
               CheckIfProductNameExist(product.ProductName),
               CheckIfCategoryLimitExceded());

            if (result!=null)
            {
                return result;
            }

            _prodcutDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
        //
        // Her methodun üstüne cache koymak doğru değildir. Cache şişer.
        // Onun için en çok kullanılan en çok ihtiyacı olan yerlere konur cache aspect'i
        [CacheAspect] // key (cache ismi), value
        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_prodcutDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_prodcutDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]   // Method Success olduğunda çalışacak. Bellekteki IProducService içerisinde tüm Get olan tüm Key leri sil demek
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _prodcutDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }
        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _prodcutDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();

        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();

            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();

        }


    }
}
