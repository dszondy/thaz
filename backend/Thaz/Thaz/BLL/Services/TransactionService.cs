using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.Repositories;

namespace Thaz.BLL.Services
{
    public class TransactionService
    {
        public TransactionService(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository;
        }

        private ITransactionRepository TransactionRepository { get; }

        public TransactionDetails Create(TransactionDetails transaction)
        {
            return TransactionRepository.Create(transaction);
        }

        public TransactionDetails Update(TransactionDetails transaction)
        {
            return TransactionRepository.Update(transaction);
        }

        public TransactionDetails Get(int id)
        {
            return TransactionRepository.Get(id);
        }

        public List<Transaction> List(TransactionSearchParams transactionSearch)
        {
            return TransactionRepository.List(transactionSearch);
        }
    }
}