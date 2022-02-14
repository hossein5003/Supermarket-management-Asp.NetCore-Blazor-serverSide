using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCaseInterfaces
{
    public interface ITransactionUseCase
    {
        public IEnumerable<Transaction> GetTodayTransactions(string cashierName);
        public void saveTransaction(string cashierName, int Id, double price, int beforeQuantity, int soldQuantity);
        public IEnumerable<Transaction> GetAllTransactions(string cashierName);
        public IEnumerable<Transaction> GetTransactionsByPeriodOfTime(string cashierName, DateTime start, DateTime end);
    }
}
