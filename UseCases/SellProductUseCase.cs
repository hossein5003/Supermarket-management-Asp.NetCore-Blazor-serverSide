using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ITransactionUseCase _transactionUseCase;
        public SellProductUseCase(IProductRepository productRepository, ITransactionUseCase transactionUseCase)
        {
            _productRepository = productRepository;
            _transactionUseCase = transactionUseCase;
        }

        public void sellProduct(string cashierName,int productId, int quantity)
        {
            var product = _productRepository.GetProductById(productId);

            if (product == null)
                return;

            int beforeQuantity = product.Quantity.Value;
            product.Quantity -= quantity;

            _transactionUseCase.saveTransaction(cashierName, productId,product.Price.Value,beforeQuantity, quantity);
        }
    }
}
