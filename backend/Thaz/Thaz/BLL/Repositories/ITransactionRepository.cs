using System.Collections.Generic;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;

namespace Thaz.BLL.Repositories
{
    public interface ITransactionRepository
    {
        TransactionDetails Create(TransactionDetails transaction);
        TransactionDetails Update(TransactionDetails transaction);
        TransactionDetails Get(int id);
        List<Transaction> List(TransactionSearchParams transactionSearch);
    }
}