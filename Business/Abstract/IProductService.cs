using Core.Utilities.Abstract.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
      IDataResult<List<Product>> GetAll();
      IDataResult<List<Product>> GetAllByCategoryId(int id);
      IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
      IDataResult<List<Product>> GetProductDetails();
      IDataResult<Product> GetById(int productId);
      IResult Add(Product product);
      IResult Update(Product product);

      //
      // Uygulamarda tutarlılığı korumak için yaptığımız bir method. 
      IResult AddTransactionalTest(Product product);
    }
}
