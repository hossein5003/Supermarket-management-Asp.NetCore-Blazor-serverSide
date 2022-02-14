using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class TransactionUseCase : ITransactionUseCase
    {
        private readonly IProductUseCase _productUseCase;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionUseCase(IProductUseCase productUseCase, ITransactionRepository transactionRepository)
        {
            _productUseCase = productUseCase;
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetAllTransactions(string cashierName)
        {
            return _transactionRepository.GetAllTransactions(cashierName);
        }

        public IEnumerable<Transaction> GetTodayTransactions(string cashierName)
        {
            return _transactionRepository.GetTransactionsByDay(cashierName, DateTime.Now);
        }

        public IEnumerable<Transaction> GetTransactionsByPeriodOfTime(string cashierName, DateTime start, DateTime end)
        {
            return _transactionRepository.GetTransactionsByPeriodOfTime(cashierName,start,end);
        }

        public void saveTransaction(string cashierName, int Id, double price, int beforeQuantity, int soldQuantity)
        {
            var product = _productUseCase.GetProductById(Id);

            _transactionRepository.saveTransaction(cashierName, Id, product.Price.Value, beforeQuantity,soldQuantity);
        }
    }
}
