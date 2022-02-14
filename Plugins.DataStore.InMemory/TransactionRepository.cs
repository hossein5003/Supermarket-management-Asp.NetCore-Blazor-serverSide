using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetAllTransactions(string cashierName)
        {
            return _transactions.Where(transaction=>transaction.cashierName.Equals(cashierName,StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime day)
        {
            return _transactions.Where(transaction=>transaction.timeStamp.Date==day.Date &&
            transaction.cashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByPeriodOfTime(string cashierName, DateTime start, DateTime end)
        {
            return _transactions.Where(transaction => 
            transaction.timeStamp.Date >= start.Date &&
            transaction.timeStamp.Date <= end.Date.AddDays(1).Date &&
            transaction.cashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void saveTransaction(string cashierName, int ProductId, double price, int beforeQuantity,int soldQuantity)
        {
            int maxId = 0;
            if (_transactions.Count > 0)
                maxId = _transactions.Max(item => item.Id);

            _transactions.Add(new Transaction()
            {
                Id = maxId + 1,
                ProductId = ProductId,
                price = price,
                soldQuantity = soldQuantity,
                beforeQuantity = beforeQuantity,
                timeStamp = DateTime.Now,
                cashierName= cashierName
            });
        }
    }
}
