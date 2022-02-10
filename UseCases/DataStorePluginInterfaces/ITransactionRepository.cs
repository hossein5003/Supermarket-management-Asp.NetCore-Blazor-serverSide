using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime day);
        public IEnumerable<Transaction> GetAllTransactions(string cashierName);
        public void saveTransaction(string cashierName, int productId, double price, int beforeQuantity, int soldQuantity);
        public IEnumerable<Transaction> GetTransactionsByPeriodOfTime(string cashierName ,DateTime start,DateTime end);
    }
}
