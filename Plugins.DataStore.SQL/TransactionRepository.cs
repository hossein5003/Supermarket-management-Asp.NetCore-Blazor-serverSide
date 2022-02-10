using CoreBusiness;
using Plugins.DataSore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DateStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext _db;

        public TransactionRepository(ApplicationContext db)
        {
            _db = db;
        }

        public IEnumerable<Transaction> GetAllTransactions(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return _db.Transactions.ToList();

            return _db.Transactions.Where(transaction => transaction.cashierName == cashierName);
        }

        public IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime day)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return _db.Transactions.Where(transaction => transaction.timeStamp.Date == day.Date);

            return _db.Transactions.Where(transaction =>
            transaction.timeStamp.Date == day.Date && transaction.cashierName.ToLower() == cashierName.ToLower());
        }

        public IEnumerable<Transaction> GetTransactionsByPeriodOfTime(string cashierName, DateTime start, DateTime end)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return _db.Transactions.Where(transaction =>
                transaction.timeStamp.Date >= start.Date && transaction.timeStamp.Date <= end.Date.AddDays(1).Date);

            return _db.Transactions.Where(transaction =>
                transaction.timeStamp.Date >= start.Date &&
                transaction.timeStamp.Date <= end.Date.AddDays(1).Date &&
                transaction.cashierName.ToLower() == cashierName.ToLower());
        }

        public void saveTransaction(string cashierName, int productId, double price, int beforeQuantity, int soldQuantity)
        {
            var transaction = new Transaction()
            {
                cashierName = cashierName,
                ProductId = productId,
                price = price,
                beforeQuantity = beforeQuantity,
                soldQuantity = soldQuantity,
                timeStamp = DateTime.Now,
            };

            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }
    }
}
