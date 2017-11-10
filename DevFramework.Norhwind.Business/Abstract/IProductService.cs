using DevFramework.Norhwind.Entities.Concrete;
using System.Collections.Generic;
using System.ServiceModel;

namespace DevFramework.Norhwind.Business.Abstract
{
    [ServiceContract]// wcf için
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();

        [OperationContract]
        Product GetById(int id);

        [OperationContract]
        Product Add(Product product);

        [OperationContract]
        Product Update(Product product);

        [OperationContract]
        void TransactionalOperation(Product product1, Product product2);

    }
}
