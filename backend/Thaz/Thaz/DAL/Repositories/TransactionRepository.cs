using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Repositories;
using Thaz.DAL.Entities;
using Thaz.DAL.QueryBuilders;
using Transaction = Thaz.BLL.Model.Transaction;
using User = Thaz.BLL.Model.User;

namespace Thaz.DAL.Repositories
{
    public class TransactionRepository : RepositoryBase, ITransactionRepository
    {

        public TransactionDetails Create(TransactionDetails transaction)
        {
            var entity = new Entities.Transaction();

            if (transaction.Partner != null)
                entity.Partner = Partners
                    .Single(x => x.Id == transaction.Partner.Id);

            if (transaction.Condominium != null)
                entity.Condominium = Condominiums
                    .Single(x => x.Id == transaction.Condominium.Id);
            entity.Tags = transaction.Tags
                .Select(x => new TransactionTag(){Label = x.Label, Ratio = x.Rate})
                .ToList();
            DbContext.AddRange(entity.Tags);
            DbContext.Add(transaction);
            DbContext.SaveChanges();
            
            return entity.ToModelDetails();
        }
        
        public TransactionDetails Update(TransactionDetails transaction)
        {
            var entity = Transactions.Single(x => x.Id == transaction.Id);
            
            entity.Amount = transaction.Amount;
            entity.AccountNumber = transaction.AccountNumber;
            entity.TransactionIdentifier = transaction.TransactionIdentifier;
            entity.Date = transaction.Date;
            entity.Partner = transaction.Partner is null ? null:
                Partners.SingleOrDefault(x => x.Id == transaction.Partner.Id);
            entity.Condominium = transaction.Condominium is null ? null:
                Condominiums.SingleOrDefault(x => x.Id == transaction.Condominium.Id);
            
            DbContext.RemoveRange(DbContext.TransactionTags.Where(x => x.Transaction==entity));
            entity.Tags = transaction.Tags
                .Select(x => new TransactionTag(){Label = x.Label, Ratio = x.Rate})
                .ToList();
            DbContext.AddRange(entity.Tags);
            DbContext.SaveChanges();
            
            return entity.ToModelDetails();
        }


        public TransactionDetails Get(int id)
        {
            return Transactions
                .Include(x =>x.Tags)
                .Single(x => x.Id == id)
                .ToModelDetails();
        }

        public List<Transaction> List(TransactionSearchParams transactionSearch)
        {
            return Transactions
                .ApplySearch(transactionSearch)
                .Select(x => x.ToModel())
                .ToList();
        }

        public TransactionRepository(ThazDbContext dbContext, User user) : base(dbContext, user)
        {
        }
    }
    

}